using OnlineSurvey.Shared.Dto.Base;


namespace OnlineSurvey.Shared.Dto
{
    public class InterviewDto:BaseDto
    {
        public Guid SurveyId { get; set; }     
        public Guid UserId { get; set; }
    }
}
