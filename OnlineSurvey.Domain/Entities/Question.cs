using OnlineSurvey.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;


namespace OnlineSurvey.Domain.Entities
{
    /// <summary>
    /// Survey question
    /// </summary>
    public class Question : BaseEntity
    {
        public required string Title { get; set; }

        [ForeignKey("Survey")]
        public Guid SurveyId { get; set; }

        public Survey Survey { get; set; }

        public List<Answer> Answers { get; set; }

        public List<Result> Results { get; set; }


    }
}
