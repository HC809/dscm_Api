using System;
using System.Collections.Generic;
using System.Text;
using DiunsaSCMInterfaceERP.Core;
using DiunsaSCMInterfaceERP.Core.Entities;
using DiunsaSCM.Utils;

namespace DiunsaSCMInterfaceERP.Core.Services
{
    public interface IERPInventItemService
    {
        ServiceResult<IEnumerable<ERPInventItem>> GetAll(string searchString);
        ServiceResult<ERPInventItem> Add(ERPInventItem eRPInventItem);
    }
}
