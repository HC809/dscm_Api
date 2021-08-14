using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using DiunsaSCM.Utils;

namespace DiunsaSCM.Service
{
    public class ShipmentContainerTypeService : IShipmentContainerTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ShipmentContainerTypeService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public ServiceResult<ShipmentContainerTypeDataTransferObject> Add(ShipmentContainerTypeDataTransferObject shipmentContainerTypeDataTransferObject)
        {
            try
            {
                var shipmentContainerType = _mapper.Map<ShipmentContainerType>(shipmentContainerTypeDataTransferObject);
                shipmentContainerType = _unitOfWork.ShipmentContainerTypes.Add(shipmentContainerType);
                _unitOfWork.Complete();
                shipmentContainerTypeDataTransferObject.Id = shipmentContainerType.Id;
                return ServiceResult<ShipmentContainerTypeDataTransferObject>.SuccessResult(shipmentContainerTypeDataTransferObject);
            }
            catch (Exception ex)
            {
                return ServiceResult<ShipmentContainerTypeDataTransferObject>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }

        public ServiceResult<ShipmentContainerTypeDataTransferObject> Delete(long id)
        {
            try
            {
                var shipmentContainerType = _unitOfWork.ShipmentContainerTypes.GetById(id);
                var shipmentContainerTypeDataTransferObject = _mapper.Map<ShipmentContainerTypeDataTransferObject>(shipmentContainerType);
                _unitOfWork.ShipmentContainerTypes.Delete(shipmentContainerType);
                _unitOfWork.Complete();
                return ServiceResult<ShipmentContainerTypeDataTransferObject>.SuccessResult(shipmentContainerTypeDataTransferObject);
            }
            catch (Exception ex)
            {
                return ServiceResult<ShipmentContainerTypeDataTransferObject>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }

        public ServiceResult<IEnumerable<ShipmentContainerTypeDataTransferObject>> GetAll()
        {
            try
            {
                var shipmentContainerTypes = _unitOfWork.ShipmentContainerTypes.All();
                var shipmentContainerTypeDataTransferObjects = shipmentContainerTypes.Select(x => _mapper.Map<ShipmentContainerTypeDataTransferObject>(x));
                return ServiceResult<IEnumerable<ShipmentContainerTypeDataTransferObject>>.SuccessResult(shipmentContainerTypeDataTransferObjects);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<ShipmentContainerTypeDataTransferObject>>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }

        public ServiceResult<ShipmentContainerTypeDataTransferObject> GetById(long id)
        {
            try
            {
                var shipmentContainerType = _unitOfWork.ShipmentContainerTypes.GetById(id);
                var shipmentContainerTypeDataTransferObject = _mapper.Map<ShipmentContainerTypeDataTransferObject>(shipmentContainerType);
                return ServiceResult<ShipmentContainerTypeDataTransferObject>.SuccessResult(shipmentContainerTypeDataTransferObject);
            }
            catch (Exception ex)
            {
                return ServiceResult<ShipmentContainerTypeDataTransferObject>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }

        public ServiceResult<ShipmentContainerTypeDataTransferObject> Update(ShipmentContainerTypeDataTransferObject shipmentContainerTypeDataTransferObject)
        {
            try
            {
                var shipmentContainerType = _mapper.Map<ShipmentContainerType>(shipmentContainerTypeDataTransferObject);
                shipmentContainerType = _unitOfWork.ShipmentContainerTypes.Update(shipmentContainerType);
                _unitOfWork.Complete();
                return ServiceResult<ShipmentContainerTypeDataTransferObject>.SuccessResult(shipmentContainerTypeDataTransferObject);
            }
            catch (Exception ex)
            {
                return ServiceResult<ShipmentContainerTypeDataTransferObject>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
            
        }
    }
}
