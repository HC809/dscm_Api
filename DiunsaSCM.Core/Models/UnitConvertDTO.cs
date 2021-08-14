namespace DiunsaSCM.Core.Models
{
    public class UnitConvertDTO : AuditableModel
    {
        public long Id { get; set; }
        public long ERPRecId { get; set; }

        public long InventItemId { get; set; }
        public long FromUnitId { get; set; }
        public long ToUnitId { get; set; }
        public decimal Factor { get; set; }

        public decimal GrossDepth { get; set; }
        public decimal GrossWidth { get; set; }
        public decimal GrossHeight { get; set; }
        public decimal GrossWeight { get; set; }

        public string FromUnitCode { get; set; }
        public string ToUnitCode { get; set; }
    }
}