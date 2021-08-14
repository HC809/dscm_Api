using System;
using System.Collections.Generic;
using System.Text;

namespace DiunsaSCMInterfaceERP.Core.Entities
{
    public class ERPInventItem
    {
        public long Id { get; set; }
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public string NameAlias { get; set; }
        public string ItemGroupId { get; set; }

        public ERPInventItem()
        {
        }

        internal static void FromSqlRaw(string v)
        {
            throw new NotImplementedException();
        }
    }
}
