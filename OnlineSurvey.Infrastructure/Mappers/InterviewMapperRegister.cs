using OnlineSurvey.Domain.Entities;
using OnlineSurvey.Shared.Dto;
using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurvey.Infrastructure.Mappers
{
    [Mapper]
    public static partial class InterviewMapperRegister
    {
        public static partial Interview Map(this InterviewDto src);
        public static partial List<Interview> Map(this List<InterviewDto> src);
        public static partial InterviewDto Map(this Interview src);
        public static partial List<InterviewDto> Map(this List<Interview> src);
    }
}
