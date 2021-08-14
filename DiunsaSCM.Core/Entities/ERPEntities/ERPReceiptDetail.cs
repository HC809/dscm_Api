using System;
using System.ComponentModel.DataAnnotations;

namespace DiunsaSCMInterfaceERP.Core.Entities.ERPEntities
{
    public class ERPReceiptDetail
    {
        [Key]
        public long ERPRecId { get; set; }
        public decimal Qty { get; set; }
    }
}
