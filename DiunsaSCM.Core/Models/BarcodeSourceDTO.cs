using System;
using DiunsaSCM.Core.Entities;
namespace DiunsaSCM.Core.Models
{
    public class BarcodeSourceDTO
    {
        public long Id { get; set; }
        public long RangeFirst { get; set; }
        public long RangeLast { get; set; }
        public long NextAvailable { get; set; }
    }
}
