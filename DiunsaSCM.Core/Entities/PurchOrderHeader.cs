using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DiunsaSCM.Core.Entities
{
    public class PurchOrderHeader : AuditableEntity
    {
        public long Id { get; set; }
        private string _code;
        public string Code { get => _code; set => _code = value == "" ? null : value; }
        public string VendorAccount { get; set; }
        public int PurchStatus { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime CreatedDatetime { get; set; }
        public string PurchName { get; set; }
        public string Reference { get; set; }
        public string PurchPaymentConditionCode { get; set; }

        public string WarehouseCode { get; set; }
        public string WarehouseDescription { get; set; }

        public DateTime ShipmentDateRequested { get; set; }
        public DateTime ShipmentDateConfirmed { get; set; }
        public DateTime DeliveryDate { get; set; }

        public virtual IEnumerable<PurchOrderDetail> PurchOrderDetails { get; set; }
        public virtual IEnumerable<PurchOrderShipmentHeader> PurchOrderShipmentHeaders { get; set; }
        
        public PurchOrderHeader()
        {
        }

        public PurchOrderHeader(PurchQuotation purchQuotation, IUnitOfWork _unitOfWork)
        {
            var vendor = _unitOfWork.Vendors.GetById(purchQuotation.VendorId.GetValueOrDefault());
            var currency = _unitOfWork.Currencies.GetById(purchQuotation.CurrencyId.GetValueOrDefault());
            var purchPaymentCondition = _unitOfWork.PurchPaymentConditions.GetById(purchQuotation.PurchPaymentConditionId.GetValueOrDefault());
            var warehouse = _unitOfWork.Warehouses.GetById(purchQuotation.WarehouseId.GetValueOrDefault());
            PurchName = vendor.Description;
            CreatedDatetime = DateTime.Now;
            Reference = purchQuotation.Description;
            VendorAccount = vendor.Code;
            PurchName = vendor.Description;
            CurrencyCode = currency.Code;
            PurchPaymentConditionCode = purchPaymentCondition.Code;
            WarehouseCode = warehouse.Code;
            WarehouseDescription = warehouse.Description;

            ShipmentDateRequested = purchQuotation.ShipmentDateRequested;
            ShipmentDateConfirmed = purchQuotation.ShipmentDateConfirmed;
            DeliveryDate = purchQuotation.DeliveryDate;

            var purchQuotationLines = _unitOfWork.PurchQuotationLines.All()
                .Include(x => x.InventItem)
                .Include(x => x.Color)
                .Include(x => x.Size)
                .Include(x => x.ItemBarcode)
                .Where(x => x.PurchQuotationId == purchQuotation.Id)
                .Select(x => new PurchOrderDetail
                {
                    Barcode = x.ItemBarcode != null ? x.ItemBarcode.Barcode : "",
                    InventColorId = x.Color != null ? x.Color.Code : "",
                    InventSizeId = x.Size != null ? x.Size.Code : "",
                    ItemId = x.InventItem.Code,
                    ItemName = x.InventItem.Description,
                    NameAlias = x.InventItem.NameAlias,
                    QtyOrdered = x.QtyOrdered,
                    PurchPrice = x.PurchPrice,
                    LineAmount = x.QtyOrdered * x.PurchPrice,
                })
                .ToList();
            PurchOrderDetails = purchQuotationLines;
        }
    }
}
