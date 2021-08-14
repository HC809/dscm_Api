using System;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiunsaSCM.API.Controllers
{
    [Route("api/PurchQuotationApprovalRules/{purchQuotationApprovalRuleId:long}/PurchQuotationApprovalRuleConditions/{parentId:long}/[controller]")]
    [Authorize]
    public class PurchQuotationApprovalRuleConditionTermsController : GenericController<PurchQuotationApprovalRuleConditionTermDTO>
    {
        public PurchQuotationApprovalRuleConditionTermsController(IServiceBase<PurchQuotationApprovalRuleConditionTermDTO> service)
            : base(service)
        {
        }
    }
}