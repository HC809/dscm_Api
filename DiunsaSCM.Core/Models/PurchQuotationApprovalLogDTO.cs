using System;
using DiunsaSCM.Core.Enums;

namespace DiunsaSCM.Core.Models
{
    public class PurchQuotationApprovalLogDTO : AuditableModel
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public PurchQuotationApprovalAction PurchQuotationApprovalAction { get; set; }
        public string PurchQuotationApprovalActionDescription { get; set; }

        public long PurchQuotationId { get; set; }
        public long PurchQuotationApprovalRuleConditionStepId { get; set; }
    }

}