using System;
using System.Collections.Generic;
using System.Linq;
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
    public class SalesPriceDefinitionService : ServiceBase<SalesPriceDefinition, SalesPriceDefinitionDTO>, ISalesPriceDefinitionService
    {
        public SalesPriceDefinitionService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<SalesPriceDefinition> repository)
            : base(mapper, unitOfWork, repository)
        {
        }

        public ServiceResult<SalesPriceDefinitionDTO> Update(SalesPriceDefinitionDTO model)
        {
            try
            {
                var entity = _mapper.Map<SalesPriceDefinition>(model);

                if (entity.SalesPriceDefinitionStatus == Core.Enums.SalesPriceDefinitionStatus.Completed)
                {
                    var newSalesPrices = new List<SalesPrice>();

                    var salesPriceDefinitionLines = _unitOfWork.SalesPriceDefinitionLines.All()
                        .Where(x => x.SalesPriceDefinitionId == entity.Id && x.InventItemId != null && x.CustomerPriceGroupId!=null)
                        .ToList();

                    foreach (var salesPriceDefinitionLine in salesPriceDefinitionLines)
                    {
                        var salesPrice = _unitOfWork.SalesPrices.All()
                            .FirstOrDefault(x => x.CustomerPriceGroupId == salesPriceDefinitionLine.CustomerPriceGroupId
                                && x.InventItemId == salesPriceDefinitionLine.InventItemId);

                        if (salesPrice == null)
                        {
                            salesPrice = newSalesPrices.FirstOrDefault(x => x.CustomerPriceGroupId == salesPriceDefinitionLine.CustomerPriceGroupId
                                && x.InventItemId == salesPriceDefinitionLine.InventItemId);
                        }

                        if (salesPrice == null)
                        {
                            salesPrice = new SalesPrice();
                            salesPrice.CustomerPriceGroupId = salesPriceDefinitionLine.CustomerPriceGroupId.GetValueOrDefault();
                            salesPrice.InventItemId = salesPriceDefinitionLine.InventItemId.GetValueOrDefault();
                            _unitOfWork.SalesPrices.Add(salesPrice);
                            newSalesPrices.Add(salesPrice);
                        }
                        salesPrice.Price = salesPriceDefinitionLine.Price;

                        InventItem inventItem = _unitOfWork.InventItems.GetById(salesPriceDefinitionLine.InventItemId.GetValueOrDefault());
                        inventItem.EstimatedCost = salesPriceDefinitionLine.EstimatedCost;
                        inventItem.EstimatedCostDate = DateTime.Now;
                        _unitOfWork.InventItems.Update(inventItem);
                    }
                    
                    entity.SalesPriceDefinitionStatus = Core.Enums.SalesPriceDefinitionStatus.Closed;
                }
                
                entity = _repository.Update(entity);
                _repository.SaveChanges();

                return ServiceResult<SalesPriceDefinitionDTO>.SuccessResult(model);
            }
            catch (Exception ex)
            {
                return ServiceResult<SalesPriceDefinitionDTO>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos.");
            }
        }

    }
}
