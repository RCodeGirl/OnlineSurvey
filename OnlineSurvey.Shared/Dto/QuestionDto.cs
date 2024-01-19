using System;

namespace OnlineSurvey.Shared.Dto
{
    public class QuestionDto
    {
        public required string Title { get; set; }   

        public  List<AnswerDto> Answers { get; set; } 

      
    }
}
