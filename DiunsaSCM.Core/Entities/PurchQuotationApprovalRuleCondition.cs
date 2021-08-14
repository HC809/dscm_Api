using System.Collections.Generic;

namespace DiunsaSCM.Core.Entities
{
    public class PurchQuotationApprovalRuleCondition : AuditableEntity
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal Priority { get; set; }
        public bool IsActive { get; set; }

        public long PurchQuotationApprovalRuleId { get; set; }

        public virtual PurchQuotationApprovalRule PurchQuotationApprovalRule { get; set; }
        public virtual IEnumerable<PurchQuotationApprovalRuleConditionTerm> PurchQuotationApprovalRuleConditionTerms { get; set; }
        public virtual IEnumerable<PurchQuotationApprovalRuleConditionStep> PurchQuotationApprovalRuleConditionSteps { get; set; }
    }
}   