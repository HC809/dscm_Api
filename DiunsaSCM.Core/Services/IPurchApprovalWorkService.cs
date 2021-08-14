using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Utils;

namespace DiunsaSCM.Core.Services
{
    public interface IPurchApprovalWorkService
    {
        Task<ServiceResult<IEnumerable<PurchApprovalWorkDTO>>> GetAllAsync(string username, string searchString = "", int slice = 0);
    }
}
