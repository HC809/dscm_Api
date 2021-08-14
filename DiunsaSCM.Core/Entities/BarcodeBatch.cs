using System;
using System.Collections.Generic;

namespace DiunsaSCM.Core.Entities
{
    public class BarcodeBatch : AuditableEntity
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public int QtyRequested { get; set; }
        public int QtyGenerated { get; set; }

        public virtual List<Barcode> Barcodes { get; set; }
    }
}
