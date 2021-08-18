using System;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Utils;

namespace DiunsaSCM.Core.Services
{
    public interface IExchangeRateService : IServiceBase<ExchangeRateDTO>
    {
        ServiceResult<ExchangeRateDTO> CreateExchangeRate(ExchangeRateDTO model);
        ServiceResult<ExchangeRateDTO> UpdateExchangeRate(ExchangeRateDTO model);
    }
}
