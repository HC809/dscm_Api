using System;
using System.Collections.Generic;

namespace DiunsaSCM.Core.Models
{
    public class InventItemPrepackBarcodeListDTO
    {
        public long InventItemId { get; set; }
        public IEnumerable<InventItemPrepackBarcodeDTO> InventItemPrepackBarcodeList { get; set; }
    }
}
