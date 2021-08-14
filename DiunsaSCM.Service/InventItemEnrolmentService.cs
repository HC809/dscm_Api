using System;
using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Services;

namespace DiunsaSCM.Service
{
    public class InventItemEnrolmentService : ServiceBase<InventItemEnrolment, InventItemEnrolmentDTO>, IInventItemEnrolmentService
    {
        public InventItemEnrolmentService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<InventItemEnrolment> repository)
            : base(mapper, unitOfWork, repository)
        {
        }
    }
}
