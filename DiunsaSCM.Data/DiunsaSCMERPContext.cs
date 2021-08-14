using System;
using DiunsaSCMInterfaceERP.Core.Entities.ERPEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DiunsaSCM.Data
{
    public class DiunsaSCMERPContext : DbContext
    {
        public DbSet<ERPReceiptDetail> ERPReceiptDetail { get; set; }
        public IConfiguration _configuration { get; set; }

        public DiunsaSCMERPContext()
        {
        }

        public DiunsaSCMERPContext(DbContextOptions<DiunsaSCMERPContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }
    }
}
