using System;
using System.Collections.Generic;

namespace DiunsaSCM.Core.Models
{
    public class ImportInventTableHeaderDTO
    {
        public long Id { get; set; }
        public string ImportInventTableId { get; set; }
        public int ImportInventTableStatus { get; set; }
        public int ImportInventTableType { get; set; }
        public string Descripcion { get; set; }
        public long PurchQuotationId { get; set; }

        public IEnumerable<ImportInventTableLineDataTransferObject> ImportInventTableLines { get; set; }
    }
}
