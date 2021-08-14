using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;

namespace DiunsaSCM.Data
{
    public class InventItemPrepackBarcodeRepository : RepositoryBase<InventItemPrepackBarcode>, IInventItemPrepackBarcodeRepository
    {
        public InventItemPrepackBarcodeRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}