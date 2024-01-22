using OnlineSurvey.Shared.Dto.Base;


namespace OnlineSurvey.Shared.Dto
{
    public class SurveyDto:BaseDto
    {
        public required string Title { get; set; }

        public string? Description { get; set; } = null;
    }
}
