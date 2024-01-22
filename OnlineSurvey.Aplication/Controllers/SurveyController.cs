using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineSurvey.Abstractions.Services;
using OnlineSurvey.Infrastructure.Service;

namespace OnlineSurvey.Aplication.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyService _surveyService;
        public SurveyController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var entities=  await _surveyService.GetAllAsync();
            return Ok(entities);
        }
    }
}
