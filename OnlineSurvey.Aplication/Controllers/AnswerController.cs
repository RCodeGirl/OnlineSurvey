using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineSurvey.Abstractions.Services;
using OnlineSurvey.Domain.Entities;
using OnlineSurvey.Infrastructure.Service;
using OnlineSurvey.Shared.Dto;
using OnlineSurvey.Shared.Exeption;


namespace OnlineSurvey.Aplication.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerService _answerService;
        private readonly IResultService _resultService;
        private readonly IInterviewService _interviewService;
        private readonly IQuestionService _questionService;
        public AnswerController(IAnswerService answerService, IResultService resultService, IInterviewService interviewService, IQuestionService questionService)
        {
            _answerService = answerService;
            _resultService = resultService;
            _interviewService = interviewService;
            _questionService = questionService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SubmitAnswer(Guid answerId)
        {
            var answer = await _answerService.GetByIdAsync(answerId);

            if (answer is null)
                throw new NotFoundException(StatusCodes.Status404NotFound,$"Вопрос с таким Id: {answerId} не найден");

            var question = answer.Question;

            //предположим что у нас есть авторизированный пользователь у которого есть актуальная интервью
            Guid actualUserId = new Guid("BB2DCF2D-9D19-448B-B561-4D81788B2A31");
            var interview = await _interviewService.GetActualInterview(actualUserId, question.SurveyId);

            if(interview is null)
                throw new NotFoundException(StatusCodes.Status404NotFound,
                    $"Не найденно актуальных интервью для авторизированного пользователя");

            var resultDto = new ResultDto
            {
               AnswerId = answer.Id,
               QuestionId = question.Id,
               InterviewId = interview.Id
            };

            await _resultService.Create(resultDto);
            
            var nextQuestion = await _questionService.GetNextQuestion(question.SurveyId, question.Order);
            if (nextQuestion is null)
                return Ok("Интервью успешно пройдено!");

            return Ok(nextQuestion.Id);
        }
    }
}
