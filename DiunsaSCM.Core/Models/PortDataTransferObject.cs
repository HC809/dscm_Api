using System;
namespace DiunsaSCM.Core.Models
{
    public class PortDataTransferObject : AuditableModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long CountryId { get; set; }
        public string CountryName { get; set; }
        
        public PortDataTransferObject()
        {
        }
    }
}
