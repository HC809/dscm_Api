using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;

namespace DiunsaSCM.Data
{
    public class BarcodeSourceRepository : RepositoryBase<BarcodeSource>, IBarcodeSourceRepository
    {
        public BarcodeSourceRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}