using System;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiunsaSCM.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class PurchPaymentConditionsController : GenericController<PurchPaymentConditionDTO>
    {
        public PurchPaymentConditionsController(IServiceBase<PurchPaymentConditionDTO> service)
            : base(service)
        {
        }
    }
}