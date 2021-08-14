using System;
using DiunsaSCM.Core.Enums;

namespace DiunsaSCM.Core.Entities
{
    public class PurchQuotationApprovalLog : AuditableEntity
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public PurchQuotationApprovalAction PurchQuotationApprovalAction { get; set; }

        public long PurchQuotationId { get; set; }
        public long PurchQuotationApprovalRuleConditionStepId { get; set; }

        public virtual PurchQuotation PurchQuotation { get; set; }
        public virtual PurchQuotationApprovalRuleConditionStep PurchQuotationApprovalRuleConditionStep { get; set; }
    }
}