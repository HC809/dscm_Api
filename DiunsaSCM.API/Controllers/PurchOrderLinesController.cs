using System;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiunsaSCM.API.Controllers
{
    [Route("api/purchorderheaders/{parentId:long}/purchorderlines")]
    [Authorize]
    public class PurchOrderDetailsController : GenericController<PurchOrderDetailDTO>
    {
        public PurchOrderDetailsController(IServiceBase<PurchOrderDetailDTO> service)
            : base(service)
        {
        }
    }
}

