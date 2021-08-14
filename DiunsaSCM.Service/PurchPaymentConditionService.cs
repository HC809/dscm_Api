using System;
using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Services;

namespace DiunsaSCM.Service
{
    public class PurchPaymentConditionService : ServiceBase<PurchPaymentCondition, PurchPaymentConditionDTO>, IPurchPaymentConditionService
    {
        public PurchPaymentConditionService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<PurchPaymentCondition> repository)
            : base(mapper, unitOfWork, repository)
        {
        }
    }
}
