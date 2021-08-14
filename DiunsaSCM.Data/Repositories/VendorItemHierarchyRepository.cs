using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;

namespace DiunsaSCM.Data
{
    public class VendorItemHierarchyRepository : RepositoryBase<VendorItemHierarchy>, IVendorItemHierarchyRepository
    {
        public VendorItemHierarchyRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}