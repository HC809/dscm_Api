using System;
namespace DiunsaSCM.Core.Entities
{
    public class PurchOrderShipmentRouteStepSuscription : AuditableEntity
    {
        public long Id { get; set; }

        public long PurchOrderShipmentHeaderId { get; set; }
        public long ShippingRouteStepId { get; set; }
        public string Username { get; set; }

        public virtual PurchOrderShipmentHeader PurchOrderShipmentHeader { get; set; }
        public virtual ShippingRouteStep ShippingRouteStep { get; set; }

        public PurchOrderShipmentRouteStepSuscription()
        {
        }
    }
}
