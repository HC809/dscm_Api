using System;
using DiunsaSCM.Core.Entities;
namespace DiunsaSCM.Core.Models
{
    public class PurchOrderShipmentCrossDockingDTO
    {
        public long Id { get; set; }
        public decimal Qty { get; set; }

        public long ShipmentContainerDetailId { get; set; }

        public long StoreId { get; set; }
        public string StoreCode { get; set; }
        public string StoreDescription { get; set; }

        public long ShipmentContainerId { get; set; }
        public long PurchOrderDetailId { get; set; }
        public decimal QtyOnContainer { get; set; }
        public string PurchId { get; set; }
        public string BLNumber { get; set; }
        public string ContainerNumber { get; set; }
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public string NameAlias { get; set; }
        public string Barcode { get; set; }
        public string InventSizeId { get; set; }
        public string InventColorId { get; set; }
    }
}