using OnlineSurvey.Domain.Entities;
using OnlineSurvey.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurvey.Abstractions.Services
{
    public interface IQuestionService
    {
        Task<QuestionDto?> GetByIdAsync(Guid id);
        Task<List<QuestionDto>> GetAllAsync(Guid surveyId);
        Task<QuestionDto?> GetNextQuestion(Guid surveyId, int previousQuestion);
       
    }
}
