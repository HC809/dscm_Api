using System;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiunsaSCM.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class ShippingRouteStatusPresentationSchemasController : GenericController<ShippingRouteStatusPresentationSchemaDTO>
    {
        public ShippingRouteStatusPresentationSchemasController(IServiceBase<ShippingRouteStatusPresentationSchemaDTO> service)
            : base(service)
        {
        }
    }
}