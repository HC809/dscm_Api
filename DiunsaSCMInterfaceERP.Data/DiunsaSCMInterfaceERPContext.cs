using System;
using DiunsaSCMInterfaceERP.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DiunsaSCMInterfaceERP.Data
{
    public class DiunsaSCMInterfaceERPContext : DbContext
    {
        public DbSet<ERPPurchOrderHeader> ERPPurchOrderHeader { get; set; }
        public DbSet<ERPPurchOrderDetail> ERPPurchOrderDetail { get; set; }
        public DbSet<ERPInventItem> ERPInventItem { get; set; }
        public DbSet<ERPItemBarcode> ERPItemBarcode { get; set; }
        public DbSet<ERPVendor> ERPVendor { get; set; }
        public DbSet<ERPShipmentImport> ERPShipmentImport { get; set; }
        public DbSet<ERPMarkupTrans> ERPMarkupTrans { get; set; }
        public DbSet<ERPSKUAnalysis> ERPSKUAnalysis { get; set; }

        public IConfiguration _configuration { get; set; }

        public DiunsaSCMInterfaceERPContext()
        {
        }
        public DiunsaSCMInterfaceERPContext(DbContextOptions<DiunsaSCMInterfaceERPContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
            => optionsBuilder.UseSqlServer("Data Source=AXDATA3;Initial Catalog=DAX_Interfaces;user id = appconsulta; password = appconsulta;");
        */
	}
}
