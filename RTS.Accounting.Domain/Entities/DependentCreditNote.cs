namespace RTS.Accounting.Domain.Entities
{
    public class DependentCreditNote : BaseDocument
    {
        /// not empty and  < 0
        public long TotalAmount { get; set; }
    }
}
