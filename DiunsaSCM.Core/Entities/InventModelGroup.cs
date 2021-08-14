using System;
namespace DiunsaSCM.Core.Entities
{
    public class InventModelGroup : AuditableEntity
    {
        public long Id { get; set; }
        public long ERPRecId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
