using System;
using System.Collections.Generic;
using DiunsaSCMInterfaceERP.Core.Entities;

namespace DiunsaSCMInterfaceERP.Core.Services
{
    public interface IERPMarkupTransService
    {
        IEnumerable<ERPMarkupTrans> GetAll(string searchString);
        ERPMarkupTrans GetById(long id);
        IEnumerable<ERPMarkupTrans> GetAllByShipmentImport(long parent);
    }
}
