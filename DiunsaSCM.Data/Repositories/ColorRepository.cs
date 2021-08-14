using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;

namespace DiunsaSCM.Data
{
    public class ColorRepository : RepositoryBase<Color>, IColorRepository
    {
        public ColorRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}