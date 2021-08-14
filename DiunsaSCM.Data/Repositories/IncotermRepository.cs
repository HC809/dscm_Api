using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;

namespace DiunsaSCM.Data
{
    public class IncotermRepository : RepositoryBase<Incoterm>, IIncotermRepository
    {
        public IncotermRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}