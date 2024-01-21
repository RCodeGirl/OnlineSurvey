using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OnlineSurvey.Infrastructure.DependencyIngection;
using OnlineSurvey.Persistence;
using Polly;
using Polly.Retry;


var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var config = builder.Configuration;
// �������� ����������� ��������� ���� ������ � �������
// Add services to the container.
// ��������������� � ���� ������ � ������� Polly
var retryPolicy = Policy
	.Handle<Exception>() // ���������� ����� ����������
	.WaitAndRetry(new[]
	{
				TimeSpan.FromSeconds(1),
				TimeSpan.FromSeconds(2),
				TimeSpan.FromSeconds(5),
		// ... �������� �������������� ��������� �� �������
	});


services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services
    .AddDataAccess(config)
    .AddApiServices(config);
retryPolicy.Execute(() =>
{
	// �������� ����� ��� �������� ���������� ���� ������
	EnsureDatabaseIsReady(services);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
static void EnsureDatabaseIsReady(IServiceCollection services)
{
	using var scope = services.BuildServiceProvider().CreateScope();
	var dbContext = scope.ServiceProvider.GetRequiredService<OnlineSurveyDbContext>();

	// ���������� ��������� ������ � ���� ������, ����� ��������� ����������
	try
	{
		dbContext.Database.CanConnect();
	}
	catch (Exception ex)
	{
		// ��������� ������, ���� ���� ������ ��� �� ������
		Console.WriteLine($"������ ��� ����������� � ���� ������: {ex.Message}");
		throw;
	}
}
app.Run();
