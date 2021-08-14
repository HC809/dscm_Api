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
    public class BarcodeService : ServiceBase<Barcode, BarcodeDTO>, IBarcodeService
    {
        public BarcodeService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<Barcode> repository)
            : base(mapper, unitOfWork, repository)
        {
        }

        public virtual async Task<ServiceResult<IEnumerable<BarcodeDTO>>> GetAllByParentAsync(long parentId)
        {
            try
            {
                var entities = _repository.All()
                    .Where(x => x.BarcodeBatchId == parentId);

                var entitieDTOs = entities.Select(x => _mapper.Map<BarcodeDTO>(x));

                return ServiceResult<IEnumerable<BarcodeDTO>>.SuccessResult(entitieDTOs);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<BarcodeDTO>>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }
    }
}
