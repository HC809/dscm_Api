using System;
using System.Collections.Generic;
using System.Text;
using DiunsaSCM.Core;
using DiunsaSCMInterfaceERP.Core.Entities;
using DiunsaSCMInterfaceERP.Core.Services;
using DiunsaSCMInterfaceERP.Core.Repositories;
using DiunsaSCM.Utils;
using DiunsaSCMInterfaceERP.Core.Models;

namespace DiunsaSCMInterfaceERP.Service
{
    public class ERPSKUAnalysisService : IERPSKUAnalysisService
    {
        private readonly IERPRepository<ERPSKUAnalysis> _repository;

        public ERPSKUAnalysisService(IERPRepository<ERPSKUAnalysis> repository)
        {
            _repository = repository;
        }

        public ServiceResult<IEnumerable<ERPSKUAnalysis>> GetAll(string searchString)
        {
            var erpSKUAnalysis = _repository.All(searchString);
            return ServiceResult<IEnumerable<ERPSKUAnalysis>>.SuccessResult(erpSKUAnalysis);
        }

        public ServiceResult<IEnumerable<ERPSKUAnalysis>> GetAllByFilterModel(ERPFilterSKUAnalysisDTO filterModel)
        {
            var erpSKUAnalysis = _repository.AllByFilterModel(filterModel);
            return ServiceResult<IEnumerable<ERPSKUAnalysis>>.SuccessResult(erpSKUAnalysis);
        }
    }
}
