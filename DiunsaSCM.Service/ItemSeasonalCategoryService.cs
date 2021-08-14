using System;
using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Services;

namespace DiunsaSCM.Service
{
    public class ItemSeasonalCategoryService : ServiceBase<ItemSeasonalCategory, ItemSeasonalCategoryDTO>, IItemSeasonalCategoryService
    {
        public ItemSeasonalCategoryService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<ItemSeasonalCategory> repository)
            : base(mapper, unitOfWork, repository)
        {
        }
    }
}
