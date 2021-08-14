using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Services;
using DiunsaSCM.Utils;

namespace DiunsaSCM.Service
{
    public class PurchOrderShipmentRouteStepSuscriptionService : ServiceBase<PurchOrderShipmentRouteStepSuscription, PurchOrderShipmentRouteStepSuscriptionDTO>, IPurchOrderShipmentRouteStepSuscriptionService
    {
        public PurchOrderShipmentRouteStepSuscriptionService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<PurchOrderShipmentRouteStepSuscription> repository)
            : base(mapper, unitOfWork, repository)
        {
        }

        public ServiceResult<IEnumerable<PurchOrderShipmentRouteStepSuscriptionDTO>> GetAllByPurchOrderShimentHeaderId(long purchOrderShimentHeaderId, string userName) {
            try
            {
                var entityList = _unitOfWork.PurchOrderShipmentRouteStepSuscriptions.GetAllByPurchOrderShimentHeaderId(purchOrderShimentHeaderId, userName);
                var model = entityList.Select(x => _mapper.Map<PurchOrderShipmentRouteStepSuscriptionDTO>(x));
                return ServiceResult<IEnumerable<PurchOrderShipmentRouteStepSuscriptionDTO>>.SuccessResult(model);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<PurchOrderShipmentRouteStepSuscriptionDTO>>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }

        public ServiceResult<IEnumerable<PurchOrderShipmentRouteStepSuscriptionDTO>> GetAllByUserName(string userName)
        {
            try
            {
                var entityList = _unitOfWork.PurchOrderShipmentRouteStepSuscriptions.GetAllByUserName(userName);
                var model = entityList.Select(x => _mapper.Map<PurchOrderShipmentRouteStepSuscriptionDTO>(x));
                return ServiceResult<IEnumerable<PurchOrderShipmentRouteStepSuscriptionDTO>>.SuccessResult(model);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<PurchOrderShipmentRouteStepSuscriptionDTO>>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }
    }
}