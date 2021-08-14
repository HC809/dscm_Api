using System;
namespace DiunsaSCM.Core.Entities
{
    public class VendorItemHierarchy : AuditableEntity
    {
        public long Id { get; set; }
        public long VendorId { get; set; }
        public long ItemHierarchyId { get; set; }

        public virtual Vendor Vendor { get; set; }
        public virtual ItemHierarchy ItemHierarchy { get; set; }
    }
}
