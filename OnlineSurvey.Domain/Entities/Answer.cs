﻿using OnlineSurvey.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;


namespace OnlineSurvey.Domain.Entities
{
    /// <summary>
    /// answer option to the survey question.
    /// </summary>
    public class Answer : BaseEntity
    {
        public required string Title { get; set; }
        public Guid QuestionId { get; set; }
        public Question Question { get; set; }
        
    }
}
