using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using DiunsaSCM.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DiunsaSCM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PortsController : Controller
    {
        private readonly IPortService _service;

        public PortsController(IPortService service)
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
        public ActionResult Post([FromBody] PortDataTransferObject port)
        {
            var serviceResult = _service.Add(port);
            if (serviceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }

        [HttpPut("{id}")]
        public ActionResult Put(long id, [FromBody] PortDataTransferObject port)
        {
            var serviceResult = _service.Update(port);
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
