using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using DiunsaSCM.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiunsaSCM.API.Controllers
{
    [Route("api/purchorderheaders/{purchOrderHeaderId:long}/purchordershipmentheaders/{purchOrderShipmentHeaderId:long}/[controller]")]
    [ApiController]
    [Authorize]
    public class ShipmentContainersController : ControllerBase
    {
        private readonly IShipmentContainerService _shipmentContainerService;

        public ShipmentContainersController(IShipmentContainerService shipmentContainerService)
        {
            _shipmentContainerService = shipmentContainerService;
        }

        // GET: api/ShipmentContainers
        [HttpGet]
        public ActionResult GetByPurchOrderShipmentHeaderId(long purchOrderShipmentHeaderId)
        {
            var serviceResult = _shipmentContainerService.GetByPurchOrderShipmentHeaderId(purchOrderShipmentHeaderId);
            if (serviceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }

        // GET: api/ShipmentContainers/5
        [HttpGet("{id}")]
        public ActionResult Get(long purchOrderShipmentHeaderId, long id)
        {
            var serviceResult = _shipmentContainerService.GetById(id);
            if (serviceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }

        // POST: api/ShipmentContainers
        [HttpPost]
        public ActionResult Post(long purchOrderHeaderId, long purchOrderShipmentHeaderId, [FromBody] ShipmentContainerDataTransferObject shipmentContainer)
        {
            shipmentContainer.PurchOrderShipmentHeaderId = purchOrderShipmentHeaderId;
            var serviceResult = _shipmentContainerService.Add(shipmentContainer);
            if (serviceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }

        // PUT: api/ShipmentContainers/5
        [HttpPut("{id}")]
        public ActionResult Put(long purchOrderHeaderId, long purchOrderShipmentHeaderId, long id, [FromBody] ShipmentContainerDataTransferObject shipmentContainer)
        {
            shipmentContainer.PurchOrderShipmentHeaderId = purchOrderShipmentHeaderId;
            var serviceResult = _shipmentContainerService.Update(shipmentContainer);
            if (serviceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(long purchOrderHeaderId, long purchOrderShipmentHeaderId, long id)
        {
            var serviceResult = _shipmentContainerService.Delete(id);
            if (serviceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }
    }
}
