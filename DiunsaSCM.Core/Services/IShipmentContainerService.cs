using System;
using System.Collections.Generic;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Utils;

namespace DiunsaSCM.Core.Services
{
    public interface IShipmentContainerService
    {
        ServiceResult<ShipmentContainerDataTransferObject> Add(ShipmentContainerDataTransferObject shipmentContainer);
        ServiceResult<IEnumerable<ShipmentContainerDataTransferObject>> GetByPurchOrderShipmentHeaderId(long purchOrderShipmentHeaderId);
        ServiceResult<ShipmentContainerDataTransferObject> GetById(long id);
        ServiceResult<ShipmentContainerDataTransferObject> Delete(long id);
        ServiceResult<ShipmentContainerDataTransferObject> Update(ShipmentContainerDataTransferObject shipmentContainer);

        ServiceResult<ShipmentContainerDetailDataTransferObject> AddLine(ShipmentContainerDetailDataTransferObject shipmentContainerDetail);
        ServiceResult<ShipmentContainerDetailsListDataTransferObject> AddLineList(ShipmentContainerDetailsListDataTransferObject shipmentContainerDetailsList);
        ServiceResult<ShipmentContainerDetailDataTransferObject> DeleteLine(long id, long shipmentContainerDetailId);
        ServiceResult<ShipmentContainerDetailDataTransferObject> UpdateLine(long id, ShipmentContainerDetailDataTransferObject shipmentContainer);
        ServiceResult<ShipmentContainerDetailDataTransferObject> GetLine(long id, long shipmentContainerDetailId);
        ServiceResult<IEnumerable<ShipmentContainerDetailDataTransferObject>> GetLines(long id);
    }
}
