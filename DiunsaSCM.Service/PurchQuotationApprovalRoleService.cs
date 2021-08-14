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
    public class PurchQuotationApprovalRoleService : ServiceBase<PurchQuotationApprovalRole, PurchQuotationApprovalRoleDTO>, IPurchQuotationApprovalRoleService
    {
        public PurchQuotationApprovalRoleService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<PurchQuotationApprovalRole> repository)
            : base(mapper, unitOfWork, repository)
        {
        }

        public virtual async Task<ServiceResult<IEnumerable<PurchQuotationApprovalRoleDTO>>> GetAllByParentAsync(long parentId)
        {
            try
            {
                var entities = _repository.All()
                    .Include(x => x.PurchRole)
                    .Include(x => x.PurchCommercialDepartment)
                    .Where(x => x.PurchQuotationApprovalId == parentId);

                var entitieDTOs = entities.Select(x => _mapper.Map<PurchQuotationApprovalRoleDTO>(x));

                return ServiceResult<IEnumerable<PurchQuotationApprovalRoleDTO>>.SuccessResult(entitieDTOs);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<PurchQuotationApprovalRoleDTO>>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }
    }
}
