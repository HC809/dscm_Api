using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using DiunsaSCM.Utils;
using Microsoft.EntityFrameworkCore;

namespace DiunsaSCM.Service
{
    public class ShippingRouteStepService : IShippingRouteStepService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ShippingRouteStepService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public ServiceResult<ShippingRouteStepDataTransferObject> Add(ShippingRouteStepDataTransferObject ShippingRouteStepDataTransferObject)
        {
            try
            {
                var shippingRouteStep = _mapper.Map<ShippingRouteStep>(ShippingRouteStepDataTransferObject);
                shippingRouteStep = _unitOfWork.ShippingRouteSteps.Add(shippingRouteStep);
                _unitOfWork.Complete();
                ShippingRouteStepDataTransferObject.Id = shippingRouteStep.Id;
                return ServiceResult<ShippingRouteStepDataTransferObject>.SuccessResult(ShippingRouteStepDataTransferObject);
            }
            catch {
                return ServiceResult<ShippingRouteStepDataTransferObject>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }

        public ServiceResult<ShippingRouteStepDataTransferObject> Delete(long id)
        {
            try
            {
                var shippingRouteStep = _unitOfWork.ShippingRouteSteps.GetById(id);
                var ShippingRouteStepDataTransferObject = _mapper.Map<ShippingRouteStepDataTransferObject>(shippingRouteStep);
                _unitOfWork.ShippingRouteSteps.Delete(shippingRouteStep);
                _unitOfWork.Complete();
                return ServiceResult<ShippingRouteStepDataTransferObject>.SuccessResult(ShippingRouteStepDataTransferObject);
            }
            catch (Exception ex){
                return ServiceResult<ShippingRouteStepDataTransferObject>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }

        public ServiceResult<IEnumerable<ShippingRouteStepDataTransferObject>> GetAll()
        {
            try
            {
                var shippingRouteStep = _unitOfWork.ShippingRouteSteps.All().Include(x => x.ShippingStepType).OrderBy(x => x.StepNumber);
                var ShippingRouteStepDataTransferObject = shippingRouteStep.Select(x => _mapper.Map<ShippingRouteStepDataTransferObject>(x));
                return ServiceResult<IEnumerable<ShippingRouteStepDataTransferObject>>.SuccessResult(ShippingRouteStepDataTransferObject);
            }
            catch {
                return ServiceResult<IEnumerable<ShippingRouteStepDataTransferObject>>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }

        

        public ServiceResult<IEnumerable<ShippingRouteStepDataTransferObject>> GetAllByShippingRoute(long shippingRouteId)
        {
            try
            {
                var shippingRouteStep = _unitOfWork.ShippingRouteSteps.All()
                .Where(x => x.ShippingRouteId == shippingRouteId)
                .Include(x => x.ShippingStepType)
                .OrderBy(x => x.StepNumber);
                var ShippingRouteStepDataTransferObject = shippingRouteStep.Select(x => _mapper.Map<ShippingRouteStepDataTransferObject>(x));
                return ServiceResult<IEnumerable<ShippingRouteStepDataTransferObject>>.SuccessResult(ShippingRouteStepDataTransferObject);
            }
            catch
            {
                return ServiceResult<IEnumerable<ShippingRouteStepDataTransferObject>>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }
        public ServiceResult<ShippingRouteStepDataTransferObject> GetById(long id)
        {
            try
            {
                var shippingRouteStep = _unitOfWork.ShippingRouteSteps.GetById(id);
                var ShippingRouteStepDataTransferObject = _mapper.Map<ShippingRouteStepDataTransferObject>(shippingRouteStep);
                return ServiceResult<ShippingRouteStepDataTransferObject>.SuccessResult(ShippingRouteStepDataTransferObject);
            }
            catch
            {
                return ServiceResult<ShippingRouteStepDataTransferObject>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }
        public ServiceResult<ShippingRouteStepDataTransferObject> Update(ShippingRouteStepDataTransferObject ShippingRouteStepDataTransferObject)
        {
            try
            {
                var shippingRouteStep = _mapper.Map<ShippingRouteStep>(ShippingRouteStepDataTransferObject);
                shippingRouteStep = _unitOfWork.ShippingRouteSteps.Update(shippingRouteStep);
                _unitOfWork.Complete();
                return ServiceResult<ShippingRouteStepDataTransferObject>.SuccessResult(ShippingRouteStepDataTransferObject);
            }
            catch
            {
                return ServiceResult<ShippingRouteStepDataTransferObject>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }
    }
}
