using System;
namespace DiunsaSCM.Core.Models
{
    public class FilterPurchOrderShipmentDTO : FilterBaseDTO
    {
        public string Slice { get; set; }
        public string Code { get; set; }
        public string PurchId { get; set; }
        public string VendorAccount { get; set; }
        public string PurchName { get; set; }
        public string BLNumber { get; set; }
        public string ShippingCompanyName { get; set; }
        public string InvoiceNumber { get; set; }
        public string Username { get; set; }
        public string Barcode { get; set; }
        public string ContainerNumber { get; set; }
    }
}
