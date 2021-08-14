using System;
using System.Collections.Generic;

namespace DiunsaSCM.Core.Models
{
    public class PurchCostDefinitionLineListDTO
    {
        public long PurchCostDefinitionId { get; set; }

        public IEnumerable<PurchCostDefinitionLineDTO> PurchCostDefinitionLineList { get; set; }
    }
}
