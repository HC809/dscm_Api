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

namespace DiunsaSCM.Service
{
    public class InventItemPrepackBarcodeService : ServiceBase<InventItemPrepackBarcode, InventItemPrepackBarcodeDTO>, IInventItemPrepackBarcodeService
    {
        public InventItemPrepackBarcodeService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<InventItemPrepackBarcode> repository)
            : base(mapper, unitOfWork, repository)
        {
        }

        public async Task<ServiceResult<InventItemPrepackBarcodeListDTO>> AddList(InventItemPrepackBarcodeListDTO modelList)
        {
            try
            {
                var entityList = _unitOfWork.InventItemPrepackBarcodes.All()
                    .Include(x => x.ItemBarcode)
                    .Where(x => x.InventItemId == modelList.InventItemId)
                    .ToList();

                foreach (var model in modelList.InventItemPrepackBarcodeList)
                {
                    var entity = entityList.Find(x => x.ItemBarcode.Barcode == model.ItemBarcodeBarcode);
                    if (entity == null)
                    {
                        var itemBarcode = _unitOfWork.ItemBarcodes.All()
                            .FirstOrDefault(x => x.Barcode == model.ItemBarcodeBarcode);
                        if (itemBarcode == null)
                        {
                            var error = string.Format("No se ha encontrado el código de barras: {0}", model.ItemBarcodeBarcode);
                            return ServiceResult<InventItemPrepackBarcodeListDTO>.ErrorResult(error);
                        }
                        entity = new InventItemPrepackBarcode
                        {
                            InventItemId = modelList.InventItemId,
                            ItemBarcodeId = itemBarcode.Id,
                            Qty = model.Qty
                        };
                        _unitOfWork.InventItemPrepackBarcodes.Add(entity);
                    }
                    else
                    {
                        entity.Qty = model.Qty;
                        _unitOfWork.InventItemPrepackBarcodes.Update(entity);
                    }
                }
                _unitOfWork.Complete();
                return ServiceResult<InventItemPrepackBarcodeListDTO>.SuccessResult(modelList);
            }
            catch (Exception ex)
            {
                return ServiceResult<InventItemPrepackBarcodeListDTO>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }

        public virtual async Task<ServiceResult<IEnumerable<InventItemPrepackBarcodeDTO>>> GetAllByParentAsync(long parentId)
        {
            try
            {
                var entities = _repository.All()
                    .Include(x => x.ItemBarcode)
                    .ThenInclude(x => x.InventItem)
                    .Include(x => x.ItemBarcode)
                    .ThenInclude(x => x.InventDim)
                    .ThenInclude(x => x.Color)
                    .Include(x => x.ItemBarcode)
                    .ThenInclude(x => x.InventDim)
                    .ThenInclude(x => x.Size)
                    .Where(x => x.InventItemId == parentId);

                var entitieDTOs = entities.Select(x => _mapper.Map<InventItemPrepackBarcodeDTO>(x));

                return ServiceResult<IEnumerable<InventItemPrepackBarcodeDTO>>.SuccessResult(entitieDTOs);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<InventItemPrepackBarcodeDTO>>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }
    }
}
