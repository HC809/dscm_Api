using System;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;

namespace DiunsaSCM.Data.Repositories
{
    public class ShippingStepTypeRepository : Repository<ShippingStepType>, IShippingStepTypeRepository
    {
        public ShippingStepTypeRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}
