using System;
namespace DiunsaSCM.Core.Entities
{
    public class PurchRoleItemHierarchy : AuditableEntity
    {
        public long Id { get; set; }
        public long PurchRoleId { get; set; }
        public long ItemHierarchyId { get; set; }

        public virtual PurchRole PurchRole { get; set; }
        public virtual ItemHierarchy ItemHierarchy { get; set; }
    }
}
