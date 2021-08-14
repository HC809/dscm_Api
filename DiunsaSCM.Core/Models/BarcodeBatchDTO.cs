using System;
using DiunsaSCM.Core.Entities;
namespace DiunsaSCM.Core.Models
{
    public class BarcodeBatchDTO
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public int QtyRequested { get; set; }
        public int QtyGenerated { get; set; }
    }
}