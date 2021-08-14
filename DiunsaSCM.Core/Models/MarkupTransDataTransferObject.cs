using System;
namespace DiunsaSCM.Core.Models
{
    public class MarkupTransDataTransferObject : AuditableModel
    {
        public long ERPRecId { get; set; }
        public long ERPTransRecId { get; set; }
        public string BLNumber { get; set; }
        public string CurrencyCode { get; set; }
        public decimal Value { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal Posted { get; set; }
        public string Voucher { get; set; }
        public string Description { get; set; }
        public DateTime TransDate { get; set; }

        public MarkupTransDataTransferObject()
        {
        }
    }
}
