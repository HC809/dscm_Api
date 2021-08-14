using System;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiunsaSCM.API.Controllers
{
    [Route("api/PurchQuotationApprovalRules/{parentId:long}/[controller]")]
    [Authorize]
    public class PurchQuotationApprovalRuleConditionsController : GenericController<PurchQuotationApprovalRuleConditionDTO>
    {
        public PurchQuotationApprovalRuleConditionsController(IServiceBase<PurchQuotationApprovalRuleConditionDTO> service)
            : base(service)
        {
        }
    }
}