namespace DiunsaSCM.Core.Entities
{
    public class InventDim : AuditableEntity
    {
        public long Id { get; set; }
        public long ERPRecId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public long InventItemId { get; set; }
        public long? ColorId { get; set; }
        public long? SizeId { get; set; }

        public virtual InventItem InventItem { get; set; }
        public virtual Color Color { get; set; }
        public virtual Size Size { get; set; }
    }
}