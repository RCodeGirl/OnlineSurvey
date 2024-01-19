using OnlineSurvey.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurvey.Domain.Entities
{
    /// <summary>
    /// Data from people's responses to survey questions
    /// </summary>
    public class Result : BaseEntity
    {
        [ForeignKey("Interview")]
        public Guid InterviewId { get; set; }

        [ForeignKey("Question")]
        public Guid QuestionId { get; set; }

        [ForeignKey("Answer")]
        public Guid AnswerId { get; set; }
        public  Interview Interview { get; set; }
        public  Question Question { get; set; }
        public  Answer Answer { get; set; }
    }
}
