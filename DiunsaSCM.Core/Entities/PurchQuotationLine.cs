using System;
using System.Collections.Generic;
using System.Linq;
using DiunsaSCM.Utils;

namespace DiunsaSCM.Core.Entities
{
    public class PurchQuotationLine : AuditableEntity
    {
        public long Id { get; set; }
        public decimal QtyOrdered { get; set; }
        public decimal PurchPrice { get; set; }
        private decimal _lineAmount { get; set; }
        public decimal LineAmount { get => QtyOrdered * PurchPrice; set => _lineAmount = QtyOrdered * PurchPrice; }
        public int LineNum { get; set; }

        public long InventItemId { get; set; }
        public long? ItemBarcodeId { get; set; }
        public long? SizeId { get; set; }
        public long? ColorId { get; set; }
        public long PurchQuotationId { get; set; }

        public virtual PurchQuotation PurchQuotation { get; set; }
        public virtual InventItem InventItem { get; set; }
        public virtual ItemBarcode ItemBarcode { get; set; }
        public virtual Size Size { get; set; }
        public virtual Color Color { get; set; }
        public virtual IList<PurchQuotationLinePrepackDetail> PurchQuotationLinePrepackDetails { get; set; }
        

        public ServiceResult<object> ValidateWrite()
        {
            if (ItemBarcodeId == null && ItemBarcode == null)
            {
                return ServiceResult<object>.ErrorResult("No se ha asignado un código de barras para este artículo.");
            }
            if (InventItem.ItemHierarchyId == null)
            {
                return ServiceResult<object>.ErrorResult("No se ha asignado el Grupo de Arículos de Árbol de Surtido al artículo");
            }
            if (InventItem.TaxItemGroupHeadingId == null)
            {
                return ServiceResult<object>.ErrorResult("No se ha asignado el Grupo de Impuestos para el artículo");
            }
            if (InventItem.InventDimGroupId == null)
            {
                return ServiceResult<object>.ErrorResult("No se ha asignado el Grupo de Dimensiones para el artículo");
            }
            if (InventItem.BrandId == null)
            {
                return ServiceResult<object>.ErrorResult("No se ha asignado la Marca para el artículo");
            }
            if (InventItem.VendorId == null)
            {
                return ServiceResult<object>.ErrorResult("No se ha asignado el Proveedor para el artículo");
            }
            if (InventItem.ItemSeasonalCategoryId == null)
            {
                return ServiceResult<object>.ErrorResult("No se ha asignado la Clasificación de Temporada para el artículo");
            }
            if (string.IsNullOrEmpty(InventItem.Description))
            {
                return ServiceResult<object>.ErrorResult("No se ha asignado la Descripción para el artículo");
            }
            if (string.IsNullOrEmpty(InventItem.NameAlias))
            {
                return ServiceResult<object>.ErrorResult("No se ha asignado la Referencia para el artículo");
            }
            if (string.IsNullOrEmpty(InventItem.WebSiteDescription))
            {
                return ServiceResult<object>.ErrorResult("No se ha asignado la Descripción Web para el artículo");
            }
            if (InventItem.GrossDepth == 0)
            {
                return ServiceResult<object>.ErrorResult("No se ha asignado el campo Grosor para el artículo");
            }
            if (InventItem.GrossHeight == 0)
            {
                return ServiceResult<object>.ErrorResult("No se ha asignado el campo Altura para el artículo");
            }
            if (InventItem.GrossWidth == 0)
            {
                return ServiceResult<object>.ErrorResult("No se ha asignado el campo Anchura para el artículo");
            }
            if (InventItem.GrossWeight == 0)
            {
                return ServiceResult<object>.ErrorResult("No se ha asignado el campo Peso para el artículo");
            }
            return ServiceResult<object>.SuccessResult(new object());
        }

        public void SetPurchPrice()
        {
            decimal purchPrice = 0;
            purchPrice = PurchQuotationLinePrepackDetails.Sum(x => x.PurchPrice * (decimal)x.QtyPerPrepack * this.QtyOrdered);

            PurchPrice = purchPrice;
        }
    }
}