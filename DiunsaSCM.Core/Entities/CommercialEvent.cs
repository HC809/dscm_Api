namespace DiunsaSCM.Core.Entities
{
    public class CommercialEvent : AuditableEntity
    {
        public long Id { get; set; }
        public string Description { get; set; }
    }
}