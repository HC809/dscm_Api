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
    public class VendorItemHierarchyService : ServiceBase<VendorItemHierarchy, VendorItemHierarchyDTO>, IVendorItemHierarchyService
    {
        public VendorItemHierarchyService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<VendorItemHierarchy> repository)
            : base(mapper, unitOfWork, repository)
        {
        }

        public virtual async Task<ServiceResult<IEnumerable<VendorItemHierarchyDTO>>> GetAllByParentAsync(long parentId)
        {
            try
            {
                var entities = _repository.All()
                    .Include(x => x.ItemHierarchy)
                    .Where(x => x.VendorId == parentId);

                var entitieDTOs = entities.Select(x => _mapper.Map<VendorItemHierarchyDTO>(x));

                return ServiceResult<IEnumerable<VendorItemHierarchyDTO>>.SuccessResult(entitieDTOs);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<VendorItemHierarchyDTO>>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }
    }
}
