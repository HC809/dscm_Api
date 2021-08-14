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
    [Route("api/InventItems/{parentId:long}/[controller]")]
    [Authorize]
    public class InventItemPrepackBarcodesController : GenericController<InventItemPrepackBarcodeDTO>
    {
        public InventItemPrepackBarcodesController(IServiceBase<InventItemPrepackBarcodeDTO> service)
            : base(service)
        {
        }

        [Route("~/api/InventItems/{parentId:long}/InventItemPrepackBarcodeImports")]
        [HttpPost]
        public async Task<ActionResult> PostAsync(long parentId, [FromBody] InventItemPrepackBarcodeListDTO modelList)
        {
            IInventItemPrepackBarcodeService inventItemPrepackBarcodeService = _service as IInventItemPrepackBarcodeService;
            modelList.InventItemId = parentId;
            var serviceResult = await inventItemPrepackBarcodeService.AddList(modelList);
            if (serviceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }
    }
}