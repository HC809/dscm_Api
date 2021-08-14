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
    public class SalesPriceDefinitionLineService : ServiceBase<SalesPriceDefinitionLine, SalesPriceDefinitionLineDTO>, ISalesPriceDefinitionLineService
    {
        public SalesPriceDefinitionLineService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<SalesPriceDefinitionLine> repository)
            : base(mapper, unitOfWork, repository)
        {
        }

        public virtual async Task<ServiceResult<IEnumerable<SalesPriceDefinitionLineDTO>>> GetAllByParentAsync(long parentId)
        {
            try
            {
                var entities = _repository.All()
                    .Where(x => x.SalesPriceDefinitionId == parentId);

                var entitieDTOs = entities.Select(x => _mapper.Map<SalesPriceDefinitionLineDTO>(x));

                return ServiceResult<IEnumerable<SalesPriceDefinitionLineDTO>>.SuccessResult(entitieDTOs);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<SalesPriceDefinitionLineDTO>>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }

        public ServiceResult<SalesPriceDefinitionLineListDTO> AddList(SalesPriceDefinitionLineListDTO modelList)
        {
            try
            {
                foreach (var model in modelList.SalesPriceDefinitionLineList)
                {
                    model.InventItemId = this.getInventItemId(model.InventItemCode);
                    model.CustomerPriceGroupId = this.getCustomerPriceGroupId(model.CustomerPriceGroupCode);
                    model.SalesPriceDefinitionId = modelList.SalesPriceDefinitionId;
                    var entity = _mapper.Map<SalesPriceDefinitionLine>(model);
                    _unitOfWork.SalesPriceDefinitionLines.Add(entity);
                }
                _unitOfWork.Complete();
                return ServiceResult<SalesPriceDefinitionLineListDTO>.SuccessResult(modelList);
            }
            catch (Exception ex)
            {
                return ServiceResult<SalesPriceDefinitionLineListDTO>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }

        }

        private long? getInventItemId(string code)
        {
            long? id = _unitOfWork.InventItems.All().FirstOrDefault(x => x.Code == code)?.Id;
            return id;
        }

        private long? getCustomerPriceGroupId(string code)
        {
            long? id = _unitOfWork.CustomerPriceGroups.All().FirstOrDefault(x => x.Code == code)?.Id;
            return id;
        }
    }
}
