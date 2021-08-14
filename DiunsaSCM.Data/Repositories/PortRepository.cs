using System;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;

namespace DiunsaSCM.Data.Repositories
{
    public class PortRepository : Repository<Port>, IPortRepository
    {
        public PortRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}
