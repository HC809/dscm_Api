using System;
namespace DiunsaSCM.Core.Models
{
    public class PurchOrderShipmentDetailDataTransferObject : AuditableModel
    {
        public long Id { get; set; }
        public long PurchOrderShipmentHeaderId { get; set; }
        public long PurchOrderDetailId { get; set; }
        public decimal QtyOnShipment { get; set; }
        public decimal QtyOnShipmentContainers { get; set; }
        public string PurchId { get; set; }
        public string BLNumber { get; set; }
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public string NameAlias { get; set; }
        public string Barcode { get; set; }
        public string InventSizeId { get; set; }
        public string InventColorId { get; set; }
        public string PurchUnit { get; set; }
        public decimal QtyOrdered { get; set; }
        public decimal QtyOnReceipt { get; set; }

        public PurchOrderShipmentDetailDataTransferObject()
        {
        }
    }
}
