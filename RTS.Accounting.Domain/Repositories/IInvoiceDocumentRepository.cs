using RTS.Accounting.Domain.Entities;

namespace RTS.Accounting.Domain.Repositories
{
    public interface IInvoiceDocumentRepository
    {
        void Add(InvoiceDocument entity);
    }
}
