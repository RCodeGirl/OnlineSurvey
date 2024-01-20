﻿using OnlineSurvey.Abstractions.Services;
using OnlineSurvey.Abstractions.Repositories;
using OnlineSurvey.Shared.Dto;
using OnlineSurvey.Infrastructure.Mappers;
using OnlineSurvey.Domain.Entities;



namespace OnlineSurvey.Infrastructure.Service
{
    public class QuestionService : IQuestionService
    {

        private readonly IQuestionRepository _questionRepository ;
        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }
        public async Task<QuestionDto?> GetByIdAsync(Guid id)
        {
            var question = await _questionRepository.GetAsync(_ => _.Id == id);

            return question?.Map();
        }

        public async Task<List<QuestionDto?>> GetAllAsync(Guid surveyId)
        {
            var entities = await _questionRepository.GetListAsync(_ =>_.SurveyId== surveyId);

            return entities?.Map();
        }

    }
}