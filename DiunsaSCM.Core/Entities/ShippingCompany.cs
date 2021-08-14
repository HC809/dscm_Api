using System;
namespace DiunsaSCM.Core.Entities
{
    public class ShippingCompany : AuditableEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string VendorAccount { get; set; }
        public decimal FreeTimeBoxDays { get; set; }
        public decimal FreeTimeBoxHours { get; set; }
        public decimal FreeTimeChassisDays { get; set; }
        public decimal FreeTimeChassisHours { get; set; }

        public ShippingCompany()
        {
        }
    }
}
