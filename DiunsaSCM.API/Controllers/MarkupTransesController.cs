using System;
using DiunsaSCM.Core.Services;
using DiunsaSCM.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiunsaSCM.API.Controllers
{
    public class MarkupTransesController : ControllerBase
    {
        private readonly IMarkupTransService _service;

        public MarkupTransesController(IMarkupTransService service)
        {
            _service = service;
        }

        [Route("~/api/shipmentimports/{shipmentImportId:long}/[controller]")]
        [HttpGet]
        [Authorize]
        public async System.Threading.Tasks.Task<ActionResult> GetAllByShipmentImportAsync(long shipmentImportId)
        {
            var result = await _service.GetAllByParentAsync(shipmentImportId);
            if (result.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(result.Error);
            }
            return Ok(result.Data);
        }
    }
}
