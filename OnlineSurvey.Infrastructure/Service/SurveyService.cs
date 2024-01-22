using Microsoft.EntityFrameworkCore;
using OnlineSurvey.Abstractions.Repositories;
using OnlineSurvey.Abstractions.Services;
using OnlineSurvey.Infrastructure.Mappers;
using OnlineSurvey.Persistence.Repositories;
using OnlineSurvey.Shared.Dto;


namespace OnlineSurvey.Infrastructure.Service
{
    public class SurveyService : ISurveyService
    {
        private readonly ISurveyRepository _surveyRepository;
        public SurveyService(ISurveyRepository surveyRepository)
        {
            _surveyRepository = surveyRepository;
        }
        public async Task<List<SurveyDto>> GetAllAsync()
        {
            var entities = await _surveyRepository.Where(_ => true).ToListAsync();

            return entities.Map();
        }

        public async Task<SurveyDto?> GetByIdAsync(Guid id)
        {
            var question = await _surveyRepository.GetAsync(_ => _.Id == id);

            return question?.Map();
        }
    }
}
