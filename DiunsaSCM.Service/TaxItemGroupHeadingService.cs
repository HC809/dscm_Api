using System;
using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Services;

namespace DiunsaSCM.Service
{
    public class TaxItemGroupHeadingService : ServiceBase<TaxItemGroupHeading, TaxItemGroupHeadingDTO>, ITaxItemGroupHeadingService
    {
        public TaxItemGroupHeadingService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<TaxItemGroupHeading> repository)
            : base(mapper, unitOfWork, repository)
        {
        }
    }
}