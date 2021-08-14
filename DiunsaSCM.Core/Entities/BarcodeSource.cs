using System;
namespace DiunsaSCM.Core.Entities
{
    public class BarcodeSource : AuditableEntity
    {
        public long Id { get; set; }
        public long RangeFirst { get; set; }
        public long RangeLast { get; set; }
        public long NextAvailable { get; set; }
    }
}
