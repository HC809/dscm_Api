using System;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiunsaSCM.API.Controllers
{
    [Route("api/PurchQuotationApprovalRules/{purchQuotationApprovalRuleId:long}/PurchQuotationApprovalRuleConditions/{parentId:long}/[controller]")]
    [Authorize]
    public class PurchQuotationApprovalRuleConditionStepsController : GenericController<PurchQuotationApprovalRuleConditionStepDTO>
    {
        public PurchQuotationApprovalRuleConditionStepsController(IServiceBase<PurchQuotationApprovalRuleConditionStepDTO> service)
            : base(service)
        {
        }
    }
}