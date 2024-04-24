using RTS.Accounting.Application;
using RTS.Accounting.Domain.Entities;
using RTS.Accounting.Domain.Repositories;

namespace RTS.Accounting.Infrastructure.Repositories
{
    public class DocumentRepository(AppDbContext appDbContext)
        : GenericRepository<BaseDocument>(appDbContext), IDocumentRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext;
    }
}
