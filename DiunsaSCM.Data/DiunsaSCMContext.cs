using System;
using System.Linq;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Providers;
using Microsoft.EntityFrameworkCore;
namespace DiunsaSCM.Data
{
    public class DiunsaSCMContext : DbContext
    {
        public DbSet<PurchOrderDetail> PurchOrderDetail { get; set; }
        public DbSet<PurchOrderHeader> PurchOrderHeader { get; set; }
        public DbSet<PurchOrderShipmentDetail> PurchOrderShipmentDetail { get; set; }
        public DbSet<PurchOrderShipmentHeader> PurchOrderShipmentHeader { get; set; }
        public DbSet<ShipmentContainer> ShipmentContainer { get; set; }
        public DbSet<ShipmentContainerDetail> ShipmentContainerDetail { get; set; }
        public DbSet<ShippingCompany> ShippingCompany { get; set; }
        public DbSet<ShipmentContainerType> ShipmentContainerType { get; set; }
        public DbSet<Port> Port { get; set; }
        public DbSet<Incoterm> Incoterm { get; set; }

        public DbSet<InventItem> InventItem { get; set; }

        public DbSet<ItemBarcode> ItemBarcode { get; set; }

        
        public DbSet<ShippingRouteStatusPresentationSchema> ShippingRouteStatusPresentationSchema { get; set; }
        public DbSet<PurchOrderShipmentRouteStepSuscription> PurchOrderShipmentRouteStepSuscription { get; set; }
        
        
        public DbSet<Color> Color { get; set; }
        public DbSet<InventDimGroup> InventDimGroup { get; set; }
        public DbSet<InventItemGroup> InventItemGroup { get; set; }
        public DbSet<Store> Store { get; set; }
        public DbSet<InventDim> InventDim { get; set; }
        public DbSet<Size> Size { get; set; }
        public DbSet<UnitConvert> UnitConvert { get; set; }
        public DbSet<TaxOnItem> TaxOnItem { get; set; }
        public DbSet<TaxItemGroupHeading> TaxItemGroupHeading { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Unit> Unit { get; set; }

        
        public DbSet<PurchQuotationLine> PurchQuotationLine { get; set; }
        public DbSet<PurchQuotation> PurchQuotation { get; set; }
        public DbSet<PurchQuotationApprovalLog> PurchQuotationApprovalLog { get; set; }
        public DbSet<PurchQuotationApprovalRuleConditionTerm> PurchQuotationApprovalRuleConditionTerm { get; set; }
        public DbSet<PurchQuotationApprovalRuleCondition> PurchQuotationApprovalRuleCondition { get; set; }
        public DbSet<PurchQuotationApprovalRule> PurchQuotationApprovalRule { get; set; }
        public DbSet<PurchQuotationApproval> PurchQuotationApproval { get; set; }

        public DbSet<UserSetting> UserSettings { get; set; }
        public DbSet<ShipmentType> ShipmentTypes { get; set; }
        public DbSet<CommercialEvent> CommercialEvent { get; set; }

        public DbSet<Vendor> Vendor { get; set; }
        public DbSet<InventModelGroup> InventModelGroup { get; set; }
        public DbSet<ItemHierarchy> ItemHierarchy { get; set; }
        public DbSet<InventItemStoreConfiguration> InventItemStoreConfiguration { get; set; }
        public DbSet<EmployeeDiscount> EmployeeDiscount { get; set; }
        public DbSet<SalesPriceDefinition> SalesPriceDefinition { get; set; }
        public DbSet<SalesPriceDefinitionLine> SalesPriceDefinitionLine { get; set; }
        public DbSet<CustomerPriceGroup> CustomerPriceGroup { get; set; }
        public DbSet<SalesPrice> SalesPrice { get; set; }
        public DbSet<BarcodeSource> BarcodeSource { get; set; }
        public DbSet<BarcodeBatch> BarcodeBatch { get; set; }
        public DbSet<Barcode> Barcode { get; set; }

        public DbSet<Currency> Currency { get; set; }
        public DbSet<PurchPaymentCondition> PurchPaymentCondition { get; set; }

        public DbSet<ItemSeasonalCategory> ItemSeasonalCategory { get; set; }
        public DbSet<Warehouse> Warehouse { get; set; }
        public DbSet<PurchCostDefinition> PurchCostDefinition { get; set; }
        public DbSet<PurchCostDefinitionLine> PurchCostDefinitionLine { get; set; }

        public DbSet<PurchCommercialDepartment> PurchCommercialDepartment { get; set; }
        public DbSet<PurchRole> PurchRole { get; set; }
        public DbSet<PurchQuotationApprovalRole> PurchQuotationApprovalRole { get; set; }
        public DbSet<PurchQuotationApprovalRuleConditionStep> PurchQuotationApprovalRuleConditionStep { get; set; }

        public DbSet<InventItemPrepackBarcode> InventItemPrepackBarcode { get; set; }
        public DbSet<PurchOrderShipmentCrossDocking> PurchOrderShipmentCrossDocking { get; set; }
        public DbSet<PurchQuotationLinePrepackDetail> PurchQuotationLinePrepackDetail { get; set; }

        public DbSet<CommercialAgreement> CommercialAgreement { get; set; }
        public DbSet<VendorItemHierarchy> VendorItemHierarchy { get; set; }
        public DbSet<PurchRoleItemHierarchy> PurchRoleItemHierarchy { get; set; }
        public DbSet<PurchQuotationCreator> PurchQuotationCreator { get; set; }
        public DbSet<PurchQuotationCreatorRole> PurchQuotationCreatorRole { get; set; }
        public DbSet<InventItemPurchPriceLog> InventItemPurchPriceLog { get; set; }
        public DbSet<InventItemEnrolment> InventItemEnrolment { get; set; }
        public DbSet<InventItemEnrolmentDetail> InventItemEnrolmentDetail { get; set; }

        #region MODULO COSTEO
        public DbSet<ExchangeRate> ExchangeRate { get; set; }
        public DbSet<Supplies> Supplies { get; set; }
        #endregion MODULO COSTEO

        public DiunsaSCMContext() { }

        private SessionProvider _sessionProvider;

        public DiunsaSCMContext(DbContextOptions<DiunsaSCMContext> options, SessionProvider sessionProvider)
           : base(options)
        {
            _sessionProvider = sessionProvider;
        }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
                    .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);

