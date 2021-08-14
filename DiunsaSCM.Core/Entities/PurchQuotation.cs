using System;
using System.Collections.Generic;
using DiunsaSCM.Core.Enums;

namespace DiunsaSCM.Core.Entities
{
    public class PurchQuotation : AuditableEntity
    {
        public long Id { get; set; }
        private string _code;
        public string Code { get => _code; set => _code = value == "" ? null : value; }
        public string Description { get; set; }
        public PurchQuotationStatus PurchQuotationStatus { get; set; }
        public DateTime ShipmentDateRequested { get; set; }
        public DateTime ShipmentDateConfirmed { get; set; }
        public DateTime DeliveryDate { get; set; }

        public long? VendorId { get; set; }
        public long? CurrencyId { get; set; }
        public long? PurchPaymentConditionId { get; set; }
        public long? PurchOrderHeaderId { get; set; }
        public long? WarehouseId { get; set; }
        public long? PurchCommercialDepartmentId { get; set; }
        public long? PurchQuotationApprovalRuleConditionId { get; set; }
        public long? PurchQuotationApprovalRuleConditionStepId { get; set; }

        public virtual Vendor Vendor { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual PurchPaymentCondition PurchPaymentCondition { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        public virtual PurchCommercialDepartment PurchCommercialDepartment { get; set; }

        public virtual IEnumerable<PurchQuotationLine> PurchQuotationLines { get; set; }
        public virtual PurchOrderHeader PurchOrderHeader { get; set; }
        public virtual PurchQuotationApprovalRuleCondition PurchQuotationApprovalRuleCondition { get; set; }
        public virtual PurchQuotationApprovalRuleConditionStep PurchQuotationApprovalRuleConditionStep { get; set; }
    }
}