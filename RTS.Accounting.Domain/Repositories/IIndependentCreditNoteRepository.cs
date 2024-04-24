using RTS.Accounting.Domain.Entities;

namespace RTS.Accounting.Domain.Repositories
{
    public interface IIndependentCreditNoteRepository
    {
        void Add(IndependentCreditNote entity);
    }
}
