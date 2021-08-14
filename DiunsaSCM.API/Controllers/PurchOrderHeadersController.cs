using System;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiunsaSCM.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class PurchOrderHeadersController : GenericController<PurchOrderHeaderDTO>
    {
        public PurchOrderHeadersController(IServiceBase<PurchOrderHeaderDTO> service)
            : base(service)
        {
        }
    }
}