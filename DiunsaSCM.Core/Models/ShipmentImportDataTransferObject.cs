using System;
namespace DiunsaSCM.Core.Models
{
    public class ShipmentImportDTO : AuditableModel
    {
        public long Id { get; set; }
        public long ERPRecId { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public string BLNumber { get; set; }
        public int Status { get; set; }

        public ShipmentImportDTO()
        {
        }
    }
}
