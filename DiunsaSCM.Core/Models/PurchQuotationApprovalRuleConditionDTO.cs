using System;

namespace DiunsaSCM.Core.Models
{
    public class PurchQuotationApprovalRuleConditionDTO : AuditableModel
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal Priority { get; set; }
        public bool IsActive { get; set; }

        public long PurchQuotationApprovalRuleId { get; set; }

    }
}