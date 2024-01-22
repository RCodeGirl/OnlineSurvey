using Bogus;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineSurvey.Domain.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace OnlineSurvey.Persistence.Extensions
{
    public static class AppBuilderExtensions
    {
        public static IApplicationBuilder MigrateDatabase(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var ctx = scope.ServiceProvider.GetRequiredService<OnlineSurveyDbContext>();

            ctx.Database.Migrate();

            var env = scope.ServiceProvider.GetRequiredService<IHostEnvironment>();
            
            if (!env.IsProduction())
            {
                if (!ctx.Surveys.Any())
                {
                    var surveys = SeedData.GenerateSurveys(numberOfSurveys: 5, questionsPerSurvey: 3, answersPerQuestion: 4, interviewsPerSurvey:1);

                    // Сохранение опросов, вопросов и ответов в базу данных
                    foreach (var survey in surveys)
                    {
                        // Сохранение опроса в базу данных
                        ctx.Surveys.Add(survey);

                        // Сохранение вопросов и ответов в базу данных
                        ctx.Questions.AddRange(survey.Questions);
                        ctx.Answers.AddRange(survey.Questions.SelectMany(q => q.Answers));
                        ctx.Interviews.AddRange(survey.Interviews);
                    }
                    ctx.SaveChanges();
                }
               
            }

            return app;
           

        
        }

        public static class SeedData
        {
            public static List<Survey> GenerateSurveys(int numberOfSurveys, int questionsPerSurvey, int answersPerQuestion, int interviewsPerSurvey)
            {
                var surveyFaker = new Faker<Survey>()
                    .RuleFor(s => s.Id, f => f.Random.Guid())
                    .RuleFor(s => s.Title, f => f.Lorem.Sentence())
                    .RuleFor(s => s.Questions, f => GenerateQuestions(questionsPerSurvey, answersPerQuestion))
                    .RuleFor(s => s.Interviews, f => GenerateInterviews(interviewsPerSurvey));

                return surveyFaker.Generate(numberOfSurveys);
            }

            private static List<Question> GenerateQuestions(int numberOfQuestions, int answersPerQuestion)
            {
                var questionFaker = new Faker<Question>()
                    .RuleFor(q => q.Id, f => f.Random.Guid())
                    .RuleFor(q => q.Order, f => f.IndexVariable+1)
                    .RuleFor(q => q.Title, f => f.Lorem.Sentence())
                    .RuleFor(q => q.Answers, f => GenerateAnswers(answersPerQuestion));

                return questionFaker.Generate(numberOfQuestions);
            }

            private static List<Answer> GenerateAnswers(int numberOfAnswers)
            {
                var answerFaker = new Faker<Answer>()
                    .RuleFor(a => a.Id, f => f.Random.Guid())
                    .RuleFor(a => a.Title, f => f.Lorem.Word());
                    

                return answerFaker.Generate(numberOfAnswers);
            }
            private static List<Interview> GenerateInterviews(int numberOfInterviews)
            {
                var interviewFaker = new Faker<Interview>()
                    .RuleFor(i => i.Id, f => f.Random.Guid())
                    .RuleFor(i => i.SurveyId, f => f.Random.Guid())
                    .RuleFor(i => i.UserId, f => new Guid("BB2DCF2D-9D19-448B-B561-4D81788B2A31"));

                return interviewFaker.Generate(numberOfInterviews);
            }

        }
      
    }
}
