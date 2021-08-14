using System;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiunsaSCM.API.Controllers
{
    [Route("api/[controller]")]
    public class PurchCommercialDepartmentsController : GenericController<PurchCommercialDepartmentDTO>
    {
        public PurchCommercialDepartmentsController(IServiceBase<PurchCommercialDepartmentDTO> service)
            : base(service)
        {
        }
    }
}