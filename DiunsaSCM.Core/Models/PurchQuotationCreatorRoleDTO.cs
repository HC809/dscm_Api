using System;
using DiunsaSCM.Core.Entities;
namespace DiunsaSCM.Core.Models
{
    public class PurchQuotationCreatorRoleDTO
    {
        public long Id { get; set; }
        public long PurchQuotationCreatorId { get; set; }
        public long PurchRoleId { get; set; }

        public string PurchRoleCode { get; set; }
        public string PurchRoleDescription { get; set; }
    }
}