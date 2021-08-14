using System;
namespace DiunsaSCM.Core.Models
{
    public class IncotermDTO : AuditableModel
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
