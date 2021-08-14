using System;
using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Services;

namespace DiunsaSCM.Service
{
    public class PurchQuotationCreatorService : ServiceBase<PurchQuotationCreator, PurchQuotationCreatorDTO>, IPurchQuotationCreatorService
    {
        public PurchQuotationCreatorService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<PurchQuotationCreator> repository)
            : base(mapper, unitOfWork, repository)
        {
        }
    }
}
