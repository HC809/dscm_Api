using System;
using System.Collections.Generic;

namespace DiunsaSCM.Core.Entities
{
    public class PurchCostDefinition : AuditableEntity
    {
        public long Id { get; set; }
        private string _code;
        public string Code { get => _code; set => _code = value == "" ? null : value; }
        public string Description { get; set; }
        public string Reference { get; set; }
        public string InvoiceNumber { get; set; }
        public string VendorCode { get; set; }
        public string VendorDescription { get; set; }
        public DateTime Date { get; set; }
        public string AgentCode { get; set; }
        public string ImportPolicyCode { get; set; }
        public string ShipmentImportCode { get; set; }
        public string ShippingCompanyCode { get; set; }
        public decimal ExchangeRate { get; set; }

        public virtual IEnumerable<PurchCostDefinitionLine> PurchCostDefinitionLines { get; set; }
    }
}
