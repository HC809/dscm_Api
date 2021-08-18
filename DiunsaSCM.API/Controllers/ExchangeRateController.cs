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

        [Route("~/api/[controller]/create")]
        [HttpPost]
        public ActionResult Create(ExchangeRateDTO model)
        {
            IExchangeRateService exchangeRateService = _service as IExchangeRateService;

            var serviceResult = exchangeRateService.CreateExchangeRate(model);

            if (serviceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }

        [Route("~/api/[controller]/update")]
        [HttpPut]
        public ActionResult Update(ExchangeRateDTO model)
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
