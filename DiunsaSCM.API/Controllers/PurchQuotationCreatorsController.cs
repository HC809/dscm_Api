using System;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiunsaSCM.API.Controllers
{
    [Route("api/[controller]")]
    public class PurchQuotationCreatorsController : GenericController<PurchQuotationCreatorDTO>
    {
        public PurchQuotationCreatorsController(IServiceBase<PurchQuotationCreatorDTO> service)
            : base(service)
        {
        }
    }
}