using System;
using System.Collections.Generic;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Utils;

namespace DiunsaSCM.Core.Services
{
    public interface IShippingStepTypeService
    {
        ServiceResult<ShippingStepTypeDTO> Add(ShippingStepTypeDTO model);
        ServiceResult<IEnumerable<ShippingStepTypeDTO>> GetAll();
        ServiceResult<ShippingStepTypeDTO> GetById(long id);
        ServiceResult<ShippingStepTypeDTO> Delete(long id);
        ServiceResult<ShippingStepTypeDTO> Update(ShippingStepTypeDTO model);
    }
}
