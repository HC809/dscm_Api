using System;
using System.Collections.Generic;
using System.Text;
using DiunsaSCM.Core;
using DiunsaSCMInterfaceERP.Core.Entities;
using DiunsaSCMInterfaceERP.Core.Services;
using DiunsaSCMInterfaceERP.Core.Repositories;
using DiunsaSCM.Utils;

namespace DiunsaSCMInterfaceERP.Service
{
    public class ERPItemBarcodeService : IERPItemBarcodeService
    {
        private readonly IERPRepository<ERPItemBarcode> _repository;

        public ERPItemBarcodeService(IERPRepository<ERPItemBarcode> repository)
        {
            _repository = repository;
        }

        public ServiceResult<ERPItemBarcode> Add(ERPItemBarcode eRPItemBarcode)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<IEnumerable<ERPItemBarcode>> GetAll(string searchString)
        {
            var eRPItemBarcodes = _repository.All(searchString);
            return ServiceResult<IEnumerable<ERPItemBarcode>>.SuccessResult(eRPItemBarcodes);
        }
    }
}
