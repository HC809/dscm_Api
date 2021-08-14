using System;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiunsaSCM.API.Controllers
{
    [Route("api/PurchQuotations/{parentId:long}/[controller]")]
    [Authorize]
    public class PurchQuotationLinesController : GenericController<PurchQuotationLineDTO>
    {
        public PurchQuotationLinesController(IServiceBase<PurchQuotationLineDTO> service)
            : base(service)
        {
        }
    }
}