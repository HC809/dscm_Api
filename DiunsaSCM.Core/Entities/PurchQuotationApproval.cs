using System.Collections.Generic;

namespace DiunsaSCM.Core.Entities
{
    public class PurchQuotationApproval : AuditableEntity
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public virtual IEnumerable<PurchQuotationApprovalRole> PurchQuotationApprovalRoles { get; set; }
    }
}