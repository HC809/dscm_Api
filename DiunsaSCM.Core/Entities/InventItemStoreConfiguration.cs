using System;
namespace DiunsaSCM.Core.Entities
{
    public class InventItemStoreConfiguration : AuditableEntity
    {
        public long Id { get; set; }
        public long ERPRecId { get; set; }
        public bool AllowToSell { get; set; }

        public long InventItemId { get; set; }
        public long StoreId { get; set; }

        public virtual InventItem InventItem { get; set; }
        public virtual Store Store { get; set; }

    }
}
