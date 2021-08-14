using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DiunsaSCMInterfaceERP.Core.Entities;
using DiunsaSCM.Utils;

namespace DiunsaSCMInterfaceERP.Core.Services
{
    public interface IERPPurchOrderHeaderService
    {
        ServiceResult<IEnumerable<ERPPurchOrderHeader>> GetAll(string searchString);
        Task<ServiceResult<ERPPurchOrderHeader>> AddAsync(ERPPurchOrderHeader eRPPurchOrderHeader);
        ServiceResult<ERPPurchOrderHeader> GetById(long id);
        Task<ServiceResult<ERPPurchOrderHeader>> DeleteAsync(long id);
        Task<ServiceResult<ERPPurchOrderHeader>> UpdateAsync(ERPPurchOrderHeader eRPPurchOrderHeader);
    }
}
