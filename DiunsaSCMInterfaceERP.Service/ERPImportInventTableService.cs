using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DiunsaSCM.Core;
using DiunsaSCMInterfaceERP.Core;
using DiunsaSCMInterfaceERP.Data;
using DiunsaSCMInterfaceERP.Core.Entities;
using DiunsaSCMInterfaceERP.Core.Services;
using DiunsaSCMInterfaceERP.Core.Repositories;
using DiunsaSCM.Utils;

namespace DiunsaSCMInterfaceERP.Service
{
    public class ERPImportInventTableService : IERPImportInventTableService
    {
        private IERPRepository<ERPImportInventTableHeader> _repository;
        private IERPRepository<ERPImportInventTableLine> _eRPImportInventTableLine;

        public ERPImportInventTableService(IERPRepository<ERPImportInventTableHeader> repository, IERPRepository<ERPImportInventTableLine> eRPImportInventTableLine)
        {
            this._repository = repository;
            this._eRPImportInventTableLine = eRPImportInventTableLine;
        }

        public async Task<ServiceResult<ERPImportInventTableHeader>> AddAsync(ERPImportInventTableHeader entity)
        {
            entity = await _repository.AddAsync(entity);
            foreach (ERPImportInventTableLine line in entity.ERPImportInventTableLines)
            {
                line.ParentRecId = entity.Id;
                await _eRPImportInventTableLine.AddAsync(line);
            }
            return ServiceResult<ERPImportInventTableHeader>.SuccessResult(entity);
        }

        public async Task<ServiceResult<ERPImportInventTableHeader>> ExecuteActionAsync(long id, string action)
        {
            object[] args = { id };
            var entity = await _repository.ExecuteActionAsync(action, args);
            return ServiceResult<ERPImportInventTableHeader>.SuccessResult(new ERPImportInventTableHeader());

        }
    }
}
