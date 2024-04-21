using Microsoft.EntityFrameworkCore;
using RTS.Accounting.Application;
using RTS.Accounting.Domain.Common;

namespace RTS.Accounting.Infrastructure.Repositories
{
    public class GenericRepository<TEntity>(AppDbContext appDbContext) where TEntity : BaseEntity
    {
        private readonly AppDbContext _appDbContext = appDbContext; 

        public void Add(TEntity entity)
        {
            _appDbContext.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _appDbContext.Update(entity);

            //_appDbContext.Attach(entity);
            //_appDbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(TEntity entity)
        {
            _appDbContext.Remove(entity);
        }

        public async Task<TEntity> GetAsync(int id)
        {
            return await _appDbContext.FindAsync<TEntity>(id);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _appDbContext.Set<TEntity>().ToListAsync();
        }
    }
}
