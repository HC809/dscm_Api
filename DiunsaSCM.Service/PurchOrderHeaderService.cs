using System;
using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Services;

namespace DiunsaSCM.Service
{
    public class PurchOrderHeaderService : ServiceBase<PurchOrderHeader, PurchOrderHeaderDTO>, IPurchOrderHeaderService
    {
        public PurchOrderHeaderService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<PurchOrderHeader> repository)
            : base(mapper, unitOfWork, repository)
        {
        }
    }
}
