using System;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;

namespace DiunsaSCM.Data.Repositories
{
    public class ShippingCompanyRepository : Repository<ShippingCompany>, IShippingCompanyRepository
    {
        public ShippingCompanyRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}
