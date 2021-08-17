using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DiunsaSCM.Data
{
    public partial class TestDBContext : DbContext
    {
        public TestDBContext()
        {
        }

        public TestDBContext(DbContextOptions<TestDBContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=DSCM;User Id=dscm_dev;Password=Dual@2021;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence("InventItemEnrolments");

            modelBuilder.HasSequence("InventItems").StartsAt(1000000);

            modelBuilder.HasSequence("PurchCostDefinitions");

            modelBuilder.HasSequence("PurchOrders").StartsAt(1000000);

            modelBuilder.HasSequence("PurchOrderShipments").StartsAt(1000000);

            modelBuilder.HasSequence("PurchQuotations");

            modelBuilder.HasSequence("SalesPriceDefinitions");

            modelBuilder.HasSequence("Vendors").StartsAt(1000000);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
