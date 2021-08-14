using System;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace DiunsaSCM.Core.Entities
{
    public abstract class AuditableEntity
    {
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public virtual void PrepareSave(EntityState state, string username)
        {
            if (state == EntityState.Added)
            {
                CreatedBy = username;
                CreatedDate = DateTime.Now;
            }
            if (state == EntityState.Modified)
            {
                UpdatedBy = username;
                UpdatedDate = DateTime.Now;
            }
        }
    }
}
