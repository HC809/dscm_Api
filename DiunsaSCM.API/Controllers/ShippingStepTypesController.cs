using System;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using DiunsaSCM.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiunsaSCM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ShippingStepTypesController : Controller
    {
        private readonly IShippingStepTypeService _service;

        public ShippingStepTypesController(IShippingStepTypeService service)
        {
            _service = service;
        }

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

        [HttpGet("{id}")]
        public ActionResult Get(long id)
        {
            var serviceResult = _service.GetById(id);
            if (serviceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }

        [HttpPost]
        public ActionResult Post([FromBody] ShippingStepTypeDTO shippingStepType)
        {
            var serviceResult = _service.Add(shippingStepType);
            if (serviceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }

        [HttpPut("{id}")]
        public ActionResult Put(long id, [FromBody] ShippingStepTypeDTO shippingStepType)
        {
            var serviceResult = _service.Update(shippingStepType);
            if (serviceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
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
