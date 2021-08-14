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
    public class PurchQuotationApprovalRuleConditionStepService : ServiceBase<PurchQuotationApprovalRuleConditionStep, PurchQuotationApprovalRuleConditionStepDTO>, IPurchQuotationApprovalRuleConditionStepService
    {
        public PurchQuotationApprovalRuleConditionStepService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<PurchQuotationApprovalRuleConditionStep> repository)
            : base(mapper, unitOfWork, repository)
        {
        }

        public virtual async Task<ServiceResult<IEnumerable<PurchQuotationApprovalRuleConditionStepDTO>>> GetAllByParentAsync(long parentId)
        {
            try
            {
                var entities = _repository.All()
                    .Include(x => x.PurchRole)
                    .Where(x => x.PurchQuotationApprovalRuleConditionId == parentId)
                    .OrderBy(x => x.Order);

                var entitieDTOs = entities.Select(x => _mapper.Map<PurchQuotationApprovalRuleConditionStepDTO>(x));

                return ServiceResult<IEnumerable<PurchQuotationApprovalRuleConditionStepDTO>>.SuccessResult(entitieDTOs);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<PurchQuotationApprovalRuleConditionStepDTO>>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }
    }
}
