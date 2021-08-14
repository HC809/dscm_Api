﻿using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;

namespace DiunsaSCM.Data
{
    public class PurchRoleItemHierarchyRepository : RepositoryBase<PurchRoleItemHierarchy>, IPurchRoleItemHierarchyRepository
    {
        public PurchRoleItemHierarchyRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}