
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
				.AddScoped<IInterviewRepository, InterviewRepository>()
				.AddScoped<ISurveyRepository, SurveyRepository>()
				.AddScoped<IResultRepository, ResultRepository>()
				.AddScoped<IAnswerRepository, AnswerRepository>();
			services.AddDbContext<OnlineSurveyDbContext>(options =>
			options.UseNpgsql(configuration.GetConnectionString("OnlineSurvey")));
			//services.AddDbContext<OnlineSurveyDbContext>(options =>
			//	options.UseNpgsql("Server=db_survey;User ID=admin;Password=survey;Port=5432;Database=online_survey;Pooling=true;"));

			//services.AddDbContext<OnlineSurveyDbContext>(options =>
			//    options.UseSqlServer(configuration.GetConnectionString("OnlineSurvey")));


			return services;

		}

		public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddScoped<IQuestionService, QuestionService>();
			services.AddScoped<IInterviewService, InterviewService>();
			services.AddScoped<ISurveyService, SurveyService>();
			services.AddScoped<IResultService, ResultService>();
			services.AddScoped<IAnswerService, AnswerService>();

			return services;
		}
	}
}
