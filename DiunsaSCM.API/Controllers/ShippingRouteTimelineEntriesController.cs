using System;
using DiunsaSCM.Core.Services;
using DiunsaSCM.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiunsaSCM.API.Controllers
{
    [Route("api/purchorderheaders/{purchOrderHeaderId:long}/purchordershipmentheaders/{purchOrderShimentHeaderId:long}/[controller]")]
    [Authorize]
    public class ShippingRouteTimelineEntriesController : Controller
    {
        private readonly IShippingRouteTimelineEntryService _service;

        public ShippingRouteTimelineEntriesController(IShippingRouteTimelineEntryService service)
        {
            _service = service;
        }

        public ActionResult GetAllByPurchOrderShimentHeaderId(long purchOrderShimentHeaderId)
        {
            var serviceResult = _service.GetAllByPurchOrderShimentHeaderId(purchOrderShimentHeaderId);
            if (serviceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }
    }
}