using System;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace DiunsaSCM.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class PurchCostDefinitionsController : GenericController<PurchCostDefinitionDTO>
    {
        public PurchCostDefinitionsController(IServiceBase<PurchCostDefinitionDTO> service)
            : base(service)
        {
        }
    }
}