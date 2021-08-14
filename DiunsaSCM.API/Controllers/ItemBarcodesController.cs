using System;
using System.Threading.Tasks;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using DiunsaSCM.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiunsaSCM.API.Controllers
{
    [Route("api/InventItems/{parentId:long}/[controller]")]
    [Authorize]
    public class ItemBarcodesController : GenericController<ItemBarcodeDTO>
    {
        public ItemBarcodesController(IServiceBase<ItemBarcodeDTO> service)
            : base(service)
        {
        }

        [Route("~/api/[controller]")]
        [HttpGet]
        public async Task<ActionResult> GetAllAsync(string searchString = "", int slice = 0)
        {
            var serviceResult = await _service.GetAllAsync(searchString, slice);
            if (serviceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }
    }
}