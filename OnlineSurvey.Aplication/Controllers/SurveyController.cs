using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineSurvey.Abstractions.Services;
using OnlineSurvey.Infrastructure.Service;
using OnlineSurvey.Shared.Dto;

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
		[ProducesResponseType(typeof(List<SurveyDto>),StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetAll()
        {
            var entities=  await _surveyService.GetAllAsync();
            return Ok(entities);
        }
    }
}
