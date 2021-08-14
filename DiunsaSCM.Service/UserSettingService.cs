using System;
using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Services;
using DiunsaSCM.Service;

namespace DiunsaSCM.Service
{
    public class UserSettingService : ServiceBase<UserSetting, UserSettingDTO>, IUserSettingService
    {
        public UserSettingService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<UserSetting> repository)
            : base(mapper, unitOfWork, repository)
        {
        }
    }
}