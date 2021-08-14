using System;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiunsaSCM.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class PurchQuotationApprovalRulesController : GenericController<PurchQuotationApprovalRuleDTO>
    {
        public PurchQuotationApprovalRulesController(IServiceBase<PurchQuotationApprovalRuleDTO> service)
            : base(service)
        {
        }
    }
}