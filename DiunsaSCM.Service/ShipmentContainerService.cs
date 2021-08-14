using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using DiunsaSCM.Data;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Utils;
using Microsoft.EntityFrameworkCore;

namespace DiunsaSCM.Service
{
    public class ShipmentContainerService : IShipmentContainerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ShipmentContainerService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public ServiceResult<ShipmentContainerDataTransferObject> Add(ShipmentContainerDataTransferObject shipmentContainerDataTransferObject)
        {
            try
            {
                var shipmentContainer = _mapper.Map<ShipmentContainer>(shipmentContainerDataTransferObject);

                _unitOfWork.ShipmentContainers.Add(shipmentContainer);
                _unitOfWork.Complete();

                shipmentContainerDataTransferObject.Id = shipmentContainer.Id;

                return ServiceResult<ShipmentContainerDataTransferObject>.SuccessResult(shipmentContainerDataTransferObject);
            }
            catch (Exception ex)
            {
                return ServiceResult<ShipmentContainerDataTransferObject>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
           
        }

        public ServiceResult<IEnumerable<ShipmentContainerDataTransferObject>> GetAll()
        {
            throw new NotImplementedException();
        }

        public ServiceResult<ShipmentContainerDataTransferObject> GetById(long id)
        {
            try
            {
                var shipmentContainer = _unitOfWork.ShipmentContainers.All()
                                .Include(x => x.PurchOrderShipmentHeader)
                                .ThenInclude(x => x.PurchOrderHeader)
                                .Include(x => x.PurchOrderShipmentHeader)
                                .ThenInclude(x => x.ShipmentImport)
                                .FirstOrDefault(x => x.Id == id);
                var shipmentContainerDataTransferObject = _mapper.Map<ShipmentContainerDataTransferObject>(shipmentContainer);
                return ServiceResult<ShipmentContainerDataTransferObject>.SuccessResult(shipmentContainerDataTransferObject);
            }
            catch (Exception ex)
            {
                return ServiceResult<ShipmentContainerDataTransferObject>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
            
        }

        public ServiceResult<IEnumerable<ShipmentContainerDataTransferObject>> GetByPurchOrderShipmentHeaderId(long purchOrderShipmentHeaderId)
        {
            try
            {
                var shipmentContainer = _unitOfWork.ShipmentContainers.GetByPurchOrderShipmentHeaderId(purchOrderShipmentHeaderId)
                                .Select(x => _mapper.Map<ShipmentContainerDataTransferObject>(x));

                return ServiceResult<IEnumerable<ShipmentContainerDataTransferObject>>.SuccessResult(shipmentContainer);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<ShipmentContainerDataTransferObject>>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
            
        }

        public ServiceResult<ShipmentContainerDataTransferObject> Delete(long id)
        {
            try
            {
                var shipmentContainer = _unitOfWork.ShipmentContainers.GetById(id);
                shipmentContainer = _unitOfWork.ShipmentContainers.Delete(shipmentContainer);
                _unitOfWork.Complete();

                var shipmentContainerDataTransferObject = _mapper.Map<ShipmentContainerDataTransferObject>(shipmentContainer);
                return ServiceResult<ShipmentContainerDataTransferObject>.SuccessResult(shipmentContainerDataTransferObject);
            }
            catch (Exception ex)
            {
                return ServiceResult<ShipmentContainerDataTransferObject>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
            
        }

        public ServiceResult<ShipmentContainerDataTransferObject> Update(ShipmentContainerDataTransferObject shipmentContainerDataTransferObject)
        {
            try
            {
                var shipmentContainer = _mapper.Map<ShipmentContainer>(shipmentContainerDataTransferObject);
                shipmentContainer = _unitOfWork.ShipmentContainers.Update(shipmentContainer);
                _unitOfWork.Complete();

                return ServiceResult<ShipmentContainerDataTransferObject>.SuccessResult(shipmentContainerDataTransferObject);
            }
            catch (Exception ex)
            {
                return ServiceResult<ShipmentContainerDataTransferObject>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
            
        }

        public ServiceResult<ShipmentContainerDetailDataTransferObject> AddLine(ShipmentContainerDetailDataTransferObject shipmentContainerDetailDataTransferObject)
        {
            try
            {
                var shipmentContainerDetail = _mapper.Map<ShipmentContainerDetail>(shipmentContainerDetailDataTransferObject);
                _unitOfWork.ShipmentContainerDetails.Add(shipmentContainerDetail);
                var purchOrderDetail = _unitOfWork.PurchOrderDetails.GetById(shipmentContainerDetail.PurchOrderDetailId);
                var qtyOnContainers = purchOrderDetail.GetQtyOnContainers();
                if (qtyOnContainers > purchOrderDetail.QtyOrdered)
                {
                    return ServiceResult<ShipmentContainerDetailDataTransferObject>.ErrorResult("Las cantidades definidas en contenedores exceden lo establecido en la orden de compra");
                }
                _unitOfWork.Complete();

                shipmentContainerDetailDataTransferObject.Id = shipmentContainerDetail.Id;
                return ServiceResult<ShipmentContainerDetailDataTransferObject>.SuccessResult(shipmentContainerDetailDataTransferObject);

            }
            catch (Exception ex)
            {
                return ServiceResult<ShipmentContainerDetailDataTransferObject>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
            
        }

        public ServiceResult<ShipmentContainerDetailsListDataTransferObject> AddLineList(ShipmentContainerDetailsListDataTransferObject shipmentContainerDetailsList)
        {
            try
            {
                foreach (ShipmentContainerDetailDataTransferObject shipmentContainerDetailDataTransferObject in shipmentContainerDetailsList.ShipmentContainerDetailList)
                {
                    var shipmentContainerDetail = this.GetByPurchOrderDetailId(shipmentContainerDetailDataTransferObject.PurchOrderDetailId, shipmentContainerDetailsList.ShipmentContainerId);
                    if (shipmentContainerDetail == null)
                    {
                        shipmentContainerDetailDataTransferObject.ShipmentContainerId = shipmentContainerDetailsList.ShipmentContainerId;
                        shipmentContainerDetail = _mapper.Map<ShipmentContainerDetail>(shipmentContainerDetailDataTransferObject);
                        _unitOfWork.ShipmentContainerDetails.Add(shipmentContainerDetail);
                    }
                    else
                    {
                        shipmentContainerDetail.QtyOnContainer = shipmentContainerDetailDataTransferObject.QtyOnContainer;
                        _unitOfWork.ShipmentContainerDetails.Update(shipmentContainerDetail);
                    }
                    var purchOrderDetail = _unitOfWork.PurchOrderDetails.GetById(shipmentContainerDetail.PurchOrderDetailId);
                    var qtyOnContainers = purchOrderDetail.GetQtyOnContainers();
                    if (qtyOnContainers > purchOrderDetail.QtyOrdered)
                    {
                        return ServiceResult<ShipmentContainerDetailsListDataTransferObject>.ErrorResult("Las cantidades definidas en contenedores exceden lo establecido en la orden de compra");
                    }
                }
                _unitOfWork.Complete();
                return ServiceResult<ShipmentContainerDetailsListDataTransferObject>.SuccessResult(shipmentContainerDetailsList);
            }
            catch (Exception ex)
            {
                return ServiceResult<ShipmentContainerDetailsListDataTransferObject>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
            
        }

        public ShipmentContainerDetail GetByPurchOrderDetailId(long purchOrderDetailId, long shipmentContainerId)
        {
            var shipmentContainerDetails = _unitOfWork.ShipmentContainerDetails.All()
                .FirstOrDefault(x => x.PurchOrderDetailId == purchOrderDetailId && x.ShipmentContainerId == shipmentContainerId);
            return shipmentContainerDetails;
        }

        public ServiceResult<ShipmentContainerDetailDataTransferObject> DeleteLine(long id, long shipmentContainerDetailId)
        {
            try
            {
                var shipmentContainerDetail = _unitOfWork.ShipmentContainerDetails.GetById(shipmentContainerDetailId);
                _unitOfWork.ShipmentContainerDetails.Delete(shipmentContainerDetail);
                _unitOfWork.Complete();
                var shipmentContainerDetailDataTransferObject = _mapper.Map<ShipmentContainerDetailDataTransferObject>(shipmentContainerDetail);
                return ServiceResult<ShipmentContainerDetailDataTransferObject>.SuccessResult(shipmentContainerDetailDataTransferObject);

            }
            catch (Exception ex)
            {
                return ServiceResult<ShipmentContainerDetailDataTransferObject>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
            
        }

        public ServiceResult<ShipmentContainerDetailDataTransferObject> UpdateLine(long id, ShipmentContainerDetailDataTransferObject shipmentContainerDetailDataTransferObject)
        {
            try
            {
                var shipmentContainerDetail = _mapper.Map<ShipmentContainerDetail>(shipmentContainerDetailDataTransferObject);
                _unitOfWork.ShipmentContainerDetails.Update(shipmentContainerDetail);
                var purchOrderDetail = _unitOfWork.PurchOrderDetails.GetById(shipmentContainerDetail.PurchOrderDetailId);
                var qtyOnContainers = purchOrderDetail.GetQtyOnContainers();
                if (qtyOnContainers > purchOrderDetail.QtyOrdered)
                {
                    return ServiceResult<ShipmentContainerDetailDataTransferObject>.ErrorResult("Las cantidades definidas en contenedores exceden lo establecido en la orden de compra");
                }
                _unitOfWork.Complete();

                return ServiceResult<ShipmentContainerDetailDataTransferObject>.SuccessResult(shipmentContainerDetailDataTransferObject);

            }
            catch (Exception ex)
            {
                return ServiceResult<ShipmentContainerDetailDataTransferObject>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }

        public ServiceResult<ShipmentContainerDetailDataTransferObject> GetLine(long id, long shipmentContainerDetailId)
        {
            try
            {
                var shipmentContainerDetail = _unitOfWork.ShipmentContainerDetails.GetById(shipmentContainerDetailId);
                var shipmentContainerDetailDataTransferObject = _mapper.Map<ShipmentContainerDetailDataTransferObject>(shipmentContainerDetail);
                return ServiceResult<ShipmentContainerDetailDataTransferObject>.SuccessResult(shipmentContainerDetailDataTransferObject);

            }
            catch (Exception ex)
            {
                return ServiceResult<ShipmentContainerDetailDataTransferObject>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }

        public ServiceResult<IEnumerable<ShipmentContainerDetailDataTransferObject>> GetLines(long id)
        {
            try
            {
                var shipmentContainerDetails = _unitOfWork.ShipmentContainerDetails.GetByShipmentContainerId(id);

                var shipmentContainerDetailDataTransferObjects = shipmentContainerDetails
                    .Select(x => _mapper.Map<ShipmentContainerDetailDataTransferObject>(x));

                return ServiceResult<IEnumerable<ShipmentContainerDetailDataTransferObject>>.SuccessResult(shipmentContainerDetailDataTransferObjects);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<ShipmentContainerDetailDataTransferObject>>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
            
        }

    }
}
