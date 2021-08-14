using System;
namespace DiunsaSCMInterfaceERP.Core.Entities
{
    public class ERPPurchOrderHeader
    {
        public long Id { get; set; }
        public string PurchId { get; set; }
        public string VendorAccount { get; set; }
        public int PurchStatus { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime CreatedDatetime { get; set; }
        public string PurchName { get; set; }

        public ERPPurchOrderHeader()
        {
        }
    }
}
