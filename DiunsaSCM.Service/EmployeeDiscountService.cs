using System;
using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Services;

namespace DiunsaSCM.Service
{
    public class EmployeeDiscountService : ServiceBase<EmployeeDiscount, EmployeeDiscountDTO>, IEmployeeDiscountService
    {
        public EmployeeDiscountService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<EmployeeDiscount> repository)
            : base(mapper, unitOfWork, repository)
        {
        }
    }
}
