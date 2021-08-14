using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DiunsaSCM.Core.Entities
{
    public class PurchOrderDetail : AuditableEntity
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
        private decimal _lineAmount { get; set; }
        public decimal LineAmount { get => QtyOrdered * PurchPrice; set => _lineAmount = QtyOrdered * PurchPrice; }

        public virtual IEnumerable<PurchOrderShipmentDetail> PurchOrderShipmentDetails { get; set; }
        public virtual IEnumerable<ShipmentContainerDetail> ShipmentContainerDetails { get; set; }
        public virtual PurchOrderHeader PurchOrderHeader { get; set; }

        public decimal GetQtyOnShipments()
        {
            if (ShipmentContainerDetails == null)
                return 0;
            return PurchOrderShipmentDetails.Sum(x => x.QtyOnShipment);
        }

        public decimal GetQtyOnContainers()
        {
            if (ShipmentContainerDetails == null)
                return 0;
            return ShipmentContainerDetails.Sum(x => x.QtyOnContainer);
        }

    }
}
