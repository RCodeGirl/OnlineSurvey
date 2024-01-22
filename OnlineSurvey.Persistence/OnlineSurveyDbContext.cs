using OnlineSurvey.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using static OnlineSurvey.Persistence.Extensions.AppBuilderExtensions;

namespace OnlineSurvey.Persistence
{
    public class OnlineSurveyDbContext : DbContext
    {
        public OnlineSurveyDbContext(DbContextOptions<OnlineSurveyDbContext> options) : base(options)
        {

        }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<Result> Results { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            foreach (var entityType in builder.Model.GetEntityTypes())
            {

                entityType.GetForeignKeys()
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                    .ToList()
                    .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
            }

        }
        
    }
}
