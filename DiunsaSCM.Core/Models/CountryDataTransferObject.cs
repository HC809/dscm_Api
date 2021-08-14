using System;
namespace DiunsaSCM.Core.Models
{
    public class CountryDataTransferObject : AuditableModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public CountryDataTransferObject()
        {
        }
    }
}
