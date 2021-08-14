using System;
using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Services;

namespace DiunsaSCM.Service
{
    public class PurchCostDefinitionService : ServiceBase<PurchCostDefinition, PurchCostDefinitionDTO>, IPurchCostDefinitionService
    {
        public PurchCostDefinitionService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<PurchCostDefinition> repository)
            : base(mapper, unitOfWork, repository)
        {
        }
    }
}
