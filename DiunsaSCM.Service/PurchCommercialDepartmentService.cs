using System;
using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Services;

namespace DiunsaSCM.Service
{
    public class PurchCommercialDepartmentService : ServiceBase<PurchCommercialDepartment, PurchCommercialDepartmentDTO>, IPurchCommercialDepartmentService
    {
        public PurchCommercialDepartmentService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<PurchCommercialDepartment> repository)
            : base(mapper, unitOfWork, repository)
        {
        }
    }
}
