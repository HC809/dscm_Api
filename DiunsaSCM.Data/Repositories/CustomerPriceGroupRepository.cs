using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;

namespace DiunsaSCM.Data
{
    public class CustomerPriceGroupRepository : RepositoryBase<CustomerPriceGroup>, ICustomerPriceGroupRepository
    {
        public CustomerPriceGroupRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}