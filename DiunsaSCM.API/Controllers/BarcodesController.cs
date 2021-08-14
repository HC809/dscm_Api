using System;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace DiunsaSCM.API.Controllers
{
    [Route("api/BarcodeBatchs/{parentId:long}/[controller]")]
    [Authorize]
    public class BarcodesController : GenericController<BarcodeDTO>
    {
        public BarcodesController(IServiceBase<BarcodeDTO> service)
            : base(service)
        {
        }
    }
}