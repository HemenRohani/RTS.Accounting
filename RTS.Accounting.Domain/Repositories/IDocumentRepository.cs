using RTS.Accounting.Domain.Entities;

namespace RTS.Accounting.Domain.Repositories
{
    public interface IDocumentRepository
    {
        Task<BaseDocument> GetAsync(int id);
    }
}
