using System;
using System.Collections.Generic;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Utils;

namespace DiunsaSCM.Core.Services
{
    public interface IPortService
    {
        ServiceResult<PortDataTransferObject> Add(PortDataTransferObject portDataTransferObject);
        ServiceResult<IEnumerable<PortDataTransferObject>> GetAll();
        ServiceResult<PortDataTransferObject> GetById(long id);
        ServiceResult<PortDataTransferObject> Delete(long id);
        ServiceResult<PortDataTransferObject> Update(PortDataTransferObject portDataTransferObject);
    }
}
