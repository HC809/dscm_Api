using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DiunsaSCMInterfaceERP.Core.Entities;
using DiunsaSCM.Utils;

namespace DiunsaSCMInterfaceERP.Core.Services
{
    public interface IERPPurchOrderDetailService
    {
        ServiceResult<IEnumerable<ERPPurchOrderDetail>> GetAll();
        ServiceResult<IEnumerable<ERPPurchOrderDetail>> GetByPurchOrderHeaderId(long purchOrderHeaderId);
        Task<ServiceResult<ERPPurchOrderDetail>> AddAsync(long purchOrderHeaderId, ERPPurchOrderDetail eRPPurchOrderDetails);
        ServiceResult<ERPPurchOrderDetail> GetById(long purchOrderHeaderId, long id);
        Task<ServiceResult<ERPPurchOrderDetail>> DeleteAsync(long purchOrderHeaderId, long id);
        Task<ServiceResult<ERPPurchOrderDetail>> UpdateAsync(long purchOrderHeaderId, ERPPurchOrderDetail eRPPurchOrderDetails);
    }
}
