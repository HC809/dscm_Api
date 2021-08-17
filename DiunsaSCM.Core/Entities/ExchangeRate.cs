using System;
namespace DiunsaSCM.Core.Entities
{
    public partial class ExchangeRate : AuditableEntity
    {
        public long Id { get; set; }
        public decimal ExchangeRate1 { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
