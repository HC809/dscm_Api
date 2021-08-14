using System;
namespace DiunsaSCM.Core.Entities
{
    public class PurchQuotationApprovalRuleConditionStep : AuditableEntity
    {
        public long Id { get; set; }
        public long PurchQuotationApprovalRuleConditionId { get; set; }
        public long PurchRoleId { get; set; }
        public long Order { get; set; }

        public virtual PurchQuotationApprovalRuleCondition PurchQuotationApprovalRuleCondition { get; set; }
        public virtual PurchRole PurchRole { get; set; }
    }
}
