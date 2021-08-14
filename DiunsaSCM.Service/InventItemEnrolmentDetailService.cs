using System;
using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Services;

namespace DiunsaSCM.Service
{
    public class InventItemEnrolmentDetailService : ServiceBase<InventItemEnrolmentDetail, InventItemEnrolmentDetailDTO>, IInventItemEnrolmentDetailService
    {
        public InventItemEnrolmentDetailService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<InventItemEnrolmentDetail> repository)
            : base(mapper, unitOfWork, repository)
        {
        }
    }
}
