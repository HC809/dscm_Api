using System;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Utils;

namespace DiunsaSCM.Core.Services
{
    public interface IPurchCostDefinitionLineService : IServiceBase<PurchCostDefinitionLineDTO>
    {
        ServiceResult<PurchCostDefinitionLineListDTO> AddList(PurchCostDefinitionLineListDTO modelList);
    }
}