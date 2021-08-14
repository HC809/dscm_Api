using System;
using DiunsaSCM.Core.Enums;

namespace DiunsaSCM.Core.Models
{
    public class PurchQuotationApprovalRuleConditionTermDTO : AuditableModel
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string ComparisonValue { get; set; }
        public decimal LowerBound { get; set; }
        public decimal UpperBound { get; set; }

        public long PurchQuotationApprovalRuleConditionId { get; set; }

        public PurchQuotationApprovalRuleConditionField PurchQuotationApprovalRuleConditionField { get; set; }
        public string PurchQuotationApprovalRuleConditionFieldDescription { get; set; }
        public PurchQuotationApprovalRuleConditionComparisonOperation PurchQuotationApprovalRuleConditionComparisonOperation { get; set; }
        public string PurchQuotationApprovalRuleConditionComparisonOperationDescription { get; set; }

    }
}