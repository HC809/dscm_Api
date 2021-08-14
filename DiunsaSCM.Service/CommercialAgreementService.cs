using System;
using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Services;

namespace DiunsaSCM.Service
{
    public class CommercialAgreementService : ServiceBase<CommercialAgreement, CommercialAgreementDTO>, ICommercialAgreementService
    {
        public CommercialAgreementService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<CommercialAgreement> repository)
            : base(mapper, unitOfWork, repository)
        {
        }
    }
}
