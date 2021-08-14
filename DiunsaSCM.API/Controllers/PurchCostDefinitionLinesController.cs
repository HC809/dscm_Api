using System;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using DiunsaSCM.Service;
using DiunsaSCM.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiunsaSCM.API.Controllers
{
    [Route("api/PurchCostDefinitions/{parentId:long}/[controller]")]
    [Authorize]
    public class PurchCostDefinitionLinesController : GenericController<PurchCostDefinitionLineDTO>
    {
        public PurchCostDefinitionLinesController(IServiceBase<PurchCostDefinitionLineDTO> service)
            : base(service)
        {
        }

        [Route("~/api/PurchCostDefinitions/{parentId:long}/PurchCostDefinitionLineImports")]
        [HttpPost]
        public ActionResult Post(long parentId, [FromBody] PurchCostDefinitionLineListDTO modelList)
        {
            IPurchCostDefinitionLineService salesPriceDefinitionLineService = _service as PurchCostDefinitionLineService;
            modelList.PurchCostDefinitionId = parentId;
            var serviceResult = salesPriceDefinitionLineService.AddList(modelList);
            if (serviceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }
    }
}