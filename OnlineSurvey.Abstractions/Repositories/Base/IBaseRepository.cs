using OnlineSurvey.Domain.Entities.Base;
using System.Linq.Expressions;


namespace OnlineSurvey.Abstractions.Repositories.Base
{
    public interface IBaseRepository <T> where T:BaseEntity
    {
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate);
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
        Task<T> AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveChangesAsync();
    }
}
