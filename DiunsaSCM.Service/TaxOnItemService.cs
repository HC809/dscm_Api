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
    public class TaxOnItemService : ServiceBase<TaxOnItem, TaxOnItemDTO>, ITaxOnItemService
    {
        public TaxOnItemService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<TaxOnItem> repository)
            : base(mapper, unitOfWork, repository)
        {
        }

        public virtual async Task<ServiceResult<IEnumerable<TaxOnItemDTO>>> GetAllByParentAsync(long parentId)
        {
            try {
                var taxOnItems = _repository.All()
                    .Where(x => x.TaxItemGroupHeadingId == parentId);

                var taxOnItemDTOs = taxOnItems.Select(x => _mapper.Map<TaxOnItemDTO>(x));

                return ServiceResult<IEnumerable<TaxOnItemDTO>>.SuccessResult(taxOnItemDTOs);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<TaxOnItemDTO>>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }
    }
}