using OnlineSurvey.Infrastructure.DependencyIngection;
using OnlineSurvey.Persistence.Extensions;


var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var config = builder.Configuration;

services.AddDataAccess(config)
.AddApiServices(config);

services.AddControllers();

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MigrateDatabase();

app.UseHttpsRedirection();
app.UseAuthentication(); 
app.UseAuthorization();
app.MapControllers();

app.Run();
