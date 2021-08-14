using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Entities;

namespace DiunsaSCM.Data.Repositories
{
    public class ItemBarcodeRepository : RepositoryBase<ItemBarcode>, IItemBarcodeRepository
    {
        public ItemBarcodeRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}
