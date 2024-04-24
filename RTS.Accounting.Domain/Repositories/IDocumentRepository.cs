using RTS.Accounting.Domain.Entities;
using RTS.Accounting.Domain.Enums;

namespace RTS.Accounting.Domain.Repositories
{
    public interface IDocumentRepository
    {
        void Remove(BaseDocument entity);
        Task<BaseDocument> GetAsync(int id, CancellationToken cancellationToken);
        Task<List<BaseDocument>> GetAllAsync(DocumentType? type, CancellationToken cancellationToken = default);
    }
}
