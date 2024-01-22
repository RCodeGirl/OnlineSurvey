using OnlineSurvey.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurvey.Abstractions.Services
{
    public interface IResultService
    {
        Task<Guid> Create(ResultDto resultDto);
    }
}
