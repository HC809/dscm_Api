using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;

namespace DiunsaSCM.Data
{
    public class SKUAnalysisRepository : RepositoryBase<SKUAnalysis>, ISKUAnalysisRepository
    {
        public SKUAnalysisRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}