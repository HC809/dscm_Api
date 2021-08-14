using System;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiunsaSCM.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class StoresController : GenericController<StoreDTO>
    {
        public StoresController(IServiceBase<StoreDTO> service)
            : base(service)
        {
        }
    }
}