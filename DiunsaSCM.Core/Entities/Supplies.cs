using System;
using System.Collections.Generic;
using System.Text;

namespace DiunsaSCM.Core.Entities
{
    public class Supplies: AuditableEntity
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public decimal Percentage { get; set; }
    }
}
