using System;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using DiunsaSCM.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiunsaSCM.API.Controllers
{
    [Route("api/shippingroutes/{shippingRouteId:long}/[controller]")]
    [ApiController]
    [Authorize]
    public class ShippingRouteStepsController : Controller
    {
        private readonly IShippingRouteStepService _service;

        public ShippingRouteStepsController(IShippingRouteStepService service)
        {
            _service = service;
        }

        [Route("~/api/shippingroutesteps")]
        [HttpGet]
        public ActionResult GetAll()
        {
            var serviceResult = _service.GetAll();
            if (serviceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }

        [HttpGet]
        public ActionResult GetAllByShippingRoute(long shippingRouteId)
        {
            var serviceResult = _service.GetAllByShippingRoute(shippingRouteId);
            if (serviceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }

        

        [HttpGet("{id}")]
        public ActionResult Get(long shippingRouteId, long id)
        {
            var serviceResult = _service.GetById(id);
            if (serviceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }

        [HttpPost]
        public ActionResult Post(long shippingRouteId, [FromBody] ShippingRouteStepDataTransferObject shippingRouteStep)
        {
            shippingRouteStep.ShippingRouteId = shippingRouteId;
            var serviceResult = _service.Add(shippingRouteStep);
            if (serviceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }

        [HttpPut("{id}")]
        public ActionResult Put(long shippingRouteId, long id, [FromBody] ShippingRouteStepDataTransferObject shippingRouteStep)
        {
            var serviceResult = _service.Update(shippingRouteStep);
            if (serviceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(long shippingRouteId, long id)
        {
            var serviceResult = _service.Delete(id);
            if (serviceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }
    }
}