            foreach (var entry in modifiedEntries)
            {
                if (entry.Entity.GetType().IsSubclassOf(typeof(AuditableEntity)))
                {
                    if (entry.State == EntityState.Modified)
                    {
                        entry.Property("CreatedDate").IsModified = false;
                        entry.Property("CreatedBy").IsModified = false;
                    }

                    var entity = entry.Entity as AuditableEntity;
                    entity?.PrepareSave(entry.State, _sessionProvider.Session.Username);
                }
            }

            var result = base.SaveChanges();
            return result;
        }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=52.251.54.83,1433;Database=DSCM;User Id=dtech;Password=Dual@2021;");
            optionsBuilder.UseSqlServer("Server=localhost;Database=DSCM;User Id=dscm_dev;Password=Dual@2021;Trusted_Connection=True;MultipleActiveResultSets=true;");
            //optionsBuilder.UseSqlServer("Server=172.30.5.231;Database=DSCM;User=sa;Password=Diunsa504Admin;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetForeignKeys())
            .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder
                .Entity<PurchQuotationLinePrepackDetail>()
                .HasOne(e => e.PurchQuotationLine)
                .WithMany(e => e.PurchQuotationLinePrepackDetails)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.HasSequence<long>("InventItems")
                .StartsAt(1000000)
                .IncrementsBy(1);
            modelBuilder.Entity<InventItem>()
                .Property(s => s.Code)
                .HasDefaultValueSql("Format(NEXT VALUE FOR dbo.InventItems,'D8')")
                .ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<InventItem>()
                .HasIndex(x => x.Code);
            modelBuilder.Entity<InventItem>()
                .HasIndex(x => x.NameAlias);
            modelBuilder.Entity<InventItem>()
                .HasIndex(x => new { x.Code, x.NameAlias });
            modelBuilder.HasSequence<long>("PurchQuotations")
                .StartsAt(1)
                .IncrementsBy(1);
            modelBuilder.Entity<PurchQuotation>()
                .Property(s => s.Code)
                .HasDefaultValueSql("'RQ' + Format(NEXT VALUE FOR dbo.PurchQuotations,'D8')");

            modelBuilder.HasSequence<long>("PurchOrders")
                .StartsAt(1000000)
                .IncrementsBy(1);
            modelBuilder.Entity<PurchOrderHeader>()
                .Property(s => s.Code)
                .HasDefaultValueSql("'OC' + Format(NEXT VALUE FOR dbo.PurchOrders,'D8')");

