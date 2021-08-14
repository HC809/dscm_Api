using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Utils;

namespace DiunsaSCM.Core.Services
{
    public interface IPurchOrderShipmentHeaderService 
    {
        ServiceResult<PurchOrderShipmentHeaderDataTransferObject> Add(PurchOrderShipmentHeaderDataTransferObject purchOrderShipmentHeader);
        ServiceResult<IEnumerable<PurchOrderShipmentHeaderDataTransferObject>> GetByPurchOrdertHeaderId(long purchOrdertHeaderId);
        ServiceResult<IEnumerable<PurchOrderShipmentHeaderDataTransferObject>> GetByShipmentImportId(long shipmentImportId);
        ServiceResult<IEnumerable<PurchOrderShipmentHeaderDataTransferObject>> GetAll(string searchString);
        ServiceResult<PurchOrderShipmentHeaderDataTransferObject> GetById(long id);
        ServiceResult<PurchOrderShipmentHeaderDataTransferObject> Delete(long id);
        ServiceResult<PurchOrderShipmentHeaderDataTransferObject> Update(PurchOrderShipmentHeaderDataTransferObject purchOrderShipmentHeader);
        ServiceResult<IEnumerable<PurchOrderShipmentHeaderDataTransferObject>> GetAllByFilterModel(FilterBaseDTO filterModel);
    }
}
