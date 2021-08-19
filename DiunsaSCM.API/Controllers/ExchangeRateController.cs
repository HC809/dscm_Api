using System;
using System.Threading.Tasks;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using DiunsaSCM.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiunsaSCM.API.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    public class ExchangeRateController : GenericController<ExchangeRateDTO>
    {
        public ExchangeRateController(IServiceBase<ExchangeRateDTO> service)
            : base(service)
        {
        }

        [HttpPost]
        public override ActionResult Post(ExchangeRateDTO model)
        {
            IExchangeRateService exchangeRateService = _service as IExchangeRateService;

            var serviceResult = exchangeRateService.CreateExchangeRate(model);

            if (serviceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }

        [HttpPut("{id}")]
        public override ActionResult Put(long id, ExchangeRateDTO model)
        {
            IExchangeRateService exchangeRateService = _service as IExchangeRateService;

            var serviceResult = exchangeRateService.UpdateExchangeRate(model);

            if (serviceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }
    }
}
