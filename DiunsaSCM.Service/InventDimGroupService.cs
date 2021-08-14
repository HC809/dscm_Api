﻿using System;
using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Services;

namespace DiunsaSCM.Service
{
    public class InventDimGroupService : ServiceBase<InventDimGroup, InventDimGroupDTO>, IInventDimGroupService
    {
        public InventDimGroupService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<InventDimGroup> repository)
            : base(mapper, unitOfWork, repository)
        {
        }
    }
}