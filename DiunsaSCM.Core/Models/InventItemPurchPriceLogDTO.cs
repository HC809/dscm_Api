using System;
using DiunsaSCM.Core.Entities;
namespace DiunsaSCM.Core.Models
{
    public class InventItemPurchPriceLogDTO
    {
        public long Id { get; set; }
        public decimal PurchPrice { get; set; }

        public long InventItemId { get; set; }

        public long PurchQuotationLineId { get; set; }
        public string PurchQuotationCode { get; set; }
    }
}