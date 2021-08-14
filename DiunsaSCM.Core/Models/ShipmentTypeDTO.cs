namespace DiunsaSCM.Core.Models
{
    public class ShipmentTypeDTO : AuditableModel
    {
        public long Id { get; set; }
        public string Description { get; set; }
    }
}