using System;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace DiunsaSCM.API.Controllers
{
    [Route("api/InventItems/{parentId:long}/[controller]")]
    [Authorize]
    public class InventItemStoreConfigurationsController : GenericController<InventItemStoreConfigurationDTO>
    {
        public InventItemStoreConfigurationsController(IServiceBase<InventItemStoreConfigurationDTO> service)
            : base(service)
        {
        }
    }
}