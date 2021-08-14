using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Enums;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Services;
using DiunsaSCM.Utils;
using Microsoft.EntityFrameworkCore;

namespace DiunsaSCM.Service
{
    public class ItemHierarchyService : ServiceBase<ItemHierarchy, ItemHierarchyDTO>, IItemHierarchyService
    {
        public ItemHierarchyService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<ItemHierarchy> repository)
            : base(mapper, unitOfWork, repository)
        {
        }
        /*
        public async Task<ServiceResult<IEnumerable<ItemHierarchyDTO>>> GetAllAsync(ItemHierarchyLevel itemHierarchyLevel)
        {
            try
            {
                var entityList = _repository.All().Where(x => itemHierarchyLevel == 0  || x.ItemHierarchyLevel == itemHierarchyLevel).ToList();
                var model = entityList.Select(x => _mapper.Map<ItemHierarchyDTO>(x));
                return ServiceResult<IEnumerable<ItemHierarchyDTO>>.SuccessResult(model);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<ItemHierarchyDTO>>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos.");
            }
        }*/

        
        public async Task<ServiceResult<IEnumerable<ItemHierarchyDTO>>> GetAllAsync(ItemHierarchyLevel itemHierarchyLevel, bool includeChildren)
        {
            try
            {
                var entityList = _repository.All();
                IEnumerable<ItemHierarchy> result = new List<ItemHierarchy>();
                if (includeChildren)
                {
                    result = entityList
                        .Include(x => x.Children)
                        .Include(x => x.InventItemGroup)
                        .ToList()
                        .Where(x => itemHierarchyLevel == 0
                            || x.ItemHierarchyLevel == itemHierarchyLevel);
                }
                else {
                    result = entityList
                        .Include(x => x.Parent)
                        .Include(x => x.InventItemGroup)
                        .ToList()
                        .Where(x => itemHierarchyLevel == 0
                            || x.ItemHierarchyLevel == itemHierarchyLevel);
                }

                result = result.OrderBy(x => x.ItemHierarchyLevel).ThenBy(x=> x.Code);

                var model = result.Select(x => _mapper.Map<ItemHierarchyDTO>(x));
                return ServiceResult<IEnumerable<ItemHierarchyDTO>>.SuccessResult(model);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<ItemHierarchyDTO>>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos.");
            }
        }
    }
}
