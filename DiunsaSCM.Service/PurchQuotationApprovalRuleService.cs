using System;
using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Services;

namespace DiunsaSCM.Service
{
    public class PurchQuotationApprovalRuleService : ServiceBase<PurchQuotationApprovalRule, PurchQuotationApprovalRuleDTO>, IPurchQuotationApprovalRuleService
    {
        public PurchQuotationApprovalRuleService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<PurchQuotationApprovalRule> repository)
            : base(mapper, unitOfWork, repository)
        {
        }
    }
}