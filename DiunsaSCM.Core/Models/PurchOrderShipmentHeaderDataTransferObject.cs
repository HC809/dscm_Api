using System;
namespace DiunsaSCM.Core.Models
{
    public class PurchOrderShipmentHeaderDataTransferObject : AuditableModel
    {
        public long Id { get; set; }
        public long PurchOrderHeaderId { get; set; }
        public string PurchId { get; set; }
        public string PurchName { get; set; }
        public long? ShippingRouteId { get; set; }
        public long? PreparationShippingRouteId { get; set; }

        public string ShippingRouteDescription { get; set; }
        public string PreparationShippingRouteDescription { get; set; }

        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ShipmentDateRequested { get; set; }
        public DateTime ShipmentDateConfirmed { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime ReceiptDateConfirmed { get; set; }
        public long? ShippingCompanyId { get; set; }
        public string ShippingCompanyName { get; set; }
        public long? IncotermId { get; set; }
        public string IncotermCode { get; set; }
        public long? ShipmentImportId { get; set; }
        public string BLNumber { get; set; }
        public decimal EstimatedVolume { get; set; }
        public decimal EstimatedWeight { get; set; }
        public decimal TotalVolume { get; set; }
        public decimal TotalWeight { get; set; }
        public decimal EstimatedContainerQty { get; set; }
        public string InvoiceNumber { get; set; }

        public long? CurrentShippingRouteId { get; set; }
        public long? CurrentShippingRouteStepId { get; set; }
        public string CurrentShippingRouteStepDescription { get; set; }

        public string Code { get; set; }
        public string CompleteCode { get; set; }

        public long? ShipmentTypeId { get; set; }
        public string ShipmentTypeDescription { get; set; }
        public long? CommercialEventId { get; set; }
        public string CommercialEventDescription { get; set; }

        public PurchOrderShipmentHeaderDataTransferObject()
        {
        }
    }
}
