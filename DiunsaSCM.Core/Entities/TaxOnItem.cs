namespace DiunsaSCM.Core.Entities
{
    public class TaxOnItem : AuditableEntity
    {
        public long Id { get; set; }
        public long ERPRecId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public long TaxItemGroupHeadingId { get; set; }

        public virtual TaxItemGroupHeading TaxItemGroupHeading { get; set; }

    }
}