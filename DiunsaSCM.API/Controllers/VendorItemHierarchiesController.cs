using System;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiunsaSCM.API.Controllers
{
    [Route("api/Vendors/{parentId:long}/[controller]")]
    [Authorize]
    public class VendorItemHierarchiesController : GenericController<VendorItemHierarchyDTO>
    {
        public VendorItemHierarchiesController(IServiceBase<VendorItemHierarchyDTO> service)
            : base(service)
        {
        }
    }
}