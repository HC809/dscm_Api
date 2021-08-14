using System;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiunsaSCM.API.Controllers
{
    [Route("api/[controller]")]
    public class ItemSeasonalCategoriesController : GenericController<ItemSeasonalCategoryDTO>
    {
        public ItemSeasonalCategoriesController(IServiceBase<ItemSeasonalCategoryDTO> service)
            : base(service)
        {
        }
    }
}