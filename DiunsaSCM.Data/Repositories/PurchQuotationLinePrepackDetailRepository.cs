using System.Linq;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DiunsaSCM.Data
{
    public class PurchQuotationLinePrepackDetailRepository : RepositoryBase<PurchQuotationLinePrepackDetail>, IPurchQuotationLinePrepackDetailRepository
    {
        public PurchQuotationLinePrepackDetailRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}