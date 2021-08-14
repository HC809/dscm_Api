using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;

namespace DiunsaSCM.Data
{
    public class CommercialAgreementRepository : RepositoryBase<CommercialAgreement>, ICommercialAgreementRepository
    {
        public CommercialAgreementRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}