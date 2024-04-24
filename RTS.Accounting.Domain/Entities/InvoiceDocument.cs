using System.ComponentModel.DataAnnotations.Schema;

namespace RTS.Accounting.Domain.Entities
{
    public class InvoiceDocument : BaseDocument
    {
        public ICollection<DependentCreditNote> CreditNotes { get; set; }
    }
}
