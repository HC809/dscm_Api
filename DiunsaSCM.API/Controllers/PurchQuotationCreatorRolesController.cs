using System;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiunsaSCM.API.Controllers
{
    [Route("api/PurchQuotationCreators/{parentId:long}/[controller]")]
    [Authorize]
    public class PurchQuotationCreatorRolesController : GenericController<PurchQuotationCreatorRoleDTO>
    {
        public PurchQuotationCreatorRolesController(IServiceBase<PurchQuotationCreatorRoleDTO> service)
            : base(service)
        {
        }
    }
}