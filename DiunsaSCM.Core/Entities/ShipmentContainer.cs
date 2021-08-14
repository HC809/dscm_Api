using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiunsaSCM.Core.Entities
{
    public class ShipmentContainer : AuditableEntity
    {
        public long Id { get; set; }
        public long PurchOrderShipmentHeaderId { get; set; }
        public string Description { get; set; }
        public long ShipmentContainerTypeId { get; set; }
        public string ContainerNumber { get; set; }
        public decimal Weight { get; set; }
        public decimal Volume { get; set; }

        public DateTime EstimatedGateUnloadDate { get; set; }
        public DateTime RealGateUnloadDate { get; set; }
        public DateTime ToShippingCompanyNotificationDate { get; set; }
        public DateTime EquipmentPickupDate { get; set; }
        public DateTime FreeTimeBoxLimitDate { get; set; }
        public DateTime FreeTimeChassisLimitDate { get; set; }

        public virtual PurchOrderShipmentHeader PurchOrderShipmentHeader { get; set; }
        public virtual ShipmentContainerType ShipmentContainerType { get; set; }
        public virtual IEnumerable<ShipmentContainerDetail> ShipmentContainerLines { get; set; }

        public ShipmentContainer()
        {

        }

        public string GetShipmentContainerTypeDescription()
        {
            if (ShipmentContainerType != null)
                return ShipmentContainerType.Description;
            else
                return "";
        }
    }
}
