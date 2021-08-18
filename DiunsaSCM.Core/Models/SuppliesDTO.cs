using System;
using System.Collections.Generic;
using System.Text;

namespace DiunsaSCM.Core.Models
{
    public class SuppliesDTO : AuditableModel
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public decimal Percentage { get; set; }
    }
}
