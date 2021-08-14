using System;
using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Services;
using DiunsaSCM.Utils;

namespace DiunsaSCM.Service
{
    public class BarcodeSourceService : ServiceBase<BarcodeSource, BarcodeSourceDTO>, IBarcodeSourceService
    {
        public BarcodeSourceService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<BarcodeSource> repository)
            : base(mapper, unitOfWork, repository)
        {
        }

        public override ServiceResult<BarcodeSourceDTO> Add(BarcodeSourceDTO model)
        {
            try
            {
                model.NextAvailable = model.RangeFirst;
                var entity = _mapper.Map<BarcodeSource>(model);
                entity = _repository.Add(entity);
                _repository.SaveChanges();
                model = _mapper.Map<BarcodeSourceDTO>(entity);
                return ServiceResult<BarcodeSourceDTO>.SuccessResult(model);
            }
            catch (Exception ex)
            {
                return ServiceResult<BarcodeSourceDTO>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos.");
            }
        }
    }
}
