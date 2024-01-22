using OnlineSurvey.Domain.Entities;
using OnlineSurvey.Shared.Dto;
using Riok.Mapperly.Abstractions;


namespace OnlineSurvey.Infrastructure.Mappers
{
    [Mapper]
    public static partial class SurveyMapperRegister
    {
        public static partial Survey Map(this SurveyDto src);
        public static partial List<Survey> Map(this List<SurveyDto> src);
        public static partial SurveyDto Map(this Survey src);
        public static partial List<SurveyDto> Map(this List<Survey> src);
    }
}
