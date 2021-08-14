using System;
using System.ComponentModel.DataAnnotations;

namespace DiunsaSCMInterfaceERP.Core.Entities
{
    public class ERPShipmentImport
    {
        [Key]
        public long ERPRecId { get; set; }
        public string BLNumber { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public int Status { get; set; }

        public ERPShipmentImport()
        {
        }
    }
}
