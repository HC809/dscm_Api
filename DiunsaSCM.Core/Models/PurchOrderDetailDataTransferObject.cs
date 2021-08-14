using System;
namespace DiunsaSCM.Core.Models
{
    public class PurchOrderDetailDTO : AuditableModel
    {
        public long Id { get; set; }
        public long PurchOrderHeaderId { get; set; }
        public string PurchId { get; set; }
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public string NameAlias { get; set; }
        public string Barcode { get; set; }
        public string InventSizeId { get; set; }
        public string InventColorId { get; set; }
        public decimal QtyOrdered { get; set; }
        public string PurchUnit { get; set; }
        public decimal PurchPrice { get; set; }
        public decimal LineAmount { get; set; }
        public decimal QtyOnShipments { get; set; }
        public decimal QtyOnContainers { get; set; }
        public object QtyOnReceipt { get; set; }

        public PurchOrderDetailDTO()
        {
        }
    }
}
