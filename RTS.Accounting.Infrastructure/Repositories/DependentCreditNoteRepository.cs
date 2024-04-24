using RTS.Accounting.Domain.Entities;
using RTS.Accounting.Domain.Repositories;

namespace RTS.Accounting.Infrastructure.Repositories
{
    public class DependentCreditNoteRepository(AppDbContext appDbContext)
        : GenericRepository<BaseDocument>(appDbContext), IDependentCreditNoteRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext;

        public void Add(DependentCreditNote entity)
        {
            _appDbContext.Add(entity);
        }
    }
}
