using System;

namespace DiunsaSCM.Core.Models
{
    public class PurchQuotationApprovalRuleDTO : AuditableModel
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

    }
}