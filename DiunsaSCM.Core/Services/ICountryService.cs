using System;
using System.Collections.Generic;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Utils;

namespace DiunsaSCM.Core.Services
{
    public interface ICountryService
    {
        ServiceResult<CountryDataTransferObject> Add(CountryDataTransferObject model);
        ServiceResult<IEnumerable<CountryDataTransferObject>> GetAll();
        ServiceResult<CountryDataTransferObject> GetById(long id);
        ServiceResult<CountryDataTransferObject> Delete(long id);
        ServiceResult<CountryDataTransferObject> Update(CountryDataTransferObject model);
    }
}
