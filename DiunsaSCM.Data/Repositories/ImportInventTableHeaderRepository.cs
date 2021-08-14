using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;

namespace DiunsaSCM.Data
{
    public class ImportInventTableHeaderRepository : RepositoryBase<ImportInventTableHeader>, IImportInventTableHeaderRepository
    {
        public ImportInventTableHeaderRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}