using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Services;
using DiunsaSCM.Utils;
using Microsoft.EntityFrameworkCore;

namespace DiunsaSCM.Service
{
    public class ItemBarcodeService : ServiceBase<ItemBarcode, ItemBarcodeDTO>, IItemBarcodeService
    {
        public ItemBarcodeService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<ItemBarcode> repository)
            : base(mapper, unitOfWork, repository)
        {
        }


        public ServiceResult<ItemBarcodeDTO> GetById(long id)
        {
            try
            {
                var entity = _repository.All()
                    .Include(x => x.InventItem)
                    .Include(x => x.InventItem)
                    .ThenInclude(x => x.Vendor)
                    .Include(x => x.InventDim)
                    .ThenInclude(x => x.Color)
                    .Include(x => x.InventDim)
                    .ThenInclude(x => x.Size)
                    .FirstOrDefault(x => x.Id == id);

                var model = _mapper.Map<ItemBarcodeDTO>(entity);
                return ServiceResult<ItemBarcodeDTO>.SuccessResult(model);
            }
            catch (Exception ex)
            {
                return ServiceResult<ItemBarcodeDTO>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos.");
            }
        }

        public virtual async Task<ServiceResult<IEnumerable<ItemBarcodeDTO>>> GetAllByParentAsync(long parentId)
        {
            try
            {
                var entities = _repository.All()
                    .Include(x => x.InventDim)
                    .ThenInclude(x=> x.Color)
                    .Include(x => x.InventDim)
                    .ThenInclude(x => x.Size)
                    .Where(x => x.InventItemId == parentId);

                var entitieDTOs = entities.Select(x => _mapper.Map<ItemBarcodeDTO>(x));

                return ServiceResult<IEnumerable<ItemBarcodeDTO>>.SuccessResult(entitieDTOs);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<ItemBarcodeDTO>>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }

        public virtual async Task<ServiceResult<IEnumerable<ItemBarcodeDTO>>> GetAllAsync(string searchString = "", int slice = 0)
        {
            try
            {
                var entities = _repository.All()
                    .Include(x => x.InventItem)
                    .Include(x => x.InventItem)
                    .ThenInclude(x => x.Vendor)
                    .Include(x => x.InventDim)
                    .ThenInclude(x => x.Color)
                    .Include(x => x.InventDim)
                    .ThenInclude(x => x.Size)
                    .Where(x => String.IsNullOrEmpty(searchString)
                        || x.Barcode.Contains(searchString)
                        || x.InventItem.Code.Contains(searchString)
                        || x.InventItem.Description.Contains(searchString)
                        || x.InventItem.NameAlias.Contains(searchString)
                        || (x.InventItem.Vendor != null && x.InventItem.Vendor.Code.Contains(searchString))
                        || (x.InventItem.Vendor != null && x.InventItem.Vendor.Description.Contains(searchString))
                        );

                if (slice > 0)
                {
                    entities = entities.Take(slice);
                }

                var entitieDTOs = entities.Select(x => _mapper.Map<ItemBarcodeDTO>(x));

                return ServiceResult<IEnumerable<ItemBarcodeDTO>>.SuccessResult(entitieDTOs);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<ItemBarcodeDTO>>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }
    }
}
