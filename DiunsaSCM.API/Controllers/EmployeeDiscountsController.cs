using System;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace DiunsaSCM.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class EmployeeDiscountsController : GenericController<EmployeeDiscountDTO>
    {
        public EmployeeDiscountsController(IServiceBase<EmployeeDiscountDTO> service)
            : base(service)
        {
        }
    }
}