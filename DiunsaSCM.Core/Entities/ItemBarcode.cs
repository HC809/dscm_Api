using System;
using System.Collections.Generic;
using System.Text;

namespace DiunsaSCM.Core.Entities
{
    public class ItemBarcode : AuditableEntity
    {
        public long Id { get; set; }
        public string Barcode { get; set; }
        public string ERPVariantCode { get; set; }

        public long InventItemId { get; set; }
        public long? InventDimId { get; set; }

        public virtual InventItem InventItem { get; set; }
        public virtual InventDim InventDim { get; set; }
    }
}
