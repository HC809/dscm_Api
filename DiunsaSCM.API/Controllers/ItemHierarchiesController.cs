using System;
using System.Threading.Tasks;
using DiunsaSCM.Core.Enums;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using DiunsaSCM.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace DiunsaSCM.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class ItemHierarchiesController : GenericController<ItemHierarchyDTO>
    {
        public ItemHierarchiesController(IServiceBase<ItemHierarchyDTO> service)
            : base(service)
        {
        }

        [Route("~/api/[controller]")]
        [HttpGet]
        public async Task<ActionResult> GetAllAsync([FromQuery] ItemHierarchyLevel itemHierarchyLevel, [FromQuery]  bool includeChildren)
        {
            var service = _service as IItemHierarchyService;
            var serviceResult = await service.GetAllAsync(itemHierarchyLevel, includeChildren);
            if (serviceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }
    }
}