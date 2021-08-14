using System;
using System.Collections.Generic;
using System.Text;
using DiunsaSCMInterfaceERP.Core.Entities;
using DiunsaSCM.Utils;

namespace DiunsaSCMInterfaceERP.Core.Services
{
    public interface IERPItemBarcodeService
    {

        ServiceResult<IEnumerable<ERPItemBarcode>> GetAll(string searchString);
        ServiceResult<ERPItemBarcode> Add(ERPItemBarcode eRPItemBarcode);
    }
}
