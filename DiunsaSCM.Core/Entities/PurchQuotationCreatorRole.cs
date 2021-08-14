using System;
namespace DiunsaSCM.Core.Entities
{
    public class PurchQuotationCreatorRole
    {
        public long Id { get; set; }
        public long PurchQuotationCreatorId { get; set; }
        public long PurchRoleId { get; set; }

        public virtual PurchQuotationCreator PurchQuotationCreator { get; set; }
        public virtual PurchRole PurchRole { get; set; }
    }
}
