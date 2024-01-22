using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineSurvey.Abstractions.Services;
using OnlineSurvey.Shared.Dto;

namespace OnlineSurvey.Aplication.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InterviewController : ControllerBase
    {
        private readonly IInterviewService _interviewService;
        public InterviewController(IInterviewService interviewService)
        {
            _interviewService = interviewService;
        }

        [HttpPost]
		[ProducesResponseType(typeof(Guid),StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> Start(Guid surveyId, Guid userId)
        {
            var interw = await _interviewService.Create(surveyId, userId);
            return Ok(interw);
        }
    }
}
