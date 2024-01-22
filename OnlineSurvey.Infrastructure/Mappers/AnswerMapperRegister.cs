using OnlineSurvey.Domain.Entities;
using OnlineSurvey.Shared.Dto;
using Riok.Mapperly.Abstractions;

namespace OnlineSurvey.Infrastructure.Mappers
{
    [Mapper]
    public static partial class AnswerMapperRegister
    {
        public static partial Answer Map(this AnswerDto src);
        public static partial List<Answer> Map(this List<AnswerDto> src);
        public static partial AnswerDto Map(this Answer src);
        public static partial List<AnswerDto> Map(this List<Answer> src);
    }
}
