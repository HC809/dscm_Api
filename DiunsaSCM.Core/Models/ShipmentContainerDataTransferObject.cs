using System;
namespace DiunsaSCM.Core.Models
{
    public class ShipmentContainerDataTransferObject : AuditableModel
    {
        public long Id { get; set; }
        public long PurchOrderShipmentHeaderId { get; set; }
        public string BLNumber { get; set; }
        public string PurchId { get; set; }
        public string Description { get; set; }
        public long ShipmentContainerTypeId { get; set; }
        public string ShipmentContainerTypeDescription { get; set; }
        public string ContainerNumber { get; set; }
        public decimal Weight { get; set; }
        public decimal Volume { get; set; }

        public DateTime EstimatedGateUnloadDate { get; set; }
        public DateTime RealGateUnloadDate { get; set; }
        public DateTime ToShippingCompanyNotificationDate { get; set; }
        public DateTime EquipmentPickupDate { get; set; }
        public DateTime FreeTimeBoxLimitDate { get; set; }
        public DateTime FreeTimeChassisLimitDate { get; set; }

        public ShipmentContainerDataTransferObject()
        {
        }
    }
}
