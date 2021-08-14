namespace DiunsaSCM.Core.Models
{
    public class CommercialEventDTO : AuditableModel
    {
        public long Id { get; set; }
        public string Description { get; set; }
    }
}