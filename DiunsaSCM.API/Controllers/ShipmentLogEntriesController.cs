using System;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using DiunsaSCM.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiunsaSCM.API.Controllers
{
    [Route("api/purchorderheaders/{purchOrderHeaderId:long}/purchordershipmentheaders/{purchOrderShimentHeaderId:long}/[controller]")]
    [ApiController]
    [Authorize]
    public class ShipmentLogEntries : Controller
    {
        private readonly IShipmentLogEntryService _service;

        public ShipmentLogEntries(IShipmentLogEntryService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult GetAll(long purchOrderHeaderId, long purchOrderShimentHeaderId)
        {
            var serviceResult = _service.GetAll(purchOrderHeaderId, purchOrderShimentHeaderId);
            if (serviceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }

        [HttpGet("{id}")]
        public ActionResult Get(long purchOrderHeaderId, long purchOrderShimentHeaderId, long id)
        {
            var serviceResult = _service.GetById(purchOrderHeaderId, purchOrderShimentHeaderId, id);
            if (serviceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }

        [HttpPost]
        public ActionResult Post(long purchOrderHeaderId, long purchOrderShimentHeaderId, [FromBody] ShipmentLogEntryDataTransferObject shipmentLogEntry)
        {
            shipmentLogEntry.PurchOrderShipmentHeaderId = purchOrderShimentHeaderId;
            var serviceResult = _service.Add(purchOrderHeaderId, purchOrderShimentHeaderId, shipmentLogEntry);
            if (serviceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }

        [HttpPut("{id}")]
        public ActionResult Put(long purchOrderHeaderId, long purchOrderShimentHeaderId, long id, [FromBody] ShipmentLogEntryDataTransferObject shipmentLogEntry)
        {
            var serviceResult = _service.Update(purchOrderHeaderId, purchOrderShimentHeaderId, shipmentLogEntry);
            if (serviceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(long purchOrderHeaderId, long purchOrderShimentHeaderId, long id)
        {
            var serviceResult = _service.Delete( purchOrderHeaderId, purchOrderShimentHeaderId, id);
            if (serviceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }
    }
}
