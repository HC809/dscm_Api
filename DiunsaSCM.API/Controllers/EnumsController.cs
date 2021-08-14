using System;
using System.Collections.Generic;
using System.Linq;
using DiunsaSCM.Core.Enums;
using DiunsaSCM.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiunsaSCM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EnumsController : Controller
    {
        public EnumsController()
        {
        }

        [HttpGet("{enumType}")]
        public IActionResult Get(string enumType)
        {
            IEnumerable<EnumDTO> enums = new List<EnumDTO>();

            if (enumType == "TransportationMethod")
            {
                enums = ((TransportationMethod[])Enum
                .GetValues(typeof(TransportationMethod)))
                .Select(c => new EnumDTO() { Value = (int)c, Name = c.ToString() })
                .ToList();
            }
            else if (enumType == "PurchQuotationApprovalRuleConditionField")
            {
                enums = ((PurchQuotationApprovalRuleConditionField[])Enum
                .GetValues(typeof(PurchQuotationApprovalRuleConditionField)))
                .Select(c => new EnumDTO() { Value = (int)c, Name = c.ToString() })
                .ToList();
            }
            else if (enumType == "PurchQuotationApprovalRuleConditionComparisonOperation")
            {
                enums = ((PurchQuotationApprovalRuleConditionComparisonOperation[])Enum
                .GetValues(typeof(PurchQuotationApprovalRuleConditionComparisonOperation)))
                .Select(c => new EnumDTO() { Value = (int)c, Name = c.ToString() })
                .ToList();
            }
            else if (enumType == "ShippingStepERPAction")
            {
                enums = ((ShippingStepERPAction[])Enum
                .GetValues(typeof(ShippingStepERPAction)))
                .Select(c => new EnumDTO() { Value = (int)c, Name = c.ToString() })
                .ToList();
            }
            else if (enumType == "ItemType")
            {
                enums = ((ItemType[])Enum
                .GetValues(typeof(ItemType)))
                .Select(c => new EnumDTO() { Value = (int)c, Name = c.ToString() })
                .ToList();
            }
            else if (enumType == "SalesPriceDefinitionStatus")
            {
                enums = ((SalesPriceDefinitionStatus[])Enum
                .GetValues(typeof(SalesPriceDefinitionStatus)))
                .Select(c => new EnumDTO() { Value = (int)c, Name = c.ToString() })
                .ToList();
            }
            else if (enumType == "ItemHierarchyLevel")
            {
                enums = ((ItemHierarchyLevel[])Enum
                .GetValues(typeof(ItemHierarchyLevel)))
                .Select(c => new EnumDTO() { Value = (int)c, Name = c.ToString() })
                .ToList();
            }
            else if (enumType == "VendorType")
            {
                enums = ((VendorType[])Enum
                .GetValues(typeof(VendorType)))
                .Select(c => new EnumDTO() { Value = (int)c, Name = c.ToString() })
                .ToList();
            }

            return Ok(enums);
        }
    }
}
