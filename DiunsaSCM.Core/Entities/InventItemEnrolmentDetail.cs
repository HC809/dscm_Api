using System;
namespace DiunsaSCM.Core.Entities
{
    public class InventItemEnrolmentDetail : AuditableEntity
    {
        public long Id { get; set; }

        public long InventItemEnrolmentId { get; set; }
        public long InventItemId { get; set; }
        public long? InventDimId { get; set; }
        public long? ItemBarcodeId { get; set; }

        public virtual InventItemEnrolment InventItemEnrolment { get; set; }
        public virtual InventItem InventItem { get; set; }
        public virtual InventDim InventDim { get; set; }
        public virtual ItemBarcode ItemBarcode { get; set; }

    }
}
