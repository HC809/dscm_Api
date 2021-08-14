using System;
using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Services;

namespace DiunsaSCM.Service
{
    public class ShipmentImportService : ServiceBase<ShipmentImport, ShipmentImportDTO>, IShipmentImportService
    {
        public ShipmentImportService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<ShipmentImport> repository)
            : base(mapper, unitOfWork, repository)
        {
        }
    }
}
