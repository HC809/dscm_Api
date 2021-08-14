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
    public class ShippingStepTypeService : IShippingStepTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ShippingStepTypeService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public ServiceResult<ShippingStepTypeDTO> Add(ShippingStepTypeDTO shippingStepTypeDataTransferObject)
        {
            try
            {
                var shippingStepType = _mapper.Map<ShippingStepType>(shippingStepTypeDataTransferObject);
                shippingStepType = _unitOfWork.ShippingStepTypes.Add(shippingStepType);
                _unitOfWork.Complete();
                shippingStepTypeDataTransferObject.Id = shippingStepType.Id;
                return ServiceResult<ShippingStepTypeDTO>.SuccessResult(shippingStepTypeDataTransferObject);
            }
            catch (Exception ex)
            {
                return ServiceResult<ShippingStepTypeDTO>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }

        public ServiceResult<ShippingStepTypeDTO> Delete(long id)
        {
            try
            {
                var shippingStepType = _unitOfWork.ShippingStepTypes.GetById(id);
                var shippingStepTypeDataTransferObject = _mapper.Map<ShippingStepTypeDTO>(shippingStepType);
                _unitOfWork.ShippingStepTypes.Delete(shippingStepType);
                _unitOfWork.Complete();
                return ServiceResult<ShippingStepTypeDTO>.SuccessResult(shippingStepTypeDataTransferObject);
            }
            catch (Exception ex)
            {
                return ServiceResult<ShippingStepTypeDTO>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }

        public ServiceResult<IEnumerable<ShippingStepTypeDTO>> GetAll()
        {
            try
            {
                var shippingStepTypes = _unitOfWork.ShippingStepTypes.All();
                var shippingStepTypeDataTransferObject = shippingStepTypes.Select(x => _mapper.Map<ShippingStepTypeDTO>(x));
                return ServiceResult<IEnumerable<ShippingStepTypeDTO>>.SuccessResult(shippingStepTypeDataTransferObject);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<ShippingStepTypeDTO>>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }

        public ServiceResult<ShippingStepTypeDTO> GetById(long id)
        {
            try
            {
                var shippingStepType = _unitOfWork.ShippingStepTypes.GetById(id);
                var shippingStepTypeDataTransferObject = _mapper.Map<ShippingStepTypeDTO>(shippingStepType);
                return ServiceResult<ShippingStepTypeDTO>.SuccessResult(shippingStepTypeDataTransferObject);
            }
            catch (Exception ex)
            {
                return ServiceResult<ShippingStepTypeDTO>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }

        public ServiceResult<ShippingStepTypeDTO> Update(ShippingStepTypeDTO shippingStepTypeDataTransferObject)
        {
            try
            {
                var shippingStepType = _mapper.Map<ShippingStepType>(shippingStepTypeDataTransferObject);
                shippingStepType = _unitOfWork.ShippingStepTypes.Update(shippingStepType);
                _unitOfWork.Complete();
                return ServiceResult<ShippingStepTypeDTO>.SuccessResult(shippingStepTypeDataTransferObject);
            }
            catch (Exception ex)
            {
                return ServiceResult<ShippingStepTypeDTO>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }
    }
}
