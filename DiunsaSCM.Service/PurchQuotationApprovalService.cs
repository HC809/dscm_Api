using System;
using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Services;

namespace DiunsaSCM.Service
{
    public class PurchQuotationApprovalService : ServiceBase<PurchQuotationApproval, PurchQuotationApprovalDTO>, IPurchQuotationApprovalService
    {
        public PurchQuotationApprovalService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<PurchQuotationApproval> repository)
            : base(mapper, unitOfWork, repository)
        {
        }
    }
}