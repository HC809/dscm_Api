using System;
using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Services;
using DiunsaSCM.Utils;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using DiunsaSCM.Data;

namespace DiunsaSCM.Service
{
    public class PurchQuotationLinePrepackDetailService : ServiceBase<PurchQuotationLinePrepackDetail, PurchQuotationLinePrepackDetailDTO>, IPurchQuotationLinePrepackDetailService
    {
        public PurchQuotationLinePrepackDetailService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<PurchQuotationLinePrepackDetail> repository)
            : base(mapper, unitOfWork, repository)
        {
        }

        public virtual async Task<ServiceResult<IEnumerable<PurchQuotationLinePrepackDetailDTO>>> GetAllByParentAsync(long parentId)
        {
            try
            {
                var entities = _repository.All()
                    .Include(x => x.InventItem)
                    .Include(x => x.Color)
                    .Include(x => x.Size)
                    .Include(x => x.ItemBarcode)
                    .Include(x => x.PurchQuotationLine)
                    .Where(x => x.PurchQuotationLineId == parentId)
                    .OrderBy(x => x.Id);
                var entitieDTOs = entities.Select(x => _mapper.Map<PurchQuotationLinePrepackDetailDTO>(x));

                return ServiceResult<IEnumerable<PurchQuotationLinePrepackDetailDTO>>.SuccessResult(entitieDTOs);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<PurchQuotationLinePrepackDetailDTO>>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }

        public ServiceResult<PurchQuotationLinePrepackDetailDTO> Update(PurchQuotationLinePrepackDetailDTO model)
        {
            try
            {
                var purchQuotationLine = _unitOfWork.PurchQuotationLines.All()
                    .Include(x => x.PurchQuotationLinePrepackDetails)
                    .FirstOrDefault(x => x.Id == model.PurchQuotationLineId);

                var entity = purchQuotationLine.PurchQuotationLinePrepackDetails.FirstOrDefault(x => x.Id == model.Id);
                entity.PurchPrice = model.PurchPrice;
                purchQuotationLine.SetPurchPrice();

                _unitOfWork.PurchQuotationLinePrepackDetails.Update(entity);
                _unitOfWork.PurchQuotationLines.Update(purchQuotationLine);
                _unitOfWork.Complete();

                return ServiceResult<PurchQuotationLinePrepackDetailDTO>.SuccessResult(model);
            }
            catch (Exception ex)
            {
                return ServiceResult<PurchQuotationLinePrepackDetailDTO>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos.");
            }
        }
    }
}
