using System;
using System.Collections.Generic;
using System.Text;
using DiunsaSCM.Core.Enums;

namespace DiunsaSCM.Core.Entities
{
    public class Vendor : AuditableEntity
    {
        public long Id { get; set; }
        public long ERPRecId { get; set; }
        private string _code;
        public string Code { get => _code; set => _code = value == "" ? null : value; }
        public string Description { get; set; }
        public bool AllowPurchOrderShipments { get; set; }
        public bool SinglePurchOrderShipment { get; set; }
        public VendorType VendorType { get; set; }

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

        public virtual Country Country { get; set; }
        public virtual Incoterm Incoterm { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual PurchPaymentCondition PurchPaymentCondition { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        public virtual PurchCommercialDepartment PurchCommercialDepartment { get; set; }
        public virtual TaxItemGroupHeading TaxItemGroupHeading { get; set; }
    }
}
