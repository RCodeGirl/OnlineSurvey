using OnlineSurvey.Domain.Entities.Base;


namespace OnlineSurvey.Domain.Entities
{
    /// <summary>
    /// Data from people's responses to survey questions
    /// </summary>
    public class Result : BaseEntity
    {
        public Guid InterviewId { get; set; }
        public Interview Interview { get; set; }

        public Guid QuestionId { get; set; }
        public Question Question { get; set; }

        public Guid AnswerId { get; set; }
        public  Answer Answer { get; set; }
    }
}
