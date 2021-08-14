using System;
namespace DiunsaSCM.Core.Entities
{
    public class ShipmentLogEntry : AuditableEntity
    {
        public long Id { get; set; }
        public long PurchOrderShipmentHeaderId { get; set; }
        public long ShippingRouteStepId { get; set; }
        public string LogText { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual PurchOrderShipmentHeader PurchOrderShipmentHeader { get; set; }
        public virtual ShippingRouteStep ShippingRouteStep { get; set; }
        public bool? Completed { get; set; }

        public ShipmentLogEntry()
        {
        }
    }
}
