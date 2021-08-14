using System;
using DiunsaSCM.Core.Entities;
namespace DiunsaSCM.Core.Models
{
    public class PurchCostDefinitionDTO
    {
        public long Id { get; set; }
        public string Code { get; set; }
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
    }
}