using OnlineSurvey.Abstractions.Repositories;
using OnlineSurvey.Domain.Entities;
using OnlineSurvey.Persistence.Repositories.Base;


namespace OnlineSurvey.Persistence.Repositories
{
    public class AnswerRepository:BaseRepository<Answer>, IAnswerRepository
    {
        public AnswerRepository(OnlineSurveyDbContext context) : base(context)
        {
                
        }
    }
}
