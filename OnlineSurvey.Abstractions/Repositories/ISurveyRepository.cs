using OnlineSurvey.Abstractions.Repositories.Base;
using OnlineSurvey.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurvey.Abstractions.Repositories
{
    public interface ISurveyRepository:IBaseRepository<Survey>
    {
    }
}
