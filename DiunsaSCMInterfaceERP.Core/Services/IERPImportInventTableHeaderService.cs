using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DiunsaSCM.Utils;
using DiunsaSCMInterfaceERP.Core.Entities;

namespace DiunsaSCMInterfaceERP.Core.Services
{
    public interface IERPImportInventTableService
    {
        Task<ServiceResult<ERPImportInventTableHeader>> AddAsync(ERPImportInventTableHeader entity);
        Task<ServiceResult<ERPImportInventTableHeader>> ExecuteActionAsync(long id, string action);
    }
}
