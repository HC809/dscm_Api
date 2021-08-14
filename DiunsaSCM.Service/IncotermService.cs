using System;
using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Services;

namespace DiunsaSCM.Service
{
    public class IncotermService : ServiceBase<Incoterm, IncotermDTO>, IIncotermService
    {
        public IncotermService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<Incoterm> repository)
            : base(mapper, unitOfWork, repository)
        {
        }
    }
}