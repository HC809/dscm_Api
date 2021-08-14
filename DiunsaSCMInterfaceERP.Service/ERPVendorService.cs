using System;
using System.Collections.Generic;
using System.Text;
using DiunsaSCM.Core;
using DiunsaSCMInterfaceERP.Core;
using DiunsaSCMInterfaceERP.Core.Entities;
using DiunsaSCMInterfaceERP.Core.Services;
using DiunsaSCMInterfaceERP.Core.Repositories;
using DiunsaSCM.Utils;

namespace DiunsaSCMInterfaceERP.Service
{
    public class ERPVendorService : IERPVendorService
    {

        private readonly IERPRepository<ERPVendor> _repository;

        public ERPVendorService(IERPRepository<ERPVendor> repository)
        {
            _repository = repository;
        }

        public ServiceResult<ERPVendor> Add(ERPVendor eRPVendor)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<IEnumerable<ERPVendor>> GetAll()
        {
            var eRPVendors = _repository.All();
            return ServiceResult<IEnumerable<ERPVendor>>.SuccessResult(eRPVendors);
        }
    }
}
