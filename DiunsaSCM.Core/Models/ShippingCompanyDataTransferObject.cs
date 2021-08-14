using System;
namespace DiunsaSCM.Core.Models
{
    public class ShippingCompanyDataTransferObject : AuditableModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string VendorAccount { get; set; }
        public decimal FreeTimeBoxDays { get; set; }
        public decimal FreeTimeBoxHours { get; set; }
        public decimal FreeTimeChassisDays { get; set; }
        public decimal FreeTimeChassisHours { get; set; }

        public ShippingCompanyDataTransferObject()
        {
            
        }
    }
}
