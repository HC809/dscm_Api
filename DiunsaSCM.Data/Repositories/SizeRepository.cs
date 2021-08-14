using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;

namespace DiunsaSCM.Data
{
    public class SizeRepository : RepositoryBase<Size>, ISizeRepository
    {
        public SizeRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}