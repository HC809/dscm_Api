using DiunsaSCM.Core.Enums;

namespace DiunsaSCM.Core.Entities
{
    public class PurchQuotationApprovalRuleConditionTerm : AuditableEntity
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string ComparisonValue { get; set; }
        public decimal LowerBound { get; set; }
        public decimal UpperBound { get; set; }

        public PurchQuotationApprovalRuleConditionField PurchQuotationApprovalRuleConditionField { get; set; }
        public PurchQuotationApprovalRuleConditionComparisonOperation PurchQuotationApprovalRuleConditionComparisonOperation { get; set; }

        public long PurchQuotationApprovalRuleConditionId { get; set; }

        public virtual PurchQuotationApprovalRuleCondition PurchQuotationApprovalRuleCondition { get; set; }
    }
}