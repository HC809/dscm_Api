using System;
using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Services;
using DiunsaSCM.Utils;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using DiunsaSCM.Core.Enums;

namespace DiunsaSCM.Service
{
    public class PurchQuotationLineService : ServiceBase<PurchQuotationLine, PurchQuotationLineDTO>, IPurchQuotationLineService
    {
        public PurchQuotationLineService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<PurchQuotationLine> repository)
            : base(mapper, unitOfWork, repository)
        {
        }



        public virtual async Task<ServiceResult<IEnumerable<PurchQuotationLineDTO>>> GetAllByParentAsync(long parentId)
        {
            try
            {
                var entities = _repository.All()
                    .Include(x => x.InventItem)
                    .Include(x => x.Color)
                    .Include(x => x.Size)
                    .Include(x => x.ItemBarcode)
                    .Where(x => x.PurchQuotationId == parentId)
                    .OrderBy(x => x.LineNum);

                var entitieDTOs = entities.Select(x => _mapper.Map<PurchQuotationLineDTO>(x));

                return ServiceResult<IEnumerable<PurchQuotationLineDTO>>.SuccessResult(entitieDTOs);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<PurchQuotationLineDTO>>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }

        public override ServiceResult<PurchQuotationLineDTO> Add(PurchQuotationLineDTO model)
        {
            try
            {
                var inventItem = _unitOfWork.InventItems.All()
                    .Include(x => x.InventItemPrepackBarcodes)
                    .ThenInclude(x => x.ItemBarcode)
                    .ThenInclude(x => x.InventItem)
                    .Include(x => x.InventItemPrepackBarcodes)
                    .ThenInclude(x => x.ItemBarcode)
                    .ThenInclude(x => x.InventDim)
                    .FirstOrDefault(x=> x.Id == model.InventItemId);

                model.InventItemCode = inventItem.Code;
                model.InventItemDescription = inventItem.Description;

                if (model.ItemBarcodeId != null) {
                    var itemBarcode = _unitOfWork.ItemBarcodes.GetById(model.ItemBarcodeId.GetValueOrDefault());
                    model.ItemBarcodeBarcode = itemBarcode.Barcode;
                }
                if (model.SizeId != null)
                {
                    var size = _unitOfWork.Sizes.GetById(model.SizeId.GetValueOrDefault());
                    model.SizeCode = size.Code;
                    model.SizeDescription = size.Description;
                }
                if (model.ColorId != null)
                {
                    var color = _unitOfWork.Colors.GetById(model.ColorId.GetValueOrDefault());
                    model.ColorCode = color.Code;
                    model.ColorDescription = color.Description;
                }
                
                model.LineAmount = model.QtyOrdered * model.PurchPrice;

                var entity = _mapper.Map<PurchQuotationLine>(model);
                
                if (inventItem.ItemType == ItemType.Prepack)
                {
                    entity.PurchQuotationLinePrepackDetails = new List<PurchQuotationLinePrepackDetail>();
                    foreach (var inventItemPrepackBarcode in inventItem.InventItemPrepackBarcodes)
                    {
                        PurchQuotationLinePrepackDetail purchQuotationLinePrepackDetail = new PurchQuotationLinePrepackDetail();
                        purchQuotationLinePrepackDetail.ItemBarcodeId = inventItemPrepackBarcode.ItemBarcodeId;
                        purchQuotationLinePrepackDetail.InventItemId = inventItemPrepackBarcode.ItemBarcode.InventItemId;
                        purchQuotationLinePrepackDetail.SizeId = inventItemPrepackBarcode.ItemBarcode.InventDim.SizeId;
                        purchQuotationLinePrepackDetail.ColorId = inventItemPrepackBarcode.ItemBarcode.InventDim.ColorId;
                        purchQuotationLinePrepackDetail.QtyPerPrepack = inventItemPrepackBarcode.Qty;
                        purchQuotationLinePrepackDetail.PurchPrice = inventItemPrepackBarcode.ItemBarcode.InventItem.PurchPrice;
                        entity.PurchQuotationLinePrepackDetails.Add(purchQuotationLinePrepackDetail);
                    }

                    entity.SetPurchPrice();
                }

                entity = _repository.Add(entity);
                _repository.SaveChanges();
                model = _mapper.Map<PurchQuotationLineDTO>(entity);
                return ServiceResult<PurchQuotationLineDTO>.SuccessResult(model);
            }
            catch (Exception ex)
            {
                return ServiceResult<PurchQuotationLineDTO>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos.");
            }
        }
    }
}