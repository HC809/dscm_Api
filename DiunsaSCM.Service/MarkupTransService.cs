using System;
using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Services;

namespace DiunsaSCM.Service
{
    public class MarkupTransService : ServiceBase<MarkupTrans, MarkupTransDTO>, IMarkupTransService
    {
        public MarkupTransService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<MarkupTrans> repository)
            : base(mapper, unitOfWork, repository)
        {
        }
    }
}
