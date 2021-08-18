using System;
using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using DiunsaSCM.Utils;

namespace DiunsaSCM.Service
{
    public class ExchangeRateService : ServiceBase<ExchangeRate, ExchangeRateDTO>, IExchangeRateService
    {
        public ExchangeRateService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<ExchangeRate> repository)
            : base(mapper, unitOfWork, repository)
        {
        }

        public ServiceResult<ExchangeRateDTO> CreateExchangeRate(ExchangeRateDTO model)
        {
            try
            {
                List<ExchangeRate> marchingdDates = _unitOfWork.ExchangeRate.All()
                    .Where(x => x.CurrencyCode == model.CurrencyCode && ((model.StartDate >= x.StartDate && model.StartDate <= x.EndDate)
                    || (model.EndDate >= x.StartDate && model.EndDate <= x.EndDate)))
                    .ToList();

                if (marchingdDates.Count > 0)
                    return ServiceResult<ExchangeRateDTO>.ErrorResult($"El rango de fechas ingresado coincide con las de otro(s) registro(s) para el tipo de moneda {model.CurrencyCode}.");

                _unitOfWork.ExchangeRate.Add(_mapper.Map<ExchangeRateDTO, ExchangeRate>(model));
                _unitOfWork.Complete();

                return ServiceResult<ExchangeRateDTO>.SuccessResult(model);
            }
            catch (Exception ex)
            {
                return ServiceResult<ExchangeRateDTO>.ErrorResult($"Ha ocurrido un error al ejecutar la operación en la base de datos. Error: {ex.InnerException.Message}");
            }
        }

        public ServiceResult<ExchangeRateDTO> UpdateExchangeRate(ExchangeRateDTO model)
        {
            try
            {
                List<ExchangeRate> marchingdDates = _unitOfWork.ExchangeRate.All()
                    .Where(x => x.Id != model.Id && x.CurrencyCode == model.CurrencyCode && ((model.StartDate >= x.StartDate && model.StartDate <= x.EndDate)
                    || (model.EndDate >= x.StartDate && model.EndDate <= x.EndDate)))
                    .ToList();

                if (marchingdDates.Count > 0)
                    return ServiceResult<ExchangeRateDTO>.ErrorResult($"El rango de fechas ingresado coincide con las de otro(s) registro(s) para el tipo de moneda {model.CurrencyCode}.");

                _unitOfWork.ExchangeRate.Update(_mapper.Map<ExchangeRateDTO, ExchangeRate>(model));
                _unitOfWork.Complete();

                return ServiceResult<ExchangeRateDTO>.SuccessResult(model);
            }
            catch (Exception ex)
            {
                return ServiceResult<ExchangeRateDTO>.ErrorResult($"Ha ocurrido un error al ejecutar la operación en la base de datos. Error: {ex.InnerException.Message}");
            }
        }

    }
}
