using System;
using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Services;
using DiunsaSCM.Utils;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DiunsaSCM.Service
{
    public class PurchQuotationApprovalRuleConditionTermService : ServiceBase<PurchQuotationApprovalRuleConditionTerm, PurchQuotationApprovalRuleConditionTermDTO>, IPurchQuotationApprovalRuleConditionTermService
    {
        public PurchQuotationApprovalRuleConditionTermService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<PurchQuotationApprovalRuleConditionTerm> repository)
            : base(mapper, unitOfWork, repository)
        {
        }

        public virtual async Task<ServiceResult<IEnumerable<PurchQuotationApprovalRuleConditionTermDTO>>> GetAllByParentAsync(long parentId)
        {
            try
            {
                var entities = _repository.All()
                    .Where(x => x.PurchQuotationApprovalRuleConditionId == parentId);

                var entitieDTOs = entities.Select(x => _mapper.Map<PurchQuotationApprovalRuleConditionTermDTO>(x));

                return ServiceResult<IEnumerable<PurchQuotationApprovalRuleConditionTermDTO>>.SuccessResult(entitieDTOs);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<PurchQuotationApprovalRuleConditionTermDTO>>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }
    }
}