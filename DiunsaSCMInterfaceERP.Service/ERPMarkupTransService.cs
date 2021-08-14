using System;
using System.Collections.Generic;
using DiunsaSCMInterfaceERP.Core.Entities;
using DiunsaSCMInterfaceERP.Core.Repositories;
using DiunsaSCMInterfaceERP.Core.Services;

namespace DiunsaSCMInterfaceERP.Service
{
    public class ERPMarkupTransService : IERPMarkupTransService
    {
        private readonly IERPRepository<ERPMarkupTrans> _repository;

        public ERPMarkupTransService(IERPRepository<ERPMarkupTrans> repository)
        {
            _repository = repository;
        }

        public IEnumerable<ERPMarkupTrans> GetAll(string searchString)
        {
            var entities = _repository.All(searchString);
            return entities;

        }

        public ERPMarkupTrans GetById(long id)
        {
            var entity = _repository.GetById(id);
            return entity;
        }

        public IEnumerable<ERPMarkupTrans> GetAllByShipmentImport(long parent)
        {
            var entities = _repository.AllByParent(parent);
            return entities;

        }

    }
}
