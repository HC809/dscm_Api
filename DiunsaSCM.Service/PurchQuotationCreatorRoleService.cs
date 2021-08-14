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
    public class PurchQuotationCreatorRoleService : ServiceBase<PurchQuotationCreatorRole, PurchQuotationCreatorRoleDTO>, IPurchQuotationCreatorRoleService
    {
        public PurchQuotationCreatorRoleService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<PurchQuotationCreatorRole> repository)
            : base(mapper, unitOfWork, repository)
        {
        }

        public virtual async Task<ServiceResult<IEnumerable<PurchQuotationCreatorRoleDTO>>> GetAllByParentAsync(long parentId)
        {
            try
            {
                var entities = _repository.All()
                    .Include(x => x.PurchRole)
                    .Where(x => x.PurchQuotationCreatorId == parentId);

                var entitieDTOs = entities.Select(x => _mapper.Map<PurchQuotationCreatorRoleDTO>(x));

                return ServiceResult<IEnumerable<PurchQuotationCreatorRoleDTO>>.SuccessResult(entitieDTOs);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<PurchQuotationCreatorRoleDTO>>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }
    }
}
