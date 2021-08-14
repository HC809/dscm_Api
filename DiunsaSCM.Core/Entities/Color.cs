namespace DiunsaSCM.Core.Entities
{
    public class Color : AuditableEntity
    {
        public long Id { get; set; }
        public long ERPRecId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public long InventItemId { get; set; }

        public virtual InventItem InventItem { get; set; }

    }
}