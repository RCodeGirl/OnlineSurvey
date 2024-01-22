using OnlineSurvey.Abstractions.Repositories;
using OnlineSurvey.Abstractions.Services;
using OnlineSurvey.Infrastructure.Mappers;
using OnlineSurvey.Shared.Dto;


namespace OnlineSurvey.Infrastructure.Service
{
    public  class ResultService:IResultService
    {
        private IResultRepository _resultRepository;
        public ResultService(IResultRepository resultRepository)
        {
            _resultRepository = resultRepository;
        }
        public async Task<Guid> Create (ResultDto resultDto)
       {
            var entity = resultDto.Map();
            await _resultRepository.AddAsync(entity);
            await _resultRepository.SaveChangesAsync();
            return entity.Id;
        }
    }
}
