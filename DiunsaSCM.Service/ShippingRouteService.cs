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
    public class ShippingRouteService : IShippingRouteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ShippingRouteService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public ServiceResult<ShippingRouteDTO> Add(ShippingRouteDTO shippingRouteDataTransferObject)
        {
            try
            {
                var shippingRoute = _mapper.Map<ShippingRoute>(shippingRouteDataTransferObject);
                shippingRoute = _unitOfWork.ShippingRoutes.Add(shippingRoute);
                _unitOfWork.Complete();
                shippingRouteDataTransferObject.Id = shippingRoute.Id;
                return ServiceResult<ShippingRouteDTO>.SuccessResult(shippingRouteDataTransferObject);
            }
            catch (Exception ex)
            {
                return ServiceResult<ShippingRouteDTO>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }

        public ServiceResult<ShippingRouteDTO> Delete(long id)
        {
            try
            {
                var shippingRoute = _unitOfWork.ShippingRoutes.GetById(id);
                var shippingRouteDataTransferObject = _mapper.Map<ShippingRouteDTO>(shippingRoute);
                _unitOfWork.ShippingRoutes.Delete(shippingRoute);
                _unitOfWork.Complete();
                return ServiceResult<ShippingRouteDTO>.SuccessResult(shippingRouteDataTransferObject);
            }
            catch (Exception ex)
            {
                return ServiceResult<ShippingRouteDTO>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }

        public ServiceResult<IEnumerable<ShippingRouteDTO>> GetAll()
        {
            try
            {

                var shippingRoutes = _unitOfWork.ShippingRoutes.All()
                    .Include(x => x.PortOfOrigin)
                    .Include(x => x.PortOfDestination)
                    .Include(x => x.ShippingRouteSteps)
                    .Include(x => x.ShippingRouteStatusPresentationSchema);
                var shippingRouteDataTransferObject = shippingRoutes.Select(x => _mapper.Map<ShippingRouteDTO>(x));
                return ServiceResult<IEnumerable<ShippingRouteDTO>>.SuccessResult(shippingRouteDataTransferObject);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<ShippingRouteDTO>>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }

        public ServiceResult<ShippingRouteDTO> GetById(long id)
        {
            try
            {
                var shippingRoute = _unitOfWork.ShippingRoutes.GetById(id);
                var shippingRoutesDataTransferObject = _mapper.Map<ShippingRouteDTO>(shippingRoute);
                return ServiceResult<ShippingRouteDTO>.SuccessResult(shippingRoutesDataTransferObject);
            }
            catch (Exception ex)
            {
                return ServiceResult<ShippingRouteDTO>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }

        public ServiceResult<ShippingRouteDTO> Update(ShippingRouteDTO shippingRouteDataTransferObject)
        {
            try
            {
                var shippingRoute = _mapper.Map<ShippingRoute>(shippingRouteDataTransferObject);
                shippingRoute = _unitOfWork.ShippingRoutes.Update(shippingRoute);
                _unitOfWork.Complete();
                return ServiceResult<ShippingRouteDTO>.SuccessResult(shippingRouteDataTransferObject);
            }
            catch (Exception ex)
            {
                return ServiceResult<ShippingRouteDTO>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }
    }
}
