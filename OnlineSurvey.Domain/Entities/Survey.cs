using OnlineSurvey.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurvey.Domain.Entities
{
    /// <summary>
    /// Information about the questionnaire 
    /// </summary>
    public class Survey: BaseEntity
    {
        [MaxLength(256)]
        public required string Title {  get; set; }

        public string? Description { get; set; }

        public List<Question> Question { get; set; }
        public List<Interview> Interviews { get; set; }

    }
}
