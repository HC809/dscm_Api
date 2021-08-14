using System;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Enums;

namespace DiunsaSCM.Core.Models
{
    public class VendorItemHierarchyDTO
    {
        public long Id { get; set; }
        public long VendorId { get; set; }

        public long ItemHierarchyId { get; set; }
        public string ItemHierarchyCode { get; set; }
        public string ItemHierarchyDescription { get; set; }
        public ItemHierarchyLevel ItemHierarchyItemHierarchyLevel { get; set; }
        public string ItemHierarchyItemHierarchyLevelDescription { get; set; }

    }
}