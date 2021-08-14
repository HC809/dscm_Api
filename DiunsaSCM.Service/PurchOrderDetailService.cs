using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Services;
using DiunsaSCM.Utils;

namespace DiunsaSCM.Service
{
    public class PurchOrderDetailService : ServiceBase<PurchOrderDetail, PurchOrderDetailDTO>, IPurchOrderDetailService
    {
        public PurchOrderDetailService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<PurchOrderDetail> repository)
            : base(mapper, unitOfWork, repository)
        {
        }

        public virtual async Task<ServiceResult<IEnumerable<PurchOrderDetailDTO>>> GetAllByParentAsync(long parentId)
        {
            try
            {
                var entities = _repository.All()
                    .Where(x => x.PurchOrderHeaderId == parentId);

                var entitieDTOs = entities.Select(x => _mapper.Map<PurchOrderDetailDTO>(x));

                return ServiceResult<IEnumerable<PurchOrderDetailDTO>>.SuccessResult(entitieDTOs);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<PurchOrderDetailDTO>>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }
        /*
        public ServiceResult<PurchOrderDetailDTO> Update(PurchOrderDetailDTO model)
        {
            try
            {
                var entity = _mapper.Map<PurchOrderDetail>(model);
                entity.LineAmount = entity.QtyOrdered * entity.PurchPrice;
                entity = _repository.Update(entity);
                _repository.SaveChanges();
                return ServiceResult<PurchOrderDetailDTO>.SuccessResult(model);
            }
            catch (Exception ex)
            {
                return ServiceResult<PurchOrderDetailDTO>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos.");
            }
        }*/
    }
}
