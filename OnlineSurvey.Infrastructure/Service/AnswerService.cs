using Microsoft.EntityFrameworkCore;
using OnlineSurvey.Abstractions.Repositories;
using OnlineSurvey.Abstractions.Services;
using OnlineSurvey.Domain.Entities;
using OnlineSurvey.Infrastructure.Mappers;
using OnlineSurvey.Persistence.Repositories;
using OnlineSurvey.Shared.Dto;

namespace OnlineSurvey.Infrastructure.Service
{
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerRepository _answerRepository;
        public AnswerService(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }
        public async Task<Answer> GetByIdAsync(Guid id)
        {
            //var entities = await _questionRepository.Where(_ => _.SurveyId == surveyId).Include(q => q.Answers).ToListAsync();
            var entity = await _answerRepository.Where(_ => _.Id == id).Include(a=>a.Question).FirstOrDefaultAsync();
            return entity;
        }
    }
}
