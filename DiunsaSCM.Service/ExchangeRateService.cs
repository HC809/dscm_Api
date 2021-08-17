using System;
using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Services;

namespace DiunsaSCM.Service
{
    public class ExchangeRateService : ServiceBase<ExchangeRate, ExchangeRateDTO>, IExchangeRateService
    {
        public ExchangeRateService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<ExchangeRate> repository)
            : base(mapper, unitOfWork, repository)
        {
        }
    }
}
