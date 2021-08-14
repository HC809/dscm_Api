using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;

namespace DiunsaSCM.Data
{   
    public class BarcodeRepository : RepositoryBase<Barcode>, IBarcodeRepository
    {
        public BarcodeRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}