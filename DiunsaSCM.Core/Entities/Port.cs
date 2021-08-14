using System;
namespace DiunsaSCM.Core.Entities
{
    public class Port : AuditableEntity
    {
        public long Id { get; set; }
        public long? CountryId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public virtual Country Country { get; set; }

        public Port()
        {
        }

    }
}
