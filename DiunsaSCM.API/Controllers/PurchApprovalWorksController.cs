using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Services;
using DiunsaSCM.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiunsaSCM.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class PurchApprovalWorksController : Controller
    {
        protected readonly IPurchApprovalWorkService _service;

        public PurchApprovalWorksController(IPurchApprovalWorkService service)
        {
            _service = service;
        }

        public async Task<ActionResult> GetAllAsync(string searchString = "", int slice = 0)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var username = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;

            var serviceResult = await _service.GetAllAsync(username, searchString, slice);
            if (serviceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }
    }
}