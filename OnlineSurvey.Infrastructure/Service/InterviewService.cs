using OnlineSurvey.Abstractions.Repositories;
using OnlineSurvey.Abstractions.Services;
using OnlineSurvey.Domain.Entities;
using OnlineSurvey.Infrastructure.Mappers;
using OnlineSurvey.Persistence.Repositories;
using OnlineSurvey.Shared.Dto;


namespace OnlineSurvey.Infrastructure.Service
{
    public class InterviewService : IInterviewService
    {
        private readonly IInterviewRepository _interviewRepository;
        public InterviewService(IInterviewRepository interviewRepository)
        {
            _interviewRepository = interviewRepository;
        }
       
        public async Task<Guid> Create(Guid surveyId, Guid userId)
        {           
            var entity = new Interview { SurveyId= surveyId , UserId = userId, InterviewDate = DateTime.Now };
            await _interviewRepository.AddAsync(entity);
            await _interviewRepository.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<InterviewDto> GetActualInterview(Guid userId, Guid surveyId)
        {
            var entity = await _interviewRepository.GetAsync(_ => _.UserId == userId && _.SurveyId == surveyId);
            return entity.Map();
        }
    }
}
