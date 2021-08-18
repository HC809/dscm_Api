using System;
using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Services;

namespace DiunsaSCM.Service
{
    public class SuppliesService : ServiceBase<Supplies, SuppliesDTO>, ISuppliesService
    {
        public SuppliesService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<Supplies> repository)
          : base(mapper, unitOfWork, repository)
        {
        }
    }
}
