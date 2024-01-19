using OnlineSurvey.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurvey.Domain.Entities
{
    public class Interview: BaseEntity
    {
        [Required]
        [ForeignKey("Survey")]
        public int SurveyId { get; set; }

        public DateTime InterviewDate { get; set; }

        public  Survey Survey { get; set; }

        public  List<Result> Results { get; set; }
    }
}
