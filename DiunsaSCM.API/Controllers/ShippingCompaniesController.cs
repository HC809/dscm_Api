using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class ShippingCompaniesController : Controller
    {
        private readonly IShippingCompanyService _service;

        public ShippingCompaniesController(IShippingCompanyService service)
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
        public ActionResult Get(long purchOrderShipmentHeaderId, long id)
        {
            var serviceResult = _service.GetById(id);
            if (serviceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }

        [HttpPost]
        public ActionResult Post([FromBody] ShippingCompanyDataTransferObject shippingCompany)
        {
            var serviceResult = _service.Add(shippingCompany);
            if (serviceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }

        [HttpPut("{id}")]
        public ActionResult Put(long id, [FromBody] ShippingCompanyDataTransferObject shippingCompany)
        {
            var serviceResult = _service.Update(shippingCompany);
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
