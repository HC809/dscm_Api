using System;
namespace DiunsaSCM.Core.Entities
{
    public class Warehouse : AuditableEntity
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
