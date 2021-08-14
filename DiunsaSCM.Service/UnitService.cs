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
    public class UnitService : ServiceBase<Unit, UnitDTO>, IUnitService
    {
        public UnitService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<Unit> repository)
            : base(mapper, unitOfWork, repository)
        {
        }
    }
}