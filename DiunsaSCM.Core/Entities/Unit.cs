namespace DiunsaSCM.Core.Entities
{
    public class Unit : AuditableEntity
    {
        public long Id { get; set; }
        public long ERPRecId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}