using OnlineSurvey.Abstractions.Repositories;
using OnlineSurvey.Domain.Entities;
using OnlineSurvey.Persistence.Repositories.Base;


namespace OnlineSurvey.Persistence.Repositories
{
    public class QuestionRepository:BaseRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(OnlineSurveyDbContext context):base(context)
        {
                
        }
    }
}
