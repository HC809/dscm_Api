using System;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Utils;

namespace DiunsaSCM.Core.Services
{
    public interface ISalesPriceDefinitionLineService : IServiceBase<SalesPriceDefinitionLineDTO>
    {
        ServiceResult<SalesPriceDefinitionLineListDTO> AddList(SalesPriceDefinitionLineListDTO modelList);
    }
}