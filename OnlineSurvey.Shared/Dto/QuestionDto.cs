using OnlineSurvey.Shared.Dto.Base;
using System;

namespace OnlineSurvey.Shared.Dto
{
    public class QuestionDto: BaseDto
    {
        public required string Title { get; set; }   

        public  List<AnswerDto> Answers { get; set; } 

      
    }
}
