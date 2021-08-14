using System;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiunsaSCM.API.Controllers
{
    [Route("api/[controller]")]
    public class CommercialAgreementsController : GenericController<CommercialAgreementDTO>
    {
        public CommercialAgreementsController(IServiceBase<CommercialAgreementDTO> service)
            : base(service)
        {
        }
    }
}
