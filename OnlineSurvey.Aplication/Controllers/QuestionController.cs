using Microsoft.AspNetCore.Mvc;
using OnlineSurvey.Abstractions.Services;
using OnlineSurvey.Shared.Dto;


namespace OnlineSurvey.Aplication.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet("{questionId:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<QuestionDto>> Get(Guid questionId)
        {
            var questionDto = await _questionService.GetByIdAsync(questionId);
            return Ok(questionDto);
        }

        [HttpGet("{surveyId:Guid}")]
        [ProducesResponseType(typeof(List<QuestionDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public  async Task<IActionResult> GetAll(Guid surveyId)
        {
            var questionDtos =  await _questionService.GetAllAsync(surveyId);
            return Ok(questionDtos);
        }
        

    }
}
