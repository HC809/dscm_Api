using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using DiunsaSCM.Service;
using DiunsaSCM.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiunsaSCM.API.Controllers
{
    [Route("api/purchorderheaders/{purchOrderHeaderId:long}/purchordershipmentheaders/{purchOrderShipmentHeaderId:long}/shipmentcontainers/{shipmentContainerId:long}/shipmentContainerDetails/{parentId:long}/[controller]")]
    [ApiController]
    [Authorize]
    public class PurchOrderShipmentCrossDockingsController : GenericController<PurchOrderShipmentCrossDockingDTO>
    {
        public PurchOrderShipmentCrossDockingsController(IServiceBase<PurchOrderShipmentCrossDockingDTO> service)
            : base(service)
        {
        }

        [Route("~/api/purchorderheaders/{purchOrderHeaderId:long}/purchordershipmentheaders/{purchOrderShipmentHeaderId:long}/shipmentcontainers/{shipmentContainerId:long}/[controller]")]
        [HttpGet]
        public async Task<ActionResult> GetAllByShipmentContainerIdAsync(long shipmentContainerId, string searchString = "", int slice = 0)
        {
            IPurchOrderShipmentCrossDockingService purchOrderShipmentCrossDockingService = _service as IPurchOrderShipmentCrossDockingService;
            var serviceResult = await purchOrderShipmentCrossDockingService.GetAllByShipmentContainerId(shipmentContainerId, searchString, slice);
            if (serviceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }

        [Route("~/api/purchorderheaders/{purchOrderHeaderId:long}/purchordershipmentheaders/{purchOrderShipmentHeaderId:long}/shipmentcontainers/{shipmentContainerId:long}/[controller]")]
        [HttpPost]
        public async Task<ActionResult> PostAsync(long shipmentContainerId, [FromBody] PurchOrderShipmentCrossDockingListDTO modelList)
        {
            IPurchOrderShipmentCrossDockingService purchOrderShipmentCrossDockingService = _service as IPurchOrderShipmentCrossDockingService;
            modelList.ShipmentContainerId = shipmentContainerId;
            var serviceResult = await purchOrderShipmentCrossDockingService.AddList(modelList);
            if (serviceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }
    }
}