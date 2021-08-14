using System;
using System.Collections.Generic;
using System.Text;
using DiunsaSCMInterfaceERP.Core;
using DiunsaSCMInterfaceERP.Core.Entities;
using DiunsaSCMInterfaceERP.Core.Repositories;
using DiunsaSCM.Utils;

namespace DiunsaSCMInterfaceERP.Core.Services
{
    
    public interface IERPVendorService
    {

        ServiceResult<IEnumerable<ERPVendor>> GetAll();
        ServiceResult<ERPVendor> Add(ERPVendor eRPVendor);
    }
}
