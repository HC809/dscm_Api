using System;
using System.Collections.Generic;
using DiunsaSCM.Core.Enums;

namespace DiunsaSCM.Core.Entities
{
    public class SalesPriceDefinition
    {
        public long Id { get; set; }
        private string _code;
        public string Code { get => _code; set => _code = value == "" ? null : value; }
        public string Description { get; set; }
        public string Reference { get; set; }

        public SalesPriceDefinitionStatus SalesPriceDefinitionStatus { get; set; }

        public virtual IEnumerable<SalesPriceDefinitionLine> SalesPriceDefinitionLines { get; set; }
        
    }
}
