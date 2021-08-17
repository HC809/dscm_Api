using System;
using System.Collections.Generic;
using System.Text;

namespace DiunsaSCM.Core.Models
{
    public class ExchangeRateDTO : AuditableModel
    {
        public long Id { get; set; }
        public decimal ExchangeRate1 { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
