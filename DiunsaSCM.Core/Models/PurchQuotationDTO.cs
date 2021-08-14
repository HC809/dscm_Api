using System;
using DiunsaSCM.Core.Enums;

namespace DiunsaSCM.Core.Models
{
    public class PurchQuotationDTO : AuditableModel
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public PurchQuotationStatus purchQuotationStatus { get; set; }

        public long? VendorId { get; set; }
        public string VendorCode { get; set; }
        public string VendorDescription { get; set; }

        public long? CurrencyId { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyDescription { get; set; }

        public long? WarehouseId { get; set; }
        public string WarehouseCode { get; set; }
        public string WarehouseDescription { get; set; }

        public long? PurchPaymentConditionId { get; set; }
        public string PurchPaymentConditionCode { get; set; }
        public string PurchPaymentConditionDescription { get; set; }
        public DateTime ShipmentDateRequested { get; set; }
        public DateTime ShipmentDateConfirmed { get; set; }
        public DateTime DeliveryDate { get; set; }

        public long? PurchCommercialDepartmentId { get; set; }
        public string PurchCommercialDepartmentDescription { get; set; }
        
        public long? PurchQuotationApprovalRuleConditionId { get; set; }
        public string PurchQuotationApprovalRuleConditionDescription { get; set; }

        public long? PurchQuotationApprovalRuleConditionStepId { get; set; }
        public string PurchQuotationApprovalRuleConditionStepPurchRoleDescription { get; set; }

        public bool IsCurrentApproval { get; set; }
        public long? PurchOrderHeaderId { get; set; }
    }
}