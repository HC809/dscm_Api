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
    public class InventDimService : ServiceBase<InventDim, InventDimDTO>, IInventDimService
    {
        public InventDimService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<InventDim> repository)
            : base(mapper, unitOfWork, repository)
        {
        }

        public virtual async Task<ServiceResult<IEnumerable<InventDimDTO>>> GetAllByParentAsync(long parentId)
        {
            try
            {
                var entities = _repository.All()
                    .Include(x=> x.Color)
                    .Include(x => x.Size)
                    .Where(x => x.InventItemId == parentId).ToList();

                var entitieDTOs = entities.Select(x => _mapper.Map<InventDimDTO>(x));

                return ServiceResult<IEnumerable<InventDimDTO>>.SuccessResult(entitieDTOs);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<InventDimDTO>>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }
    }
}