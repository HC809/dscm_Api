using System;
using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Services;

namespace DiunsaSCM.Service
{
    public class VendorService : ServiceBase<Vendor, VendorDTO>, IVendorService
    {
        public VendorService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<Vendor> repository)
            : base(mapper, unitOfWork, repository)
        {
        }
    }
}
