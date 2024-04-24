using RTS.Accounting.Domain.Entities;
using RTS.Accounting.Domain.Repositories;

namespace RTS.Accounting.Infrastructure.Repositories
{
    public class IndependentCreditNoteRepository(AppDbContext appDbContext)
        : GenericRepository<BaseDocument>(appDbContext), IIndependentCreditNoteRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext;

        public void Add(IndependentCreditNote entity)
        {
            _appDbContext.Add(entity);
        }
    }
}
