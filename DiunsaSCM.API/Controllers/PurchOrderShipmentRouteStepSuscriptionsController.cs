using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using DiunsaSCM.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiunsaSCM.API.Controllers
{
    [Route("api/PurchOrderHeaders/{purchOrderId}/PurchOrderShipmentHeaders/{purchOrderShimentHeaderId}/PurchOrderShipmentRouteStepSuscriptions")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize]
    public class PurchOrderShipmentRouteStepSuscriptionsController : GenericController<PurchOrderShipmentRouteStepSuscriptionDTO>
    {
        IPurchOrderShipmentRouteStepSuscriptionService _purchOrderShipmentRouteStepSuscriptionService;

        public PurchOrderShipmentRouteStepSuscriptionsController(IServiceBase<PurchOrderShipmentRouteStepSuscriptionDTO> service,
                                                                 IPurchOrderShipmentRouteStepSuscriptionService purchOrderShipmentRouteStepSuscriptionService)
            : base(service)
        {
            _purchOrderShipmentRouteStepSuscriptionService = purchOrderShipmentRouteStepSuscriptionService;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> GetAllAsync(long purchOrderShimentHeaderId)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            ServiceResult<IEnumerable<PurchOrderShipmentRouteStepSuscriptionDTO>> serviceResult;
            if (purchOrderShimentHeaderId == 0)
                serviceResult = _purchOrderShipmentRouteStepSuscriptionService.GetAllByUserName(userName);
            else
                serviceResult = _purchOrderShipmentRouteStepSuscriptionService.GetAllByPurchOrderShimentHeaderId(purchOrderShimentHeaderId, userName);
            if (serviceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }

        [Authorize]
        [Route("~/api/[controller]")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;

            var serviceResult = _purchOrderShipmentRouteStepSuscriptionService.GetAllByUserName(userName);
            if (serviceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }

        [Route("~/api/[controller]/{id}")]
        [HttpDelete]
        public IActionResult DeleteGlobal(long id)
        {
            return this.Delete(id);
        }
    }
}