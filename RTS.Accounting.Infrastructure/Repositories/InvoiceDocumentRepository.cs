using RTS.Accounting.Domain.Entities;
using RTS.Accounting.Domain.Repositories;

namespace RTS.Accounting.Infrastructure.Repositories
{
    public class InvoiceDocumentRepository(AppDbContext appDbContext)
        : GenericRepository<BaseDocument>(appDbContext), IInvoiceDocumentRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext;

        public void Add(InvoiceDocument entity)
        {
            _appDbContext.Add(entity);
        }
    }
}
