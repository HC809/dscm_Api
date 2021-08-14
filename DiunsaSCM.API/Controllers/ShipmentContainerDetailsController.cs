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
    [Route("api/purchorderheaders/{purchOrderHeaderId:long}/purchordershipmentheaders/{purchOrderShipmentHeaderId:long}/shipmentcontainers/{shipmentContainerId:long}/[controller]")]
    [ApiController]
    [Authorize]
    public class ShipmentContainerDetailsController : ControllerBase
    {
        private readonly IShipmentContainerService _shipmentContainerService;

        public ShipmentContainerDetailsController(IShipmentContainerService shipmentContainerService)
        {
            _shipmentContainerService = shipmentContainerService;
        }

        // GET: api/ShipmentContainerDetails
        [HttpGet]
        public ActionResult Get(long shipmentContainerId)
        {
            var serviceResult = _shipmentContainerService.GetLines(shipmentContainerId);
            if (serviceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }

        // GET: api/ShipmentContainerDetails/5
        [HttpGet("{id}")]
        public ActionResult Get(long shipmentContainerId, long id)
        {
            var serviceResult = _shipmentContainerService.GetLine(shipmentContainerId, id);
            if (serviceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }

        // POST: api/ShipmentContainerDetails
        [HttpPost]
        public ActionResult Post(long purchOrderHeaderId, long purchOrderShipmentHeaderId, long shipmentContainerId, [FromBody] ShipmentContainerDetailDataTransferObject shipmentContainerDetail)
        {
            shipmentContainerDetail.ShipmentContainerId = shipmentContainerId;
            var serviceResult = _shipmentContainerService.AddLine(shipmentContainerDetail);
            if (serviceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }

        [Route("~/api/purchorderheaders/{purchOrderHeaderId:long}/purchordershipmentheaders/{purchOrderShipmentHeaderId:long}/shipmentcontainers/{shipmentContainerId:long}/ShipmentContainerDetailImports")]
        [HttpPost]
        public ActionResult Post(long purchOrderHeaderId, long purchOrderShipmentHeaderId, long shipmentContainerId, [FromBody] ShipmentContainerDetailsListDataTransferObject shipmentContainerDetailsListDataTransferObject)
        {
            shipmentContainerDetailsListDataTransferObject.ShipmentContainerId = shipmentContainerId;
            var purchOrderShipmentDetailServiceResult = _shipmentContainerService.AddLineList(shipmentContainerDetailsListDataTransferObject);
            if (purchOrderShipmentDetailServiceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(purchOrderShipmentDetailServiceResult);
            }
            return Ok(purchOrderShipmentDetailServiceResult);
        }

        // PUT: api/ShipmentContainerDetails/5
        [HttpPut("{id}")]
        public ActionResult Put(long purchOrderHeaderId, long purchOrderShipmentHeaderId, long shipmentContainerId, long id, [FromBody] ShipmentContainerDetailDataTransferObject shipmentContainerDetail)
        {
            var serviceResult = _shipmentContainerService.UpdateLine(id, shipmentContainerDetail);
            if (serviceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(long purchOrderHeaderId, long purchOrderShipmentHeaderId, long shipmentContainerId, long id)
        {
            var serviceResult = _shipmentContainerService.DeleteLine(shipmentContainerId, id);
            if (serviceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }
    }
}
