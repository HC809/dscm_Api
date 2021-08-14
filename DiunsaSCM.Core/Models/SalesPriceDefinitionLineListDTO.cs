using System;
using System.Collections.Generic;

namespace DiunsaSCM.Core.Models
{
    public class SalesPriceDefinitionLineListDTO
    {
        public long SalesPriceDefinitionId { get; set; }

        public IEnumerable<SalesPriceDefinitionLineDTO> SalesPriceDefinitionLineList { get; set; }

    }
}
