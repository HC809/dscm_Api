namespace DiunsaSCM.Core.Models
{
    public class SizeDTO : AuditableModel
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public long InventItemId { get; set; }
        public string InventItemCode { get; set; }
        public string InventItemDescription { get; set; }
    }
}