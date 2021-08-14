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
    public class SalesPriceService : ServiceBase<SalesPrice, SalesPriceDTO>, ISalesPriceService
    {
        public SalesPriceService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<SalesPrice> repository)
            : base(mapper, unitOfWork, repository)
        {
        }

        public virtual async Task<ServiceResult<IEnumerable<SalesPriceDTO>>> GetAllByParentAsync(long parentId)
        {
            try
            {
                var entities = _repository.All()
                    .Include(x => x.CustomerPriceGroup)
                    .Where(x => x.InventItemId == parentId);

                var entitieDTOs = entities.Select(x => _mapper.Map<SalesPriceDTO>(x));

                return ServiceResult<IEnumerable<SalesPriceDTO>>.SuccessResult(entitieDTOs);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<SalesPriceDTO>>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }
    }
}
