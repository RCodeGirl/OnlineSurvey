using OnlineSurvey.Domain.Entities;
using OnlineSurvey.Shared.Dto;
using Riok.Mapperly.Abstractions;


namespace OnlineSurvey.Infrastructure.Mappers
{
    [Mapper]
    public static partial class ResultMappersRegister
    {
        public static partial Result Map(this ResultDto src);
        public static partial List<Result> Map(this List<ResultDto> src);
        public static partial ResultDto Map(this Result src);
        public static partial List<ResultDto> Map(this List<Result> src);
    }
}
