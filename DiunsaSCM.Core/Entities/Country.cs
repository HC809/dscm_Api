using System;
namespace DiunsaSCM.Core.Entities
{
    public class Country : AuditableEntity
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public Country()
        {
            
        }
    }
}
