using OnlineSurvey.Shared.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurvey.Shared.Dto
{
    public class ResultDto:BaseDto
    {
        public Guid InterviewId { get; set; }      

        public Guid QuestionId { get; set; }  

        public Guid AnswerId { get; set; }
    
    }
}
