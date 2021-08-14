using System;
using DiunsaSCM.Core.Entities;
namespace DiunsaSCM.Core.Models
{
    public class PurchQuotationApprovalRoleDTO : AuditableModel
    {
        public long Id { get; set; }
        public long PurchQuotationApprovalId { get; set; }
        public long PurchRoleId { get; set; }
        public long PurchCommercialDepartmentId { get; set; }

        public string PurchRoleCode { get; set; }
        public string PurchRoleDescription { get; set; }
        public string PurchCommercialDepartmentCode { get; set; }
        public string PurchCommercialDepartmentDescription { get; set; }
    }
}