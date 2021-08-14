using System;
namespace DiunsaSCM.Core.Models
{
    public class ShipmentContainerTypeDataTransferObject : AuditableModel
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public decimal CubicCapacity { get; set; }
        public decimal LoadCapacity { get; set; }

        public ShipmentContainerTypeDataTransferObject()
        {
        }
    }
}
