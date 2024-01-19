using System;
using OnlineSurvey.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace OnlineSurvey.Persistence
{
    public class OnlineSurveyDbContext:DbContext
    {
        public OnlineSurveyDbContext(DbContextOptions<OnlineSurveyDbContext> options):base(options) { }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<Result> Results { get; set; }
    }
}
