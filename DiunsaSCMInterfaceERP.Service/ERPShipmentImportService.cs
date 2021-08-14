using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DiunsaSCMInterfaceERP.Core.Entities;
using DiunsaSCMInterfaceERP.Core.Repositories;
using DiunsaSCMInterfaceERP.Core.Services;

namespace DiunsaSCMInterfaceERP.Service
{
    public class ERPShipmentImportService : IERPShipmentImportService
    {
        private readonly IERPRepository<ERPShipmentImport> _repository;

        public ERPShipmentImportService(IERPRepository<ERPShipmentImport> repository)
        {
            _repository = repository;
        }

        public async Task<ERPShipmentImport> AddAsync(ERPShipmentImport entity)
        {
            entity = await _repository.AddAsync(entity);
            entity = this.GetById(entity.ERPRecId);
            return entity;
        }

        public Task<ERPImportInventTableHeader> AddAsync(ERPImportInventTableHeader entity)
        {
            throw new NotImplementedException();
        }

        public async Task<ERPShipmentImport> DeleteAsync(long id)
        {
            var entity = this.GetById(id);
            object p = await _repository.DeleteAsync(entity.ERPRecId);
            return entity;
        }

        public Task<ERPImportInventTableHeader> ExecuteActionAsync(long id, string action)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ERPShipmentImport> GetAll(string searchString)
        {
            var entities = _repository.All(searchString);
            return entities;

        }

        public ERPShipmentImport GetById(long id)
        {
            var entity = _repository.GetById(id);
            return entity;
        }

        public async Task<ERPShipmentImport> UpdateAsync(ERPShipmentImport entity)
        {
            await _repository.UpdatAsync(entity);
            entity = this.GetById(entity.ERPRecId);
            return entity;
        }

        Task<ERPShipmentImport> IERPShipmentImportService.ExecuteActionAsync(long id, string action)
        {
            throw new NotImplementedException();
        }

    }
}
