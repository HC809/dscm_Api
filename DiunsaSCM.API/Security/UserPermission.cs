using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiunsaSCM.API.Security
{
    public class UserPermission
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public long ApplicationId { get; set; }
    }
}
