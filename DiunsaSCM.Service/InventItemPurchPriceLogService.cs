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
using Microsoft.EntityFrameworkCore;

namespace DiunsaSCM.Service
{
    public class InventItemPurchPriceLogService : ServiceBase<InventItemPurchPriceLog, InventItemPurchPriceLogDTO>, IInventItemPurchPriceLogService
    {
        public InventItemPurchPriceLogService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<InventItemPurchPriceLog> repository)
            : base(mapper, unitOfWork, repository)
        {
        }

        public virtual async Task<ServiceResult<IEnumerable<InventItemPurchPriceLogDTO>>> GetAllByParentAsync(long parentId)
        {
            try
            {
                var entities = _repository.All()
                    .Include(x => x.PurchQuotationLine)
                    .ThenInclude(x => x.PurchQuotation)
                    .Where(x => x.InventItemId == parentId);

                var entitieDTOs = entities.Select(x => _mapper.Map<InventItemPurchPriceLogDTO>(x));

                return ServiceResult<IEnumerable<InventItemPurchPriceLogDTO>>.SuccessResult(entitieDTOs);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<InventItemPurchPriceLogDTO>>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }
    }
}
