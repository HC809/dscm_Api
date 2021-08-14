using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DiunsaSCMInterfaceERP.Core.Entities;

namespace DiunsaSCMInterfaceERP.Core.Services
{
    public interface IERPShipmentImportService
    {
        Task<ERPShipmentImport> AddAsync(ERPShipmentImport entity);
        Task<ERPShipmentImport> ExecuteActionAsync(long id, string action);
        IEnumerable<ERPShipmentImport> GetAll(string searchString);
        ERPShipmentImport GetById(long id);
        Task<ERPShipmentImport> DeleteAsync(long id);
        Task<ERPShipmentImport> UpdateAsync(ERPShipmentImport entity);
    }
}
