using System;
using System.Collections.Generic;
using System.Text;

namespace DiunsaSCMInterfaceERP.Core.Entities
{
    public class ERPImportInventTableLine
    {
        public long Id { get; set; }
        public long ParentRecId { get; set; }
        public string ItemId { get; set; }
        public string InventDimGroupId { get; set; }
        public string NameAlias { get; set; }
        public string ItemBarcode { get; set; }
        public string InventSizeId { get; set; }
        public string SizeName { get; set; }
        public string InventColorId { get; set; }
        public string ColorName { get; set; }
        public string ItemName { get; set; }
        public int Cantidad { get; set; }
        public decimal Costo { get; set; }
        public int GrupoId { get; set; }
        public string Accountnum { get; set; }
        public string TaxItemGroupId { get; set; }
        public string Descontable { get; set; }
        public int DescuentoEmpl { get; set; }
        public string BrandId { get; set; }
        public int ItemUME { get; set; }
        public string ClasificacionTemporada { get; set; }
        public string CMR_T1 { get; set; }
        public string CMR_T2 { get; set; }
        public string CMR_T3 { get; set; }
        public string CMR_T4 { get; set; }
        public string CMR_T5 { get; set; }
        public string CMR_T6 { get; set; }
        public string CMR_MAY { get; set; }
        public string CMR_ECOM { get; set; }
    }
}
