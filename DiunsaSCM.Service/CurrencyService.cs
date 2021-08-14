using System;
using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Services;

namespace DiunsaSCM.Service
{
    public class CurrencyService : ServiceBase<Currency, CurrencyDTO>, ICurrencyService
    {
        public CurrencyService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<Currency> repository)
            : base(mapper, unitOfWork, repository)
        {
        }
    }
}
