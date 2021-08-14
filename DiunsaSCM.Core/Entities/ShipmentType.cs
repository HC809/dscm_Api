namespace DiunsaSCM.Core.Entities
{
    public class ShipmentType : AuditableEntity
    {
        public long Id { get; set; }
        public string Description { get; set; }
    }
}