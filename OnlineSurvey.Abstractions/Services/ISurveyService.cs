using OnlineSurvey.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurvey.Abstractions.Services
{
    public interface ISurveyService
    {
        Task<SurveyDto?> GetByIdAsync(Guid id);
        Task<List<SurveyDto>> GetAllAsync();
    }
}
