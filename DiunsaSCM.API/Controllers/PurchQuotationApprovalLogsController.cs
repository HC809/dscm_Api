using System;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiunsaSCM.API.Controllers
{
    [Route("api/PurchQuotations/{parentId:long}/[controller]")]
    [Authorize]
    public class PurchQuotationApprovalLogsController : GenericController<PurchQuotationApprovalLogDTO>
    {
        public PurchQuotationApprovalLogsController(IServiceBase<PurchQuotationApprovalLogDTO> service)
            : base(service)
        {
        }
    }
}