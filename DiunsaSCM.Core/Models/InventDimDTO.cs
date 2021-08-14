namespace DiunsaSCM.Core.Models
{
    public class InventDimDTO : AuditableModel
    {
        public long Id { get; set; }
        public string Description { get; set; }

        public long InventItemId { get; set; }

        public long? ColorId { get; set; }
        public string ColorCode { get; set; }

        public long? SizeId { get; set; }
        public string SizeCode { get; set; }

    }
}