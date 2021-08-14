using System;
using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Services;

namespace DiunsaSCM.Service
{
    public class WarehouseService : ServiceBase<Warehouse, WarehouseDTO>, IWarehouseService
    {
        public WarehouseService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<Warehouse> repository)
            : base(mapper, unitOfWork, repository)
        {
        }
    }
}
