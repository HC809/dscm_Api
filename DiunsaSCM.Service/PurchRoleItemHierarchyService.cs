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
    public class PurchRoleItemHierarchyService : ServiceBase<PurchRoleItemHierarchy, PurchRoleItemHierarchyDTO>, IPurchRoleItemHierarchyService
    {
        public PurchRoleItemHierarchyService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<PurchRoleItemHierarchy> repository)
            : base(mapper, unitOfWork, repository)
        {
        }

        public virtual async Task<ServiceResult<IEnumerable<PurchRoleItemHierarchyDTO>>> GetAllByParentAsync(long parentId)
        {
            try
            {
                var entities = _repository.All()
                    .Include(x => x.ItemHierarchy)
                    .Where(x => x.PurchRoleId == parentId);

                var entitieDTOs = entities.Select(x => _mapper.Map<PurchRoleItemHierarchyDTO>(x));

                return ServiceResult<IEnumerable<PurchRoleItemHierarchyDTO>>.SuccessResult(entitieDTOs);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<PurchRoleItemHierarchyDTO>>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }
    }
}
