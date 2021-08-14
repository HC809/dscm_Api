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
    public class PurchOrderShipmentCrossDockingService : ServiceBase<PurchOrderShipmentCrossDocking, PurchOrderShipmentCrossDockingDTO>, IPurchOrderShipmentCrossDockingService
    {
        public PurchOrderShipmentCrossDockingService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<PurchOrderShipmentCrossDocking> repository)
            : base(mapper, unitOfWork, repository)
        {
        }

        public async Task<ServiceResult<PurchOrderShipmentCrossDockingListDTO>> AddList(PurchOrderShipmentCrossDockingListDTO modelList)
        {
            try
            {
                var entityList = _unitOfWork.PurchOrderShipmentCrossDockings.All()
                    .Include(x => x.ShipmentContainerDetail)
                    .Where(x => x.ShipmentContainerDetail.ShipmentContainerId == modelList.ShipmentContainerId)
                    .ToList();

                foreach (var model in modelList.PurchOrderShipmentCrossDockingList)
                {
                    var entity = entityList.Find(x => x.StoreId == model.StoreId
                        && x.ShipmentContainerDetailId == model.ShipmentContainerDetailId);
                    if (entity == null)
                    {
                        entity = new PurchOrderShipmentCrossDocking {
                            StoreId = model.StoreId,
                            ShipmentContainerDetailId = model.ShipmentContainerDetailId,
                            Qty = model.Qty
                        };
                        _unitOfWork.PurchOrderShipmentCrossDockings.Add(entity);
                    }
                    else
                    {
                        entity.Qty = model.Qty;
                        _unitOfWork.PurchOrderShipmentCrossDockings.Update(entity);
                    }
                }
                _unitOfWork.Complete();
                return ServiceResult<PurchOrderShipmentCrossDockingListDTO>.SuccessResult(modelList);
            }
            catch (Exception ex)
            {
                return ServiceResult<PurchOrderShipmentCrossDockingListDTO>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }

        public virtual async Task<ServiceResult<IEnumerable<PurchOrderShipmentCrossDockingDTO>>> GetAllByParentAsync(long parentId)
        {
            try
            {
                var entities = _repository.All()
                    .Include(x=> x.Store)
                    .Where(x => x.ShipmentContainerDetailId == parentId);

                var entitieDTOs = entities.Select(x => _mapper.Map<PurchOrderShipmentCrossDockingDTO>(x));

                return ServiceResult<IEnumerable<PurchOrderShipmentCrossDockingDTO>>.SuccessResult(entitieDTOs);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<PurchOrderShipmentCrossDockingDTO>>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }

        public async Task<ServiceResult<IEnumerable<PurchOrderShipmentCrossDockingDTO>>> GetAllByShipmentContainerId(long parentId, string searchString = "", int slice = 0)
        {
            try
            {
                var shipmentContainer = _unitOfWork.ShipmentContainers.All()
                .Include(x => x.PurchOrderShipmentHeader)
                    .ThenInclude(x => x.PurchOrderShipmentDetails)
                .Include(x => x.PurchOrderShipmentHeader)
                    .ThenInclude(x => x.PurchOrderHeader)
                .Include(x => x.PurchOrderShipmentHeader)
                    .ThenInclude(x => x.ShipmentImport)
                .FirstOrDefault(x => x.Id == parentId);

                var shipmentContainerDetails = _unitOfWork.ShipmentContainerDetails.All()
                    .Where(x => x.ShipmentContainerId == parentId && x.QtyOnContainer >0 );

                var purchOrderShipmentCrossDockings = _unitOfWork.PurchOrderShipmentCrossDockings.All()
                    .Include(x => x.Store)
                    .Include(x => x.ShipmentContainerDetail)
                    .Where(x => x.ShipmentContainerDetail.ShipmentContainerId == shipmentContainer.Id);

                var entitieDTOs = (from sc in shipmentContainerDetails
                                    join cd in purchOrderShipmentCrossDockings
                                        on sc.Id equals cd.ShipmentContainerDetailId into gj
                                    from x in gj.DefaultIfEmpty()
                                    select new PurchOrderShipmentCrossDockingDTO
                                    {
                                        Id = x.Id,
                                        Qty = x.Qty,
                                        ShipmentContainerDetailId = sc.Id,
                                        StoreId = x.StoreId,
                                        StoreCode = x.Store.Code,
                                        StoreDescription = x.Store.Description,
                                        ShipmentContainerId = sc.ShipmentContainerId,
                                        PurchId = sc.ShipmentContainer.PurchOrderShipmentHeader.PurchOrderHeader.Code,
                                        BLNumber = sc.ShipmentContainer.PurchOrderShipmentHeader.ShipmentImport.BLNumber,
                                        ContainerNumber = sc.ShipmentContainer.ContainerNumber,
                                        ItemId = sc.PurchOrderOrderDetail.ItemId,
                                        ItemName = sc.PurchOrderOrderDetail.ItemName,
                                        NameAlias = sc.PurchOrderOrderDetail.NameAlias,
                                        Barcode = sc.PurchOrderOrderDetail.Barcode,
                                        InventSizeId = sc.PurchOrderOrderDetail.InventSizeId,
                                        InventColorId = sc.PurchOrderOrderDetail.InventColorId,
                                        QtyOnContainer = sc.QtyOnContainer
                                    }).ToList();

                return ServiceResult<IEnumerable<PurchOrderShipmentCrossDockingDTO>>.SuccessResult(entitieDTOs);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<PurchOrderShipmentCrossDockingDTO>>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }
    }
}
