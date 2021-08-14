using System;
using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Services;

namespace DiunsaSCM.Service
{
    public class PurchRoleService : ServiceBase<PurchRole, PurchRoleDTO>, IPurchRoleService
    {
        public PurchRoleService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<PurchRole> repository)
            : base(mapper, unitOfWork, repository)
        {
        }
    }
}
