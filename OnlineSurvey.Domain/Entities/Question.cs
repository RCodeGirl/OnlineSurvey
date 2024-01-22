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
       
        public Guid SurveyId { get; set; }

        public Survey Survey { get; set; }
        public List<Answer> Answers { get; set; } = new();

        public int Order { get; set; }

    }
}
