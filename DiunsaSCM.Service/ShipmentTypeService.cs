using System;
using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Services;
using DiunsaSCM.Service;

namespace DiunsaSCM.Service
{
    public class ShipmentTypeService : ServiceBase<ShipmentType, ShipmentTypeDTO>, IShipmentTypeService
    {
        public ShipmentTypeService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<ShipmentType> repository)
            : base(mapper, unitOfWork, repository)
        {
        }
    }
}