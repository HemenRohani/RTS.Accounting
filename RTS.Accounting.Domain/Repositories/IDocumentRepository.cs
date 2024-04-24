using RTS.Accounting.Domain.Entities;

namespace RTS.Accounting.Domain.Repositories
{
    public interface IDocumentRepository
    {
        void Remove(BaseDocument entity);
        Task<BaseDocument> GetAsync(int id, CancellationToken cancellationToken);
        Task<List<BaseDocument>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
