using System;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiunsaSCM.API.Controllers
{
    [Route("api/[controller]")]
    public class PurchRolesController : GenericController<PurchRoleDTO>
    {
        public PurchRolesController(IServiceBase<PurchRoleDTO> service)
            : base(service)
        {
        }
    }
}