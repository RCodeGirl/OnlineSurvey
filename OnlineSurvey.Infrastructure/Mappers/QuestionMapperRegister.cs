using OnlineSurvey.Domain.Entities;
using OnlineSurvey.Shared.Dto;
using Riok.Mapperly.Abstractions;


namespace OnlineSurvey.Infrastructure.Mappers
{
    [Mapper]
    public static partial class QuestionMapperRegister
    {
        public static partial Question Map(this QuestionDto src);
        public static partial List<Question> Map(this List<QuestionDto> src);

        public static partial QuestionDto Map(this  Question src);
        public static partial List<QuestionDto> Map(this List<Question> src);

    }
}
