using System.Collections.Generic;

namespace DiunsaSCM.Core.Entities
{
    public class PurchQuotationApprovalRule : AuditableEntity
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public virtual IEnumerable<PurchQuotationApprovalRuleCondition> PurchQuotationApprovalRuleConditions { get; set; }
    }
}