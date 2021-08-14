
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiunsaSCM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InventItemsController : GenericController<InventItemDTO>
    {
        public InventItemsController(IServiceBase<InventItemDTO> service)
            : base(service)
        {
        }
    }
    /*public class InventItemsController : ControllerBase
    {
        private readonly IInventItemService _inventItemService;
        public InventItemsController(IInventItemService inventItemService)
        {
            _inventItemService = inventItemService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] string searchString)
        {
            searchString = String.IsNullOrEmpty(searchString) ? "" : searchString;
            var inventItemServiceResult = _inventItemService.GetAll(searchString);
            if (inventItemServiceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(inventItemServiceResult.Error);
            }
            return Ok(inventItemServiceResult.Data);
        }

        [HttpPost]
        public IActionResult Post([FromBody] InventItemDTO inventItemDataTransferObject)
        {
            var inventItemServiceResult = _inventItemService.Add(inventItemDataTransferObject);
            if (inventItemServiceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(inventItemServiceResult.Error);
            }
            return Ok(inventItemServiceResult.Data);
        }
    }*/
}
