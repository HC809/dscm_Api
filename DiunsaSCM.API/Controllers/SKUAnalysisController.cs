using System;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace DiunsaSCM.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class SKUAnalysissController : GenericController<SKUAnalysisDTO>
    {
        public SKUAnalysissController(IServiceBase<SKUAnalysisDTO> service)
            : base(service)
        {
        }
    }
}