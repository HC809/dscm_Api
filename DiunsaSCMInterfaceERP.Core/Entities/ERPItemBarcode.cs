using System;
using System.Collections.Generic;
using System.Text;

namespace DiunsaSCMInterfaceERP.Core.Entities
{
    public class ERPItemBarcode
    {
        public long Id { get; set; }
        public string Barcode { get; set; }
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public string NameAlias { get; set; }
        public string InventColorId { get; set; }
        public string InventSizeId { get; set; }
        public string BarcodeSetupId { get; set; }
        internal static void FromSqlRaw(string v)
        {
            throw new NotImplementedException();
        }
    }
}
