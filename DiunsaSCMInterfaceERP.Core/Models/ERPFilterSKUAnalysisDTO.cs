using System;
using System.Collections.Generic;

namespace DiunsaSCMInterfaceERP.Core.Models
{
    public class ERPFilterSKUAnalysisDTO : ERPFilterBaseDTO
    {
        public IEnumerable<string> Barcodes { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
