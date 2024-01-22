using OnlineSurvey.Domain.Entities;
using OnlineSurvey.Shared.Dto;


namespace OnlineSurvey.Abstractions.Services
{
    public interface IInterviewService
    {
        Task<InterviewDto> GetActualInterview(Guid userId, Guid surveyId);
        Task<Guid> Create(Guid surveyId, Guid userId);
        
    }
}
