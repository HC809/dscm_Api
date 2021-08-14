using System;
using System.Collections.Generic;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Utils;

namespace DiunsaSCM.Core.Services
{
    public interface IShipmentContainerTypeService
    {
        ServiceResult<ShipmentContainerTypeDataTransferObject> Add(ShipmentContainerTypeDataTransferObject shippingContainerTypeDataTransferObject);
        ServiceResult<IEnumerable<ShipmentContainerTypeDataTransferObject>> GetAll();
        ServiceResult<ShipmentContainerTypeDataTransferObject> GetById(long id);
        ServiceResult<ShipmentContainerTypeDataTransferObject> Delete(long id);
        ServiceResult<ShipmentContainerTypeDataTransferObject> Update(ShipmentContainerTypeDataTransferObject shippingContainerTypeDataTransferObject);
    }
}
