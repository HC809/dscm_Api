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
    public class PurchQuotationApprovalRuleConditionService : ServiceBase<PurchQuotationApprovalRuleCondition, PurchQuotationApprovalRuleConditionDTO>, IPurchQuotationApprovalRuleConditionService
    {
        public PurchQuotationApprovalRuleConditionService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<PurchQuotationApprovalRuleCondition> repository)
            : base(mapper, unitOfWork, repository)
        {
        }

        public virtual async Task<ServiceResult<IEnumerable<PurchQuotationApprovalRuleConditionDTO>>> GetAllByParentAsync(long parentId)
        {
            try
            {
                var entities = _repository.All()
                    .Where(x => x.PurchQuotationApprovalRuleId == parentId);

                var entitieDTOs = entities.Select(x => _mapper.Map<PurchQuotationApprovalRuleConditionDTO>(x));

                return ServiceResult<IEnumerable<PurchQuotationApprovalRuleConditionDTO>>.SuccessResult(entitieDTOs);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<PurchQuotationApprovalRuleConditionDTO>>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }
    }
}