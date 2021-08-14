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
    public class CommercialEventService : ServiceBase<CommercialEvent, CommercialEventDTO>, ICommercialEventService
    {
        public CommercialEventService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<CommercialEvent> repository)
            : base(mapper, unitOfWork, repository)
        {
        }
    }
}