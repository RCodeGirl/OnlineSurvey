using OnlineSurvey.Domain.Entities.Base;

namespace OnlineSurvey.Domain.Entities
{
    public class Interview: BaseEntity
    {
        public Guid SurveyId { get; set; }
        public Survey Survey { get; set; }
        public DateTime InterviewDate { get; set; }
        public Guid UserId { get; set; }       
    }
}
