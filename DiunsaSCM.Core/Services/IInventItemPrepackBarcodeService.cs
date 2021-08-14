using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Utils;

namespace DiunsaSCM.Core.Services
{
    public interface IInventItemPrepackBarcodeService : IServiceBase<InventItemPrepackBarcodeDTO>
    {
        Task<ServiceResult<InventItemPrepackBarcodeListDTO>> AddList(InventItemPrepackBarcodeListDTO modelList);
    }
}