using System;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiunsaSCM.API.Controllers
{
    [NonController]
    [Route("api/[controller]")]
    [Authorize]
    public class BarcodeBatchsController : GenericController<BarcodeBatchDTO>
    {
        public BarcodeBatchsController(IServiceBase<BarcodeBatchDTO> service)
            : base(service)
        {
        }
    }
}