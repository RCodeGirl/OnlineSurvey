using Microsoft.EntityFrameworkCore;
using OnlineSurvey.Abstractions.Repositories.Base;
using OnlineSurvey.Domain.Entities.Base;
using System.Linq.Expressions;


namespace OnlineSurvey.Persistence.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly OnlineSurveyDbContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(OnlineSurveyDbContext context )
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public  IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return  _dbSet.Where(predicate);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);

            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
