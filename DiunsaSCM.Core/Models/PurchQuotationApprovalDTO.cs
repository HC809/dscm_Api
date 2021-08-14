namespace DiunsaSCM.Core.Models
{
    public class PurchQuotationApprovalDTO : AuditableModel
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}