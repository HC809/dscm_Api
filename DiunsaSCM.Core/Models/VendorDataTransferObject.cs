using System;
using System.Collections.Generic;
using System.Text;
using DiunsaSCM.Core.Enums;

namespace DiunsaSCM.Core.Models
{
    public class VendorDTO : AuditableModel
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool AllowPurchOrderShipments { get; set; }
        public bool SinglePurchOrderShipment { get; set; }

        public string SearchText { get { return Code + " - " + Description; } }

        public VendorType VendorType { get; set; }
        public string VendorTypeDescription { get; set; }

        public string NameAlias { get; set; }
        public string ContactName { get; set; }
        public string Address { get; set; }
        public string FiscalCode { get; set; }
        public string Email { get; set; }
        public string TelephoneNumber { get; set; }
        public string CellphoneNumer { get; set; }

        public long? CountryId { get; set; }
        public long? IncotermId { get; set; }
        public long? CurrencyId { get; set; }
        public long? PurchPaymentConditionId { get; set; }
        public long? WarehouseId { get; set; }
        public long? PurchCommercialDepartmentId { get; set; }
        public long? TaxItemGroupHeadingId { get; set; }
    }
}
