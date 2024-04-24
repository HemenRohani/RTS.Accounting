using Microsoft.EntityFrameworkCore;
using RTS.Accounting.Domain.Entities;
using RTS.Accounting.Domain.Enums;
using RTS.Accounting.Domain.Repositories;

namespace RTS.Accounting.Infrastructure.Repositories
{
    public class DocumentRepository(AppDbContext appDbContext)
        : GenericRepository<BaseDocument>(appDbContext), IDocumentRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext;

        public async Task<List<BaseDocument>> GetAllAsync(DocumentType? type, CancellationToken cancellationToken = default)
        {
            var query = _appDbContext.Set<BaseDocument>().AsQueryable();
            if (type.HasValue)
                query = query.Where(x => x.Type == type.Value).AsNoTracking();

            return await query.ToListAsync(cancellationToken);
        }
    }
}
