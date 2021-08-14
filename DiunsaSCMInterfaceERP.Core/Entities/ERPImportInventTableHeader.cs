using System;
using System.Collections.Generic;
using System.Text;

namespace DiunsaSCMInterfaceERP.Core.Entities
{
    public class ERPImportInventTableHeader
    {
        public long Id { get; set; }
        public string ImportInventTableId { get; set; }
        public int ImportInventTableStatus { get; set; }
        public int ImportInventTableType { get; set; }
        public string Descripcion { get; set; }
        public string PurchId { get; set; }

        public IEnumerable<ERPImportInventTableLine> ERPImportInventTableLines { get; set; }
    }
}
