using System;
using System.Collections.Generic;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Utils;

namespace DiunsaSCM.Core.Services
{
    public interface IShipmentLogEntryService
    {
        ServiceResult<ShipmentLogEntryDataTransferObject> Add(long purchOrderHeaderId, long purchOrderShimentHeaderId, ShipmentLogEntryDataTransferObject model);
        ServiceResult<IEnumerable<ShipmentLogEntryDataTransferObject>> GetAll(long purchOrderHeaderId, long purchOrderShimentHeaderId);
        ServiceResult<ShipmentLogEntryDataTransferObject> GetById(long purchOrderHeaderId, long purchOrderShimentHeaderId, long id);
        ServiceResult<ShipmentLogEntryDataTransferObject> Delete(long purchOrderHeaderId, long purchOrderShimentHeaderId, long id);
        ServiceResult<ShipmentLogEntryDataTransferObject> Update(long purchOrderHeaderId, long purchOrderShimentHeaderId, ShipmentLogEntryDataTransferObject model);
    }
}
