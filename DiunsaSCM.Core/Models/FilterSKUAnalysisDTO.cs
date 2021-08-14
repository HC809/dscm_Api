using System;
using System.Collections.Generic;

namespace DiunsaSCM.Core.Models
{
    public class FilterSKUAnalysisDTO : FilterBaseDTO
    {
        public IEnumerable<string> Barcodes { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
