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

    [Route("api/purchorderheaders/{purchOrderHeaderId:long}/purchordershipmentheaders/{purchOrderShimentHeaderId:long}/[controller]")]
    [ApiController]
    [Authorize]
    public class PurchOrderShipmentDetailsController : ControllerBase
    {
        private readonly IPurchOrderShipmentDetailService _purchOrderShipmentDetailService;

        public PurchOrderShipmentDetailsController(IPurchOrderShipmentDetailService purchOrderShipmentDetailService)
        {
            _purchOrderShipmentDetailService = purchOrderShipmentDetailService;
        }

        // GET: api/<PurchOrderShipmentDetailsController>
        [HttpGet]
        public ActionResult Get(long purchOrderHeaderId , long purchOrderShimentHeaderId)
        {
            var purchOrderDetailServiceResult = _purchOrderShipmentDetailService.GetByPurchShipmentHeaderId(purchOrderShimentHeaderId);
            if (purchOrderDetailServiceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(purchOrderDetailServiceResult);
            }
            return Ok(purchOrderDetailServiceResult);
        }

        // GET api/<PurchOrderShipmentDetailsController>/5
        [HttpGet("{id:long}")]
        public ActionResult Get(long purchOrderHeaderId, long purchOrderShimentHeaderId, int id)
        {
            var purchOrderShipmentDetailServiceResult = _purchOrderShipmentDetailService.GetById(id);
            if (purchOrderShipmentDetailServiceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(purchOrderShipmentDetailServiceResult);
            }
            return Ok(purchOrderShipmentDetailServiceResult);
        }

        // POST api/<PurchOrderShipmentDetailsController>
        [HttpPost]
        public ActionResult Post(long purchOrderHeaderId, long purchOrderShimentHeaderId, [FromBody] PurchOrderShipmentDetailDataTransferObject purchOrderShipmentDetailDataTransferObject)
        {
            purchOrderShipmentDetailDataTransferObject.PurchOrderShipmentHeaderId = purchOrderShimentHeaderId;
            var purchOrderShipmentDetailServiceResult = _purchOrderShipmentDetailService.Add(purchOrderShipmentDetailDataTransferObject);
            if (purchOrderShipmentDetailServiceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(purchOrderShipmentDetailServiceResult);
            }
            return Ok(purchOrderShipmentDetailServiceResult);
        }

        [Route("~/api/purchorderheaders/{purchOrderHeaderId:long}/purchordershipmentheaders/{purchOrderShimentHeaderId:long}/purchOrderShimentDetailImports")]
        [HttpPost]
        public ActionResult Post(long purchOrderHeaderId, long purchOrderShimentHeaderId, [FromBody] PurchOrderShipmentDetailsListDataTransferObject purchOrderShipmentDetailsListDataTransferObject)
        {
            purchOrderShipmentDetailsListDataTransferObject.PurchOrderShipmentHeaderId = purchOrderShimentHeaderId;
            var purchOrderShipmentDetailServiceResult = _purchOrderShipmentDetailService.Add(purchOrderShipmentDetailsListDataTransferObject);
            if (purchOrderShipmentDetailServiceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(purchOrderShipmentDetailServiceResult);
            }
            return Ok(purchOrderShipmentDetailServiceResult);
        }

        // PUT api/<PurchOrderShipmentDetailsController>/5
        [HttpPut("{id:long}")]
        public ActionResult Put(long purchOrderHeaderId, long purchOrderShimentHeaderId, long id, [FromBody] PurchOrderShipmentDetailDataTransferObject purchOrderShipmentDetailDataTransferObject)
        {
            var purchOrderShipmentDetailServiceResult = _purchOrderShipmentDetailService.Update(purchOrderShipmentDetailDataTransferObject);
            if (purchOrderShipmentDetailServiceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(purchOrderShipmentDetailServiceResult);
            }
            return Ok(purchOrderShipmentDetailServiceResult);
        }

        // DELETE api/<PurchOrderShipmentDetailsController>/5
        [HttpDelete("{id:long}")]
        public ActionResult Delete(long purchOrderHeaderId, long purchOrderShimentHeaderId, long id)
        {
            var purchOrderShipmentDetailServiceResult = _purchOrderShipmentDetailService.Delete(id);
            if (purchOrderShipmentDetailServiceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(purchOrderShipmentDetailServiceResult);
            }
            return Ok(purchOrderShipmentDetailServiceResult);
        }
    }
}
