using System;
using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Services;

namespace DiunsaSCM.Service
{
    public class InventModelGroupService : ServiceBase<InventModelGroup, InventModelGroupDTO>, IInventModelGroupService
    {
        public InventModelGroupService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<InventModelGroup> repository)
            : base(mapper, unitOfWork, repository)
        {
        }
    }
}
