using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DiunsaSCM.Core.Enums;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Utils;

namespace DiunsaSCM.Core.Services
{
    public interface IItemHierarchyService : IServiceBase<ItemHierarchyDTO>
    {
        Task<ServiceResult<IEnumerable<ItemHierarchyDTO>>> GetAllAsync(ItemHierarchyLevel itemHierarchyLevel, bool includeChildren);
    }
}