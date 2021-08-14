using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DiunsaSCM.Core;
using DiunsaSCMInterfaceERP.Core.Entities;
using DiunsaSCMInterfaceERP.Core.Services;
using DiunsaSCMInterfaceERP.Core.Repositories;
using DiunsaSCM.Utils;

namespace DiunsaSCMInterfaceERP.Service
{
    public class ERPPurchOrderHeaderService : IERPPurchOrderHeaderService
    {
        private readonly IERPRepository<ERPPurchOrderHeader> _repository;

        public ERPPurchOrderHeaderService(IERPRepository<ERPPurchOrderHeader> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult<ERPPurchOrderHeader>> AddAsync(ERPPurchOrderHeader eRPPurchOrderHeader)
        {
            eRPPurchOrderHeader = await _repository.AddAsync(eRPPurchOrderHeader);
            eRPPurchOrderHeader = this.GetById(eRPPurchOrderHeader.Id).Data;
            return ServiceResult<ERPPurchOrderHeader>.SuccessResult(eRPPurchOrderHeader);
        }

        public async Task<ServiceResult<ERPPurchOrderHeader>> DeleteAsync(long id)
        {
            var eRPPurchOrderHeader = this.GetById(id).Data;
            object p = await _repository.DeleteAsync(eRPPurchOrderHeader.Id);
            return ServiceResult<ERPPurchOrderHeader>.SuccessResult(eRPPurchOrderHeader);
        }

        public ServiceResult<IEnumerable<ERPPurchOrderHeader>> GetAll(string searchString)
        {
            var eRPurchOrderHeaders = _repository.All(searchString);
            return ServiceResult<IEnumerable<ERPPurchOrderHeader>>.SuccessResult(eRPurchOrderHeaders);

        }

        public ServiceResult<ERPPurchOrderHeader> GetById(long id)
        {
            var eRPurchOrderHeader = _repository.GetById(id);
            return ServiceResult<ERPPurchOrderHeader>.SuccessResult(eRPurchOrderHeader);
        }

        public async Task<ServiceResult<ERPPurchOrderHeader>> UpdateAsync(ERPPurchOrderHeader eRPPurchOrderHeader)
        {
            await _repository.UpdatAsync(eRPPurchOrderHeader);
            eRPPurchOrderHeader = this.GetById(eRPPurchOrderHeader.Id).Data;
            return ServiceResult<ERPPurchOrderHeader>.SuccessResult(eRPPurchOrderHeader);
        }

    }
}
