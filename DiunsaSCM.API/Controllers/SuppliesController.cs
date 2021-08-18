using System;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiunsaSCM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class SuppliesController : GenericController<SuppliesDTO>
    {
        public SuppliesController(IServiceBase<SuppliesDTO> service)
            : base(service)
        {
        }
    }
}
