using System;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using DiunsaSCM.Service;
using DiunsaSCM.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace DiunsaSCM.API.Controllers
{
    [Route("api/SalesPriceDefinitions/{parentId:long}/[controller]")]
    [Authorize]
    public class SalesPriceDefinitionLinesController : GenericController<SalesPriceDefinitionLineDTO>
    {
        public SalesPriceDefinitionLinesController(IServiceBase<SalesPriceDefinitionLineDTO> service)
            : base(service)
        {
        }

        [Route("~/api/SalesPriceDefinitions/{parentId:long}/SalesPriceDefinitionLineImports")]
        [HttpPost]
        public ActionResult Post(long parentId, [FromBody] SalesPriceDefinitionLineListDTO modelList)
        {
            ISalesPriceDefinitionLineService salesPriceDefinitionLineService = _service as SalesPriceDefinitionLineService;
            modelList.SalesPriceDefinitionId = parentId;
            var serviceResult = salesPriceDefinitionLineService.AddList(modelList);
            if (serviceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }
    }
}