            modelBuilder.HasSequence<long>("PurchOrderShipments")
                .StartsAt(1000000)
                .IncrementsBy(1);
            modelBuilder.Entity<PurchOrderShipmentHeader>()
                .Property(s => s.Code)
                .HasDefaultValueSql("'EC' + Format(NEXT VALUE FOR dbo.PurchOrderShipments,'D8')");

            modelBuilder.HasSequence<long>("Vendors")
                .StartsAt(1000000)
                .IncrementsBy(1);
            modelBuilder.Entity<Vendor>()
                .Property(s => s.Code)
                .HasDefaultValueSql("'P' + Format(NEXT VALUE FOR dbo.Vendors,'D8')");

            modelBuilder.HasSequence<long>("PurchCostDefinitions")
                .StartsAt(1000000)
                .IncrementsBy(1);
            modelBuilder.Entity<PurchCostDefinition>()
                .Property(s => s.Code)
                .HasDefaultValueSql("'DC' + Format(NEXT VALUE FOR dbo.PurchCostDefinitions,'D8')");

            modelBuilder.HasSequence<long>("SalesPriceDefinitions")
                .StartsAt(1000000)
                .IncrementsBy(1);
            modelBuilder.Entity<SalesPriceDefinition>()
                .Property(s => s.Code)
                .HasDefaultValueSql("'DP' + Format(NEXT VALUE FOR dbo.SalesPriceDefinitions,'D8')");

            modelBuilder.HasSequence<long>("InventItemEnrolments")
                .IncrementsBy(1);
            modelBuilder.Entity<InventItemEnrolment>()
                .Property(s => s.Code)
                .HasDefaultValueSql("'MA' + Format(NEXT VALUE FOR dbo.InventItemEnrolments,'D8')");

