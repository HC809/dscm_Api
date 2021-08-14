using System;
namespace DiunsaSCM.Core.Models
{
    public class ShipmentLogEntryDataTransferObject : AuditableModel
    {
        public long Id { get; set; }
        public long PurchOrderShipmentHeaderId { get; set; }
        public long ShippingRouteStepId { get; set; }
        public string LogText { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateCreated { get; set; }
        public string ShippingRouteStepDescription { get; set; }
        public bool? Completed { get; set; }

        public ShipmentLogEntryDataTransferObject()
        {
        }
    }
}
