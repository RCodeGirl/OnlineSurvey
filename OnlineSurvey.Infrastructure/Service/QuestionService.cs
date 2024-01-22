using OnlineSurvey.Abstractions.Services;
using OnlineSurvey.Abstractions.Repositories;
using OnlineSurvey.Shared.Dto;
using OnlineSurvey.Infrastructure.Mappers;
using OnlineSurvey.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;



namespace OnlineSurvey.Infrastructure.Service
{
    public class QuestionService : IQuestionService
    {

        private readonly IQuestionRepository _questionRepository;
        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }
        public async Task<QuestionDto?> GetByIdAsync(Guid id)
        {
            var question = await _questionRepository.GetAsync(_ => _.Id == id);

            return question?.Map();
        }

        public async Task<List<QuestionDto>> GetAllAsync(Guid surveyId)
        {
            var entities = await _questionRepository.Where(_ => _.SurveyId == surveyId).Include(q => q.Answers).ToListAsync();

            return entities.Map();
        }

        public async Task<QuestionDto?> GetNextQuestion(Guid surveyId, int previousQuestionOrder)
        {
            var entities = await _questionRepository.Where(_ => _.SurveyId == surveyId && _.Order > previousQuestionOrder)
                .OrderBy(q => q.Order)
                .ToListAsync();
            var entity = entities.FirstOrDefault();
            return entity?.Map();
        }
       
    }
}
