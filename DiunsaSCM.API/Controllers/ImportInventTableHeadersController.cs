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
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ImportInventTableHeadersController : ControllerBase
    {
        private readonly IImportInventTableHeaderService _importInventTableHeaderService;
        public ImportInventTableHeadersController(IImportInventTableHeaderService importInventTableHeaderService)
        {
            _importInventTableHeaderService = importInventTableHeaderService;
        }

        // POST api/<ImportInventTableHeaderController>
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] ImportInventTableHeaderDTO importInventTableHeaderDataTransferObject)
        {
            var purchOrderHeaderServiceResult = _importInventTableHeaderService.AddList(importInventTableHeaderDataTransferObject);
            if (purchOrderHeaderServiceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(purchOrderHeaderServiceResult);
            }

            /*purchOrderHeaderServiceResult = _importInventTableHeaderService.ExecuteActionAsync(purchOrderHeaderServiceResult.Data.Id, "Apply");
            if (purchOrderHeaderServiceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(purchOrderHeaderServiceResult.Error);
            }*/

            return Ok(purchOrderHeaderServiceResult);
        }

        // PUT api/<ImportInventTableHeaderController>/5
        [HttpPut("{id:long}/actions/apply")]
        public async Task<ActionResult> ExcecuteActionApplyAsync(long id, string action="Apply")
        {
            /*var purchOrderHeaderServiceResult = await _importInventTableHeaderService.ExecuteActionAsync(id, "Apply");
            if (purchOrderHeaderServiceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(purchOrderHeaderServiceResult.Error);
            }
            return Ok(purchOrderHeaderServiceResult.Data);*/
            return Ok();
        }

    }
}
