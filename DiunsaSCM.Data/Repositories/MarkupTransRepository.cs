using System.Linq;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;

namespace DiunsaSCM.Data
{
    public class MarkupTransRepository : RepositoryBase<MarkupTrans>, IMarkupTransRepository
    {
        public MarkupTransRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}