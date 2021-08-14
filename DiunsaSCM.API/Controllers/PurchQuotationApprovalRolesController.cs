using System;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiunsaSCM.API.Controllers
{
    [Route("api/PurchQuotationApprovals/{parentId:long}/[controller]")]
    [Authorize]
    public class PurchQuotationApprovalRolesController : GenericController<PurchQuotationApprovalRoleDTO>
    {
        public PurchQuotationApprovalRolesController(IServiceBase<PurchQuotationApprovalRoleDTO> service)
            : base(service)
        {
        }
    }
}