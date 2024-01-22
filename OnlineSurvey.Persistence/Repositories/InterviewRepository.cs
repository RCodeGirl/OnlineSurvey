using OnlineSurvey.Abstractions.Repositories;
using OnlineSurvey.Domain.Entities;
using OnlineSurvey.Persistence.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurvey.Persistence.Repositories
{
    public class InterviewRepository: BaseRepository<Interview>, IInterviewRepository
    {
        public InterviewRepository(OnlineSurveyDbContext context) : base(context)
        {

        }
    }
}
