using System;
using System.Collections.Generic;
using System.Text;
using DiunsaSCM.Core;
using DiunsaSCMInterfaceERP.Core.Entities;
using DiunsaSCMInterfaceERP.Core.Services;
using DiunsaSCMInterfaceERP.Core.Repositories;
using DiunsaSCM.Utils;

namespace DiunsaSCMInterfaceERP.Service
{
    public class ERPInventItemService : IERPInventItemService
    {
        private readonly IERPRepository<ERPInventItem> _repository;

        public ERPInventItemService(IERPRepository<ERPInventItem> repository)
        {
            _repository = repository;
        }

        public ServiceResult<ERPInventItem> Add(ERPInventItem eRPInventItem)
        {
            _repository.AddAsync(eRPInventItem);
            return ServiceResult<ERPInventItem>.SuccessResult(eRPInventItem);
        }

        public ServiceResult<IEnumerable<ERPInventItem>> GetAll(string searchString)
        {
            var eRPInventItem = _repository.All(searchString);
            return ServiceResult<IEnumerable<ERPInventItem>>.SuccessResult(eRPInventItem);
        }
    }
}
