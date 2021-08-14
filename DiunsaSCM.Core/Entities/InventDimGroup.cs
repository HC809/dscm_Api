namespace DiunsaSCM.Core.Entities
{
    public class InventDimGroup : AuditableEntity
    {
        public long Id { get; set; }
        public long ERPRecId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public bool ColorRequired { get; set; }
        public bool SizeRequired { get; set; }
        public bool ConfigurationRequired { get; set; }
        public bool StyleRequired { get; set; }
        public bool SerialNumberRequired { get; set; }
    }
}