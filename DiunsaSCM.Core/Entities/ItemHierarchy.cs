using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DiunsaSCM.Core.Enums;

namespace DiunsaSCM.Core.Entities
{
    public class ItemHierarchy : AuditableEntity
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public ItemHierarchyLevel ItemHierarchyLevel { get; set; }

        public long? InventItemGroupId { get; set; }
        public long? ParentId { get; set; }

        [ForeignKey("ParentId")]
        public virtual ItemHierarchy Parent { get; set; }
        public virtual IEnumerable<ItemHierarchy> Children { get; set; }
        public virtual InventItemGroup InventItemGroup { get; set; }

        public long? GetParentInventItemGroupId()
        {
            if (this.InventItemGroupId != null)
            {
                return this.InventItemGroupId;
            }

            if (this.Parent == null)
            {
                return null;
            }
            return Parent.GetParentInventItemGroupId();    
        }
    }
}
