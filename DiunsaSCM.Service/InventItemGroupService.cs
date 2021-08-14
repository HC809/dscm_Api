using System;
using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Services;

namespace DiunsaSCM.Service
{
    public class InventItemGroupService : ServiceBase<InventItemGroup, InventItemGroupDTO>, IInventItemGroupService
    {
        public InventItemGroupService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<InventItemGroup> repository)
            : base(mapper, unitOfWork, repository)
        {
        }
    }
}