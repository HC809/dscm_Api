﻿using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;

namespace DiunsaSCM.Data.Repositories
{
    public class ExchangeRateRepository : RepositoryBase<ExchangeRate>, IExchangeRateRepository
    {
        public ExchangeRateRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}
