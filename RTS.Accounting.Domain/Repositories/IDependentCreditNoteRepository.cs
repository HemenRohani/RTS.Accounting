using RTS.Accounting.Domain.Entities;

namespace RTS.Accounting.Domain.Repositories
{
    public interface IDependentCreditNoteRepository
    {
        void Add(DependentCreditNote entity);
    }
}
