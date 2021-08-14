using System;
using DiunsaSCM.Core.Entities;
namespace DiunsaSCM.Core.Models
{
    public class BarcodeDTO
    {
        public long Id { get; set; }
        public long Number { get; set; }
        public int ControlDigit { get; set; }
        public string Code { get; set; }

        public long BarcodeBatchId { get; set; }

    }
}