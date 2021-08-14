using System;
namespace DiunsaSCM.Core.Entities
{
    public class PurchQuotationApprovalRole : AuditableEntity
    {
        public long Id { get; set; }
        public long PurchQuotationApprovalId { get; set; }
        public long PurchRoleId { get; set; }
        public long PurchCommercialDepartmentId { get; set; }

        public virtual PurchQuotationApproval PurchQuotationApproval { get; set; }
        public virtual PurchRole PurchRole { get; set; }
        public virtual PurchCommercialDepartment PurchCommercialDepartment { get; set; }

    }
}
