using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;

namespace DiunsaSCM.Data
{
    public class EmployeeDiscountRepository : RepositoryBase<EmployeeDiscount>, IEmployeeDiscountRepository
    {
        public EmployeeDiscountRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}