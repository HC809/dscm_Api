using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DiunsaSCM.Core;
using DiunsaSCMInterfaceERP.Core.Entities;
using DiunsaSCMInterfaceERP.Core.Services;
using DiunsaSCMInterfaceERP.Core.Repositories;
using DiunsaSCM.Utils;

namespace DiunsaSCMInterfaceERP.Service
{
    public class ERPPurchOrderDetailService : IERPPurchOrderDetailService
    {

        private readonly IERPRepository<ERPPurchOrderDetail> _repository;

        public ERPPurchOrderDetailService(IERPRepository<ERPPurchOrderDetail> repository)
        {
            _repository = repository;
        }

        public ServiceResult<IEnumerable<ERPPurchOrderDetail>> GetByPurchOrderHeaderId(long purchOrderHeaderId)
        {
            var eRPPurchOrderDetails = _repository.AllByParent(purchOrderHeaderId);
            return ServiceResult<IEnumerable<ERPPurchOrderDetail>>.SuccessResult(eRPPurchOrderDetails);
        }


        public async Task<ServiceResult<ERPPurchOrderDetail>> AddAsync(long purchOrderHeaderId, ERPPurchOrderDetail entity)
        {
            entity = await _repository.AddAsync(entity);
            entity = this.GetById(purchOrderHeaderId, entity.Id).Data;
            return ServiceResult<ERPPurchOrderDetail>.SuccessResult(entity);
        }

        public async Task<ServiceResult<ERPPurchOrderDetail>> DeleteAsync(long purchOrderHeaderId, long id)
        {
            var entity = this.GetById(purchOrderHeaderId, id).Data;
            object p = await _repository.DeleteAsync(entity.Id);
            return ServiceResult<ERPPurchOrderDetail>.SuccessResult(entity);
        }

        public ServiceResult<IEnumerable<ERPPurchOrderDetail>> GetAll()
        {
            var entity = _repository.All();
            return ServiceResult<IEnumerable<ERPPurchOrderDetail>>.SuccessResult(entity);

        }

        public ServiceResult<ERPPurchOrderDetail> GetById(long purchOrderHeaderId, long id)
        {
            var entity = _repository.GetById(id);
            return ServiceResult<ERPPurchOrderDetail>.SuccessResult(entity);
        }

        public async Task<ServiceResult<ERPPurchOrderDetail>> UpdateAsync(long purchOrderHeaderId, ERPPurchOrderDetail entity)
        {
            await _repository.UpdatAsync(entity);
            entity = this.GetById(purchOrderHeaderId, entity.Id).Data;
            return ServiceResult<ERPPurchOrderDetail>.SuccessResult(entity);
        }
    }
}
