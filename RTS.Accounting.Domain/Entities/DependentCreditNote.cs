namespace RTS.Accounting.Domain.Entities
{
    public class DependentCreditNote : BaseDocument
    {
        public int ParentInvoiceId { get; set; }
        public InvoiceDocument ParentInvoice { get; set; }
    }
}
