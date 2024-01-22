using OnlineSurvey.Domain.Entities;
using OnlineSurvey.Shared.Dto;


namespace OnlineSurvey.Abstractions.Services
{
    public interface IAnswerService
    {
        Task<Answer> GetByIdAsync(Guid id);

    }
}
