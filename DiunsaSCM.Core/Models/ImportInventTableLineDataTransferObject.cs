using System;
using System.Collections.Generic;
using System.Text;

namespace DiunsaSCM.Core.Models
{
    public class ImportInventTableLineDataTransferObject
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
        public string GrupoId { get; set; }
        public string Accountnum { get; set; }
        public string TaxItemGroupId { get; set; }
        public string Descontable { get; set; }
        public string DescuentoEmpl { get; set; }
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
        public decimal Cajita { get; set; }
        public decimal Caja { get; set; }

        public decimal Pallet { get; set; }
        public decimal Unidad_Peso { get; set; }
        public decimal Unidad_Grosor { get; set; }
        public decimal Unidad_Anchura { get; set; }
        public decimal Unidad_Altura { get; set; }
        public decimal Cajita_Peso { get; set; }
        public decimal Cajita_Grosor { get; set; }
        public decimal Cajita_Anchura { get; set; }
        public decimal Cajita_Altura { get; set; }
        public decimal Caja_Peso { get; set; }
        public decimal Caja_Grosor { get; set; }
        public decimal Caja_Anchura { get; set; }
        public decimal Caja_Altura { get; set; }
        public decimal Pallet_Peso { get; set; }
        public decimal Pallet_Grosor { get; set; }
        public decimal Pallet_Anchura { get; set; }
        public decimal Pallet_Altura { get; set; }

        public string Descripcion_Web { get; set; }
        public string Origen { get; set; }

        public string Bloquea_Venta { get; set; }
        public string Bloquea_Compra { get; set; }
        public string Bloquea_Abastecimiento { get; set; }
        

    }
}
