namespace DiunsaSCM.Core.Models
{
    public class TaxOnItemDTO : AuditableModel
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public long TaxItemGroupHeadingId { get; set; }
    }
}