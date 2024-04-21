using RTS.Accounting.Domain.Entities;

namespace RTS.Accounting.Domain.Repositories
{
    public interface IDocumentRepository
    {
        void Add(Document document);
        Task<Document> GetAsync(int id);
    }
}
