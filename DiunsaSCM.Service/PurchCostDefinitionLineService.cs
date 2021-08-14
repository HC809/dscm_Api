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
    public class PurchCostDefinitionLineService : ServiceBase<PurchCostDefinitionLine, PurchCostDefinitionLineDTO>, IPurchCostDefinitionLineService
    {
        public PurchCostDefinitionLineService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<PurchCostDefinitionLine> repository)
            : base(mapper, unitOfWork, repository)
        {
        }

        public virtual async Task<ServiceResult<IEnumerable<PurchCostDefinitionLineDTO>>> GetAllByParentAsync(long parentId)
        {
            try
            {
                var entities = _repository.All()
                    .Where(x => x.PurchCostDefinitionId == parentId)
                    .OrderBy(x => x.LineNumber);

                var entitieDTOs = entities.Select(x => _mapper.Map<PurchCostDefinitionLineDTO>(x));

                return ServiceResult<IEnumerable<PurchCostDefinitionLineDTO>>.SuccessResult(entitieDTOs);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<PurchCostDefinitionLineDTO>>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }

        public ServiceResult<PurchCostDefinitionLineListDTO> AddList(PurchCostDefinitionLineListDTO modelList)
        {
            try
            {
                foreach (var model in modelList.PurchCostDefinitionLineList)
                {
                    model.PurchCostDefinitionId = modelList.PurchCostDefinitionId;
                    var entity = _mapper.Map<PurchCostDefinitionLine>(model);
                    _unitOfWork.PurchCostDefinitionLines.Add(entity);
                }
                _unitOfWork.Complete();
                return ServiceResult<PurchCostDefinitionLineListDTO>.SuccessResult(modelList);
            }
            catch (Exception ex)
            {
                return ServiceResult<PurchCostDefinitionLineListDTO>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }
    }
}
