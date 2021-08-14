using System;
using System.Collections.Generic;

namespace DiunsaSCM.Core.Entities
{
    public class PurchQuotationCreator
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public virtual IEnumerable<PurchQuotationCreatorRole> PurchQuotationCreatorRoles { get; set; }
    }
}