            modelBuilder.Entity<Barcode                                             >().HasIndex(e => e.Code).IsUnique(true);
            modelBuilder.Entity<Brand                                               >().HasIndex(e=>e.Code).IsUnique(true);
            modelBuilder.Entity<Color                                               >().HasIndex(e=>new{e.InventItemId, e.Code }).IsUnique(true);
            modelBuilder.Entity<CommercialEvent                                     >().HasIndex(e => e.Description).IsUnique(true);
            modelBuilder.Entity<Country                                             >().HasIndex(e => e.Code).IsUnique(true);
            modelBuilder.Entity<Currency                                            >().HasIndex(e => e.Code).IsUnique(true);
            modelBuilder.Entity<CustomerPriceGroup                                  >().HasIndex(e => e.Code).IsUnique(true);
            modelBuilder.Entity<EmployeeDiscount                                    >().HasIndex(e => e.Code).IsUnique(true);
            modelBuilder.Entity<Incoterm                                            >().HasIndex(e => e.Code).IsUnique(true);
            modelBuilder.Entity<InventDim                                           >().HasIndex(e => new { e.InventItemId, e.ColorId, e.SizeId }).IsUnique(true);
            modelBuilder.Entity<InventDimGroup                                      >().HasIndex(e => e.Code).IsUnique(true);
            modelBuilder.Entity<InventItem                                          >().HasIndex(e => e.Code).IsUnique(true);
            modelBuilder.Entity<InventItemGroup                                     >().HasIndex(e => e.Code).IsUnique(true);
            modelBuilder.Entity<InventItemStoreConfiguration                        >().HasIndex(e => new { e.InventItemId , e.StoreId }).IsUnique(true);
            modelBuilder.Entity<InventModelGroup                                    >().HasIndex(e => e.Code).IsUnique(true);
            modelBuilder.Entity<ItemBarcode                                         >().HasIndex(e => e.Barcode).IsUnique(true);
            modelBuilder.Entity<ItemHierarchy                                       >().HasIndex(e => e.Code).IsUnique(true);
            modelBuilder.Entity<ItemSeasonalCategory                                >().HasIndex(e => e.Code).IsUnique(true);
            modelBuilder.Entity<Port                                                >().HasIndex(e => e.Code).IsUnique(true);
            modelBuilder.Entity<PurchOrderHeader                                    >().HasIndex(e => e.Code).IsUnique(true);
            modelBuilder.Entity<PurchOrderShipmentHeader                            >().HasIndex(e => e.Code).IsUnique(true);
            modelBuilder.Entity<PurchPaymentCondition                               >().HasIndex(e => e.Code).IsUnique(true);
            modelBuilder.Entity<PurchQuotation                                      >().HasIndex(e => e.Code).IsUnique(true);
            modelBuilder.Entity<PurchQuotationApproval                              >().HasIndex(e => e.Code).IsUnique(true);
            modelBuilder.Entity<PurchQuotationApprovalRule                          >().HasIndex(e => e.Code).IsUnique(true);
            modelBuilder.Entity<PurchQuotationApprovalRuleCondition                 >().HasIndex(e => e.Code).IsUnique(true);
            modelBuilder.Entity<SalesPrice                                          >().HasIndex(e => new { e.InventItemId, e.CustomerPriceGroupId }).IsUnique(true);
            modelBuilder.Entity<SalesPriceDefinition                                >().HasIndex(e => e.Code).IsUnique(true);
            //modelBuilder.Entity<SalesPriceDefinitionLine                            >().HasIndex(e => e.Code).IsUnique(true);
            modelBuilder.Entity<ShipmentContainer                                   >().HasIndex(e => new { e.PurchOrderShipmentHeaderId, e.ContainerNumber }).IsUnique(true);
            //modelBuilder.Entity<ShipmentContainerDetail                             >().HasIndex(e => e.Code).IsUnique(true);
            modelBuilder.Entity<ShipmentContainerType                               >().HasIndex(e => e.Description).IsUnique(true);
            modelBuilder.Entity<ShipmentImport                                      >().HasIndex(e => e.BLNumber).IsUnique(true);
            //modelBuilder.Entity<ShipmentLogEntry                                    >().HasIndex(e => e.Code).IsUnique(true);
            modelBuilder.Entity<ShipmentType                                        >().HasIndex(e => e.Description).IsUnique(true);
            modelBuilder.Entity<ShippingCompany                                     >().HasIndex(e => e.Name).IsUnique(true);
            modelBuilder.Entity<ShippingRoute                                       >().HasIndex(e => e.Code).IsUnique(true);
            modelBuilder.Entity<ShippingRouteStatusPresentationSchema               >().HasIndex(e => e.Description).IsUnique(true);
            //modelBuilder.Entity<ShippingRouteStep                                   >().HasIndex(e => e.Code).IsUnique(true);
            modelBuilder.Entity<ShippingStepType                                    >().HasIndex(e => e.Code).IsUnique(true);
            modelBuilder.Entity<Size                                                >().HasIndex(e => new { e.InventItemId, e.Code }).IsUnique(true);
            modelBuilder.Entity<Store                                               >().HasIndex(e => e.Code).IsUnique(true);
            modelBuilder.Entity<TaxItemGroupHeading                                 >().HasIndex(e => e.Code).IsUnique(true);
            modelBuilder.Entity<TaxOnItem                                           >().HasIndex(e => e.Code).IsUnique(true);
            modelBuilder.Entity<Unit                                                >().HasIndex(e => e.Code).IsUnique(true);
            modelBuilder.Entity<UnitConvert                                         >().HasIndex(e => new { e.InventItemId, e.FromUnitId, e.ToUnitId }).IsUnique(true);
            modelBuilder.Entity<UserSetting                                         >().HasIndex(e => e.Username).IsUnique(true);
            modelBuilder.Entity<Vendor                                              >().HasIndex(e => e.Code).IsUnique(true);
            modelBuilder.Entity<Warehouse                                           >().HasIndex(e => e.Code).IsUnique(true);
            modelBuilder.Entity<PurchCostDefinition                                 >().HasIndex(e => e.Code).IsUnique(true);
            modelBuilder.Entity<InventItemPrepackBarcode                            >().HasIndex(e => new { e.InventItemId, e.ItemBarcodeId }).IsUnique(true);
            modelBuilder.Entity<PurchOrderShipmentCrossDocking                      >().HasIndex(e => new { e.ShipmentContainerDetailId, e.StoreId }).IsUnique(true);
            modelBuilder.Entity<InventItemEnrolment                                 >().HasIndex(e => e.Code).IsUnique(true);

            modelBuilder.Entity<ExchangeRate>(entity =>
            {
                entity.HasIndex(e => new { e.CurrencyCode, e.StartDate, e.EndDate })
                    .HasName("UQ__Exchange__2A3F9F26711F63C1")
                    .IsUnique();

                entity.Property(e => e.CurrencyCode).IsRequired();

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.ExchangeRate1)
                    .HasColumnName("ExchangeRate")
                    .HasColumnType("numeric(9, 4)");

                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            modelBuilder.Entity<Supplies>(entity =>
            {
                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Percentage).HasColumnType("decimal(5, 2)");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
