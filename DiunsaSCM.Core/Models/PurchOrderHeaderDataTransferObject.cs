using System;
namespace DiunsaSCM.Core.Models
{
    public class PurchOrderHeaderDTO : AuditableModel
    {
        public long Id { get; set; }
        public string PurchId { get; set; }
        public string VendorAccount { get; set; }
        public int PurchStatus { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime CreatedDatetime { get; set; }
        public string PurchName { get; set; }
        public string Reference { get; set; }
        public string PurchPaymentConditionCode { get; set; }
        public string WarehouseCode { get; set; }
        public string WarehouseDescription { get; set; }
        public DateTime ShipmentDateRequested { get; set; }
        public DateTime ShipmentDateConfirmed { get; set; }
        public DateTime DeliveryDate { get; set; }

        public PurchOrderHeaderDTO()
        {
        }
    }
}
