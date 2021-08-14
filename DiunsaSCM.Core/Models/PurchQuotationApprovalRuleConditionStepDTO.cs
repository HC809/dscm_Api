using System;
using DiunsaSCM.Core.Entities;
namespace DiunsaSCM.Core.Models
{
    public class PurchQuotationApprovalRuleConditionStepDTO : AuditableModel
    {
        public long Id { get; set; }
        public long PurchQuotationApprovalRuleConditionId { get; set; }
        public long PurchRoleId { get; set; }
        public long Order { get; set; }

        public string PurchRoleCode { get; set; }
        public string PurchRoleDescription { get; set; }
    }
}