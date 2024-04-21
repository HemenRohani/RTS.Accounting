using RTS.Accounting.Application;
using RTS.Accounting.Application.Interfaces;

namespace RTS.Accounting.Infrastructure.Repositories
{
    public class UnitOfWork(AppDbContext appDbContext) : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext = appDbContext;
        public async Task<int> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync();
        }
    }
}
