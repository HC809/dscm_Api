namespace DiunsaSCM.Core.Models
{
    public class TaxItemGroupHeadingDTO : AuditableModel
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}