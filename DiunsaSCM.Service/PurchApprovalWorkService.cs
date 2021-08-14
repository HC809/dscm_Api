using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Services;
using DiunsaSCM.Utils;
using Microsoft.EntityFrameworkCore;

namespace DiunsaSCM.Service
{
    public class PurchApprovalWorkService : IPurchApprovalWorkService
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        public PurchApprovalWorkService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResult<IEnumerable<PurchApprovalWorkDTO>>> GetAllAsync(string username, string searchString = "", int slice = 0)
        {
            try
            {
                var approvalRoles = _unitOfWork.PurchQuotationApprovalRoles.All()
                    .Include(x => x.PurchQuotationApproval)
                    .Where(x => x.PurchQuotationApproval.Code == username)
                    .ToList();

                var query = _unitOfWork.PurchQuotations.All()
                    .Include(x => x.PurchCommercialDepartment)
                    .Include(x => x.PurchQuotationApprovalRuleCondition)
                    .Include(x => x.PurchQuotationApprovalRuleConditionStep)
                    .Where(x => x.PurchQuotationStatus == Core.Enums.PurchQuotationStatus.PendingApproval
                        && x.PurchCommercialDepartmentId != null
                        && x.PurchQuotationApprovalRuleConditionStepId != null)
                    .ToList()
                    .Where(x => approvalRoles.Any(z => z.PurchCommercialDepartmentId == x.PurchCommercialDepartmentId
                        && z.PurchRoleId == x.PurchQuotationApprovalRuleConditionStep.PurchRoleId));

                var entityList = query.ToList();

                var model = entityList.Select(x => _mapper.Map<PurchApprovalWorkDTO>(x));
                return ServiceResult<IEnumerable<PurchApprovalWorkDTO>>.SuccessResult(model);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<PurchApprovalWorkDTO>>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos.");
            }
        }
    }
}
