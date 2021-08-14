using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DiunsaSCM.Core.Entities
{
    public class ShipmentImport : AuditableEntity
    {
        public long Id { get; set; }
        public long ERPRecId { get; set; }
        public long? ShippingRouteId { get; set; }
        public long? CurrentShippingRouteStepId { get; set; }
        public long? ShippingCompanyId { get; set; }

        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ShipmentDateRequested { get; set; }
        public DateTime ShipmentDateConfirmed { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime ReceiptDateConfirmed { get; set; }
        public string BLNumber { get; set; }
        public decimal EstimatedVolume { get; set; }
        public decimal EstimatedWeight { get; set; }
        public string Incoterm { get; set; }
        public int Status { get; set; }

        public virtual ShippingCompany ShippingCompany { get; set; }
        public virtual ShippingRoute ShippingRoute { get; set; }
        [ForeignKey("CurrentShippingRouteStepId")]
        public virtual ShippingRouteStep ShippingRouteStep { get; set; }

        public virtual IEnumerable<PurchOrderShipmentHeader> PurchOrderShipmentHeaders { get; set; }

        public decimal GetTotalVolume()
        {
            return 0;
            /*if (ShipmentContainers == null)
                return 0;
            return ShipmentContainers.Sum(x => x.Volume);*/
        }

        public decimal GetTotalWeight()
        {
            return 0;
            /*if (ShipmentContainers == null)
                return 0;
            return ShipmentContainers.Sum(x => x.Weight);*/
        }

        public string GetShippingCompanyName()
        {
            if (ShippingCompany != null)
                return ShippingCompany.Name;
            else
                return "";
        }

        public string GetShippingRouteDescription()
        {
            if (ShippingRoute == null)
                return "";
            return ShippingRoute.Description;
        }
        public string GetCurrentShippingRouteStepDescription()
        {
            if (ShippingRouteStep == null)
                return "";
            return ShippingRouteStep.ShippingStepType.Description;
        }

        public ShipmentImport()
        {
        }
    }
}
