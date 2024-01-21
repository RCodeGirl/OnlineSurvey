using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineSurvey.Abstractions.Repositories;
using OnlineSurvey.Abstractions.Services;
using OnlineSurvey.Infrastructure.Service;
using OnlineSurvey.Persistence;
using OnlineSurvey.Persistence.Repositories;


namespace OnlineSurvey.Infrastructure.DependencyIngection

{
	public static class DependencyIngection
	{
		public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
		{
			services
				.AddScoped<IQuestionRepository, QuestionRepository>()
				.AddScoped<IAnswerRepository, AnswerRepository>();
			//				.AddDbContext<OnlineSurveyDbContext>(options =>
			//options.UseNpgsql(configuration.GetConnectionString("OnlineSurvey")));
			services.AddDbContext<OnlineSurveyDbContext>(options =>
				options.UseNpgsql("Server=db_survey;User ID=admin;Password=survey;Port=5432;Database=online_survey;Pooling=true;"));

			//.AddDbContext<OnlineSurveyDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("OnlineSurvey")));
			return services;

		}

		public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddScoped<IQuestionService, QuestionService>();

			return services;
		}
	}
}
