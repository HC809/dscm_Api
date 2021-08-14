using System;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Utils;

namespace DiunsaSCM.Core.Services
{
    public interface IImportInventTableHeaderService
    {
        ServiceResult<ImportInventTableHeaderDTO> AddList(ImportInventTableHeaderDTO modelList);
    }
}