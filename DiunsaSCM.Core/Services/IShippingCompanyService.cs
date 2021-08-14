using System;
using System.Collections.Generic;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Utils;

namespace DiunsaSCM.Core.Services
{
    public interface IShippingCompanyService
    {
        ServiceResult<ShippingCompanyDataTransferObject> Add(ShippingCompanyDataTransferObject shippingCompanyDataTransferObject);
        ServiceResult<IEnumerable<ShippingCompanyDataTransferObject>> GetAll();
        ServiceResult<ShippingCompanyDataTransferObject> GetById(long id);
        ServiceResult<ShippingCompanyDataTransferObject> Delete(long id);
        ServiceResult<ShippingCompanyDataTransferObject> Update(ShippingCompanyDataTransferObject shippingCompanyDataTransferObject);
    }
}
