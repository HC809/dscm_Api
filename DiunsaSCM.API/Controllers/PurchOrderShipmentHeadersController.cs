using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using DiunsaSCM.Service;
using DiunsaSCM.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DiunsaSCM.API.Controllers
{
    [Route("api/purchorderheaders/{purchOrderHeaderId:long}/[controller]")]
    [ApiController]
    [Authorize]
    public class PurchOrderShipmentHeadersController : ControllerBase
    {
        private readonly IPurchOrderShipmentHeaderService _purchOrderShipmentHeaderService;

        public PurchOrderShipmentHeadersController(IPurchOrderShipmentHeaderService purchOrderShipmentHeaderService)
        {
            _purchOrderShipmentHeaderService = purchOrderShipmentHeaderService;
        }

        /*[Route("~/api/[controller]")]
        [HttpGet]
        public IActionResult GetAll([FromQuery] string searchString)
        {
            searchString = String.IsNullOrEmpty(searchString) ? "" : searchString;
            var purchOrderHeaderServiceResult = _purchOrderShipmentHeaderService.GetAll(searchString);
            if (purchOrderHeaderServiceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(purchOrderHeaderServiceResult);
            }
            return Ok(purchOrderHeaderServiceResult);
        }*/

        // GET: api/<PurchOrderShipmentHeaders>
        [HttpGet]
        public ActionResult GetByPurchOrdertHeaderId(long purchOrderHeaderId)
        {
            var purchOrderHeaderServiceResult = _purchOrderShipmentHeaderService.GetByPurchOrdertHeaderId(purchOrderHeaderId);
            if (purchOrderHeaderServiceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(purchOrderHeaderServiceResult);
            }
            return Ok(purchOrderHeaderServiceResult);
        }

        [Route("~/api/shipmentimports/{shipmentImportId:long}/[controller]")]
        [HttpGet]
        public ActionResult GetByShipmentImportId(long shipmentImportId)
        {
            var purchOrderHeaderServiceResult = _purchOrderShipmentHeaderService.GetByShipmentImportId(shipmentImportId);
            if (purchOrderHeaderServiceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(purchOrderHeaderServiceResult);
            }
            return Ok(purchOrderHeaderServiceResult);
        }

        [HttpGet]
        [Route("~/api/[controller]")]
        public IActionResult GetAllByFilterModel([FromQuery] FilterPurchOrderShipmentDTO filterModel)
        {
            var serviceResult = _purchOrderShipmentHeaderService.GetAllByFilterModel(filterModel);
            if (serviceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }

        // GET api/<PurchOrderShipmentHeaders>/5
        [HttpGet("{id:long}")]
        public ActionResult Get(long id)
        {
            var purchOrderHeaderServiceResult = _purchOrderShipmentHeaderService.GetById(id);
            if (purchOrderHeaderServiceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(purchOrderHeaderServiceResult);
            }
            return Ok(purchOrderHeaderServiceResult);
        }

        // POST api/<PurchOrderShipmentHeaders>
        [HttpPost]
        public ActionResult Post(long purchOrderHeaderId, [FromBody] PurchOrderShipmentHeaderDataTransferObject purchOrderShipmentHeaderDataTransferObject)
        {
            purchOrderShipmentHeaderDataTransferObject.PurchOrderHeaderId = purchOrderHeaderId;
            var purchOrderShipmentHeaderServiceResult = _purchOrderShipmentHeaderService.Add(purchOrderShipmentHeaderDataTransferObject);
            if (purchOrderShipmentHeaderServiceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(purchOrderShipmentHeaderServiceResult);
            }
            return Ok(purchOrderShipmentHeaderServiceResult);
        }

        // PUT api/<PurchOrderShipmentHeaders>/5
        [HttpPut("{id}")]
        public ActionResult Put(long purchOrderHeaderId, long id, [FromBody] PurchOrderShipmentHeaderDataTransferObject purchOrderShipmentHeaderDataTransferObject)
        {
            var purchOrderShipmentHeaderServiceResult = _purchOrderShipmentHeaderService.Update(purchOrderShipmentHeaderDataTransferObject);
            if (purchOrderShipmentHeaderServiceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(purchOrderShipmentHeaderServiceResult);
            }
            return Ok(purchOrderShipmentHeaderServiceResult);
        }

        // DELETE api/<PurchOrderShipmentHeaders>/5
        [HttpDelete("{id:long}")]
        public ActionResult Delete(long purchOrderHeaderId, long id)
        {
            var purchOrderShipmentHeaderServiceResult = _purchOrderShipmentHeaderService.Delete(id);
            if (purchOrderShipmentHeaderServiceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(purchOrderShipmentHeaderServiceResult);
            }
            return Ok(purchOrderShipmentHeaderServiceResult);
        }
    }
}
