using OnlineSurvey.Abstractions.Repositories;
using OnlineSurvey.Domain.Entities;
using OnlineSurvey.Persistence.Repositories.Base;


namespace OnlineSurvey.Persistence.Repositories
{
    public class SurveyRepository: BaseRepository<Survey>, ISurveyRepository
    {
        public SurveyRepository(OnlineSurveyDbContext context) : base(context)
        {
            
        }
    }
}
