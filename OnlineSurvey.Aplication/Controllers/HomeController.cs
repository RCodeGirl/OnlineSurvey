using Microsoft.AspNetCore.Mvc;
using OnlineSurvey.Abstractions.Services;
using OnlineSurvey.Shared.Dto;

namespace OnlineSurvey.Aplication.Controllers
{
    [Route("api/OnlineSurvey_WebApi")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        public HomeController(IQuestionService questionService)
        {
            _questionService = questionService;
        }
        [HttpGet("{surveyId:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public  ActionResult<List<QuestionDto?>> GetQuestionsBySurveyId( Guid surveyId)
        {
            var questionDtos =   _questionService.GetAllAsync(surveyId);
            return Ok(questionDtos);
        }
    }
}
