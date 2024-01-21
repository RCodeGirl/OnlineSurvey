using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OnlineSurvey.Infrastructure.DependencyIngection;
using OnlineSurvey.Persistence;
using Polly;
using Polly.Retry;


var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var config = builder.Configuration;
// Добавьте зависимость настройки базы данных в сервисы
// Add services to the container.
// Переподключение к базе данных с помощью Polly
var retryPolicy = Policy
	.Handle<Exception>() // Обработать любые исключения
	.WaitAndRetry(new[]
	{
				TimeSpan.FromSeconds(1),
				TimeSpan.FromSeconds(2),
				TimeSpan.FromSeconds(5),
		// ... добавьте дополнительные интервалы по желанию
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
	// Вызовите метод для проверки готовности базы данных
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

	// Попробуйте выполнить запрос к базе данных, чтобы проверить готовность
	try
	{
		dbContext.Database.CanConnect();
	}
	catch (Exception ex)
	{
		// Обработка ошибки, если база данных еще не готова
		Console.WriteLine($"Ошибка при подключении к базе данных: {ex.Message}");
		throw;
	}
}
app.Run();
