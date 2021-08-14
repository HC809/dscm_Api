using System;
using DiunsaSCM.Core.Entities;
namespace DiunsaSCM.Core.Models
{
    public class InventItemStoreConfigurationDTO
    {
        public long Id { get; set; }
        public bool AllowToSell { get; set; }

        public long InventItemId { get; set; }

        public long StoreId { get; set; }
        public string StoreCode { get; set; }
        public string StoreDescription { get; set; }
    }
}