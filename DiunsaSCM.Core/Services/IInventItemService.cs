using System;
using System.Collections.Generic;
using System.Text;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Utils;

namespace DiunsaSCM.Core.Services
{
    public interface IInventItemService : IServiceBase<InventItemDTO>
    {
    }

    /*public interface IInventItemService
    {
        ServiceResult<InventItemDTO> Add(InventItemDTO inventItem);
        ServiceResult<IEnumerable<InventItemDTO>> GetAll(string searchString);
    }*/
}
