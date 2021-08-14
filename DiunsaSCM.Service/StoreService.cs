using System;
using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Services;

namespace DiunsaSCM.Service
{
    public class StoreService : ServiceBase<Store, StoreDTO>, IStoreService
    {
        public StoreService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<Store> repository)
            : base(mapper, unitOfWork, repository)
        {
        }
    }
}