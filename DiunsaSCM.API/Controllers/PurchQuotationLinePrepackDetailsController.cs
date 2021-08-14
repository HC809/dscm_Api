using System;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiunsaSCM.API.Controllers
{
    [Route("api/PurchQuotations/{purchQuotationId:long}/PurchQuotationLines/{parentId:long}/[controller]")]
    [Authorize]
    public class PurchQuotationLinePrepackDetailsController : GenericController<PurchQuotationLinePrepackDetailDTO>
    {
        public PurchQuotationLinePrepackDetailsController(IServiceBase<PurchQuotationLinePrepackDetailDTO> service)
            : base(service)
        {
        }
    }
}
