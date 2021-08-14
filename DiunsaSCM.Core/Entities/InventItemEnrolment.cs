using System;
namespace DiunsaSCM.Core.Entities
{
    public class InventItemEnrolment : AuditableEntity
    {
        public long Id { get; set; }
        private string _code;
        public string Code { get => _code; set => _code = value == "" ? null : value; }
        public string Description { get; set; }
    }
}
