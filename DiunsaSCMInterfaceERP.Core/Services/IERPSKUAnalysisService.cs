using System;
using System.Collections.Generic;
using System.Text;
using DiunsaSCMInterfaceERP.Core;
using DiunsaSCMInterfaceERP.Core.Entities;
using DiunsaSCM.Utils;
using DiunsaSCMInterfaceERP.Core.Models;

namespace DiunsaSCMInterfaceERP.Core.Services
{
    public interface IERPSKUAnalysisService
    {
        ServiceResult<IEnumerable<ERPSKUAnalysis>> GetAll(string searchString);

        ServiceResult<IEnumerable<ERPSKUAnalysis>> GetAllByFilterModel(ERPFilterSKUAnalysisDTO filterDTO);
    }
}
