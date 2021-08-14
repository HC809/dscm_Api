using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Utils;

namespace DiunsaSCM.Core.Services
{
    public interface IPurchOrderShipmentDetailService
    {
        ServiceResult<PurchOrderShipmentDetailDataTransferObject> Add(PurchOrderShipmentDetailDataTransferObject purchOrderShipmentDetail);
        ServiceResult<PurchOrderShipmentDetailsListDataTransferObject> Add(PurchOrderShipmentDetailsListDataTransferObject purchOrderShipmentDetailsList);

        
        ServiceResult<IEnumerable<PurchOrderShipmentDetailDataTransferObject>> GetByPurchShipmentHeaderId(long purchShipmentHeaderId);
        
        ServiceResult<IEnumerable<PurchOrderShipmentDetailDataTransferObject>> GetAll();
        ServiceResult<PurchOrderShipmentDetailDataTransferObject> GetById(long id);
        ServiceResult<PurchOrderShipmentDetailDataTransferObject> Delete(long id);
        ServiceResult<PurchOrderShipmentDetailDataTransferObject> Update(PurchOrderShipmentDetailDataTransferObject purchOrderShipmentDetailDataTransferObject);
    }
}
