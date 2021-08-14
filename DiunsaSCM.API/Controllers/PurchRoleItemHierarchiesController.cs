using System;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiunsaSCM.API.Controllers
{
    [Route("api/PurchRoles/{parentId:long}/[controller]")]
    [Authorize]
    public class PurchRoleItemHierarchiesController : GenericController<PurchRoleItemHierarchyDTO>
    {
        public PurchRoleItemHierarchiesController(IServiceBase<PurchRoleItemHierarchyDTO> service)
            : base(service)
        {
        }
    }
}