﻿using System;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiunsaSCM.API.Controllers
{
    [Route("api/InventItems/{parentId:long}/[controller]")]
    [Authorize]
    public class UnitConvertsController : GenericController<UnitConvertDTO>
    {
        public UnitConvertsController(IServiceBase<UnitConvertDTO> service)
            : base(service)
        {
        }
    }
}