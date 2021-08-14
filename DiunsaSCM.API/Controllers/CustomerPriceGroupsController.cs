using System;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace DiunsaSCM.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class CustomerPriceGroupsController : GenericController<CustomerPriceGroupDTO>
    {
        public CustomerPriceGroupsController(IServiceBase<CustomerPriceGroupDTO> service)
            : base(service)
        {
        }
    }
}