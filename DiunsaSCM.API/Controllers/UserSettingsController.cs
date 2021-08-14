using System;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiunsaSCM.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class UserSettingsController : GenericController<UserSettingDTO>
    {
        public UserSettingsController(IServiceBase<UserSettingDTO> service)
            : base(service)
        {
        }
    }
}