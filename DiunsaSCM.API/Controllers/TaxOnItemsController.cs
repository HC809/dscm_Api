using System;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiunsaSCM.API.Controllers
{
    [Route("api/TaxItemGroupHeadings/{parentId:long}/[controller]")]
    [Authorize]
    public class TaxOnItemsController : GenericController<TaxOnItemDTO>
    {
        public TaxOnItemsController(IServiceBase<TaxOnItemDTO> service)
            : base(service)
        {
        }
    }
}