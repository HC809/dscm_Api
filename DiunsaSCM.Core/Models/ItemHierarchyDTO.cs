using System;
using System.Collections.Generic;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Enums;

namespace DiunsaSCM.Core.Models
{
    public class ItemHierarchyDTO
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string SearchText { get { return Code + " - " + Description; } }

        public ItemHierarchyLevel ItemHierarchyLevel { get; set; }
        public string ItemHierarchyLevelDescription { get; set; }

        public int? ParentId { get; set; }
        public string ParentCode { get; set; }

        public long? InventItemGroupId { get; set; }
        public string InventItemGroupCode { get; set; }

        public virtual IEnumerable<ItemHierarchyDTO> Children { get; set; }
    }
}