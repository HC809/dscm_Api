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
    public class InventItemStoreConfigurationService : ServiceBase<InventItemStoreConfiguration, InventItemStoreConfigurationDTO>, IInventItemStoreConfigurationService
    {
        public InventItemStoreConfigurationService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<InventItemStoreConfiguration> repository)
            : base(mapper, unitOfWork, repository)
        {
        }

        public virtual async Task<ServiceResult<IEnumerable<InventItemStoreConfigurationDTO>>> GetAllByParentAsync(long parentId)
        {
            try
            {
                var entities = _repository.All()
                    .Include(x => x.Store)
                    .Where(x => x.InventItemId == parentId);

                var entitieDTOs = entities.Select(x => _mapper.Map<InventItemStoreConfigurationDTO>(x));

                return ServiceResult<IEnumerable<InventItemStoreConfigurationDTO>>.SuccessResult(entitieDTOs);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<InventItemStoreConfigurationDTO>>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }
    }
}
