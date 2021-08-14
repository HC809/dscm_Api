using System;
using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Services;

namespace DiunsaSCM.Service
{
    public class BrandService : ServiceBase<Brand, BrandDTO>, IBrandService
    {
        public BrandService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<Brand> repository)
            : base(mapper, unitOfWork, repository)
        {
        }
    }
}