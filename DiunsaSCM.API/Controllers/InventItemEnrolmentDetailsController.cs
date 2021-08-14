using System;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiunsaSCM.API.Controllers
{
    [Route("api/InventItemEnrolments/{parentId:long}/[controller]")]
    [Authorize]
    public class InventItemEnrolmentDetailsController : GenericController<InventItemEnrolmentDetailDTO>
    {
        public InventItemEnrolmentDetailsController(IServiceBase<InventItemEnrolmentDetailDTO> service)
            : base(service)
        {
        }
    }
}