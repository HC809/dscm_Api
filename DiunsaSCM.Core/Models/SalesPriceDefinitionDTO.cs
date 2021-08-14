using System;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Enums;

namespace DiunsaSCM.Core.Models
{
    public class SalesPriceDefinitionDTO
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Reference { get; set; }

        public SalesPriceDefinitionStatus SalesPriceDefinitionStatus { get; set; }
        public string SalesPriceDefinitionStatusDescription { get; set; }
    }
}