using System;
using System.Linq;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DiunsaSCM.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DiunsaSCMContext _context;

        public UnitOfWork(DiunsaSCMContext context)
        {
            _context = context;
            PurchOrderHeaders = new PurchOrderHeaderRepository(_context);
            PurchOrderDetails = new PurchOrderDetailRepository(_context);
            PurchOrderShipmentHeaders = new PurchOrderShipmentHeaderRepository(_context);
            PurchOrderShipmentDetails = new PurchOrderShipmentDetailRepository(_context);

            ShipmentContainers = new ShipmentContainerRepository(_context);
            ShipmentContainerDetails = new ShipmentContainerDetailRepository(_context);
            ShipmentContainerTypes = new ShipmentContainerTypeRepository(_context);
            Ports = new PortRepository(_context);
            ShippingCompanies = new ShippingCompanyRepository(_context);

            Countries = new CountryRepository(_context);
            ShipmentLogEntries = new ShipmentLogEntryRepository(_context);
            ShippingRoutes = new ShippingRouteRepository(_context);
            ShippingRouteSteps = new ShippingRouteStepRepository(_context);
            ShippingStepTypes = new ShippingStepTypeRepository(_context);
            ShipmentImports = new ShipmentImportRepository(_context);
            Incoterms = new IncotermRepository(_context);

            Colors = new ColorRepository(_context);
            InventDimGroups = new InventDimGroupRepository(_context);
            InventItemGroups = new InventItemGroupRepository(_context);
            Stores = new StoreRepository(_context);
            InventDims = new InventDimRepository(_context);
            Sizes = new SizeRepository(_context);
            UnitConverts = new UnitConvertRepository(_context);
            TaxOnItems = new TaxOnItemRepository(_context);
            TaxItemGroupHeadings = new TaxItemGroupHeadingRepository(_context);
            Brands = new BrandRepository(_context);
            Units = new UnitRepository(_context);
            InventItems = new InventItemRepository(_context);
            ItemBarcodes = new ItemBarcodeRepository(_context);

            PurchQuotationApprovalRules = new PurchQuotationApprovalRuleRepository(_context);
            PurchQuotationApprovalRuleConditions = new PurchQuotationApprovalRuleConditionRepository(_context);
            PurchQuotationApprovalRuleConditionTerms = new PurchQuotationApprovalRuleConditionTermRepository(_context);
            PurchQuotationApprovalLogs = new PurchQuotationApprovalLogRepository(_context);
            PurchQuotations = new PurchQuotationRepository(_context);
            PurchQuotationLines = new PurchQuotationLineRepository(_context);
            PurchQuotationApprovals = new PurchQuotationApprovalRepository(_context);

            PurchOrderShipmentRouteStepSuscriptions = new PurchOrderShipmentRouteStepSuscriptionRepository(_context);
            ShippingRouteStatusPresentationSchemas = new ShippingRouteStatusPresentationSchemaRepository(_context);

            UserSettings = new UserSettingRepository(_context);
            ShipmentTypes = new ShipmentTypeRepository(_context);
            CommercialEvents = new CommercialEventRepository(_context);
            BarcodeSources = new BarcodeSourceRepository(_context);

            SalesPriceDefinitionLines = new SalesPriceDefinitionLineRepository(_context);
            CustomerPriceGroups = new CustomerPriceGroupRepository(_context);
            ItemHierarchies = new ItemHierarchyRepository(_context);
            Vendors = new VendorRepository(_context);
            EmployeeDiscounts = new EmployeeDiscountRepository(_context);
            SalesPrices = new SalesPriceRepository(_context);

            Currencies = new CurrencyRepository(_context);
            PurchPaymentConditions = new PurchPaymentConditionRepository(_context);
            ItemSeasonalCategories = new ItemSeasonalCategoryRepository(_context);
            InventItemStoreConfigurations = new InventItemStoreConfigurationRepository(_context);
            Warehouses = new WarehouseRepository(_context);
            PurchCostDefinitionLines = new PurchCostDefinitionLineRepository(_context);
            PurchCostDefinitions = new PurchCostDefinitionRepository(_context);
            PurchQuotationApprovalRoles = new PurchQuotationApprovalRoleRepository(_context);
            PurchQuotationApprovalRuleConditionSteps = new PurchQuotationApprovalRuleConditionStepRepository(_context);
            PurchQuotationLinePrepackDetails = new PurchQuotationLinePrepackDetailRepository(_context);
            PurchOrderShipmentCrossDockings = new PurchOrderShipmentCrossDockingRepository(_context);
            InventItemPrepackBarcodes = new InventItemPrepackBarcodeRepository(_context);
            InventItemPurchPriceLog = new InventItemPurchPriceLogRepository(_context);

            ExchangeRate = new ExchangeRateRepository(_context);
            Supplies = new SuppliesRepository(_context);
        }

        public IInventItemPrepackBarcodeRepository InventItemPrepackBarcodes { get; }
        public IPurchOrderShipmentCrossDockingRepository PurchOrderShipmentCrossDockings { get; }
        public IPurchQuotationLinePrepackDetailRepository PurchQuotationLinePrepackDetails { get; set; }
        public IPurchCostDefinitionLineRepository PurchCostDefinitionLines { get; set; }
        public IPurchCostDefinitionRepository PurchCostDefinitions { get; set; }
        public IWarehouseRepository Warehouses { get; set; }
        public IInventItemStoreConfigurationRepository InventItemStoreConfigurations { get; set; }
        public IItemSeasonalCategoryRepository ItemSeasonalCategories { get; set; }
        public ICurrencyRepository Currencies { get; set; }
        public IPurchPaymentConditionRepository PurchPaymentConditions { get; set; }
        public ISalesPriceRepository SalesPrices { get; set; }
        public IEmployeeDiscountRepository EmployeeDiscounts { get; set; }
        public IVendorRepository Vendors { get; set; }
        public IItemHierarchyRepository ItemHierarchies { get; set; }
        public IPurchOrderHeaderRepository PurchOrderHeaders { get; private set; }
        public IPurchOrderDetailRepository PurchOrderDetails { get; private set; }
        public IPurchOrderShipmentHeaderRepository PurchOrderShipmentHeaders { get; private set; }
        public IPurchOrderShipmentDetailRepository PurchOrderShipmentDetails { get; private set; }
        public IShipmentContainerRepository ShipmentContainers { get; private set; }
        public IShipmentContainerDetailRepository ShipmentContainerDetails { get; private set; }
        public IShippingCompanyRepository ShippingCompanies { get; set; }
        public IShipmentContainerTypeRepository ShipmentContainerTypes { get; set; }
        public IPortRepository Ports { get; set; }
        public ICountryRepository Countries { get; set; }
        public IShipmentLogEntryRepository ShipmentLogEntries { get; set; }
        public IShippingRouteRepository ShippingRoutes { get; set; }
        public IShippingRouteStepRepository ShippingRouteSteps { get; set; }
        public IShippingStepTypeRepository ShippingStepTypes { get; set; }
        public IShipmentImportRepository ShipmentImports { get; set; }
        public IIncotermRepository Incoterms { get; set; }

        public IColorRepository Colors { get; set; }
        public IInventDimGroupRepository InventDimGroups { get; set; }
        public IInventItemGroupRepository InventItemGroups { get; set; }
        public IStoreRepository Stores { get; set; }
        public IInventDimRepository InventDims { get; set; }
        public ISizeRepository Sizes { get; set; }
        public IUnitConvertRepository UnitConverts { get; set; }
        public ITaxOnItemRepository TaxOnItems { get; set; }
        public ITaxItemGroupHeadingRepository TaxItemGroupHeadings { get; set; }
        public IBrandRepository Brands { get; set; }
        public IUnitRepository Units { get; set; }

        public IPurchQuotationApprovalRuleRepository PurchQuotationApprovalRules { get; set; }
        public IPurchQuotationApprovalRuleConditionRepository PurchQuotationApprovalRuleConditions { get; set; }
        public IPurchQuotationApprovalRuleConditionTermRepository PurchQuotationApprovalRuleConditionTerms { get; set; }
        public IPurchQuotationApprovalLogRepository PurchQuotationApprovalLogs { get; set; }
        public IPurchQuotationRepository PurchQuotations { get; set; }
        public IPurchQuotationLineRepository PurchQuotationLines { get; set; }
        public IPurchQuotationApprovalRepository PurchQuotationApprovals { get; set; }

        public IPurchOrderShipmentRouteStepSuscriptionRepository PurchOrderShipmentRouteStepSuscriptions { get; set; }
        public IShippingRouteStatusPresentationSchemaRepository ShippingRouteStatusPresentationSchemas { get; set; }

        public IUserSettingRepository UserSettings { get; set; }
        public IShipmentTypeRepository ShipmentTypes { get; set; }
        public ICommercialEventRepository CommercialEvents { get; set; }
        public IItemBarcodeRepository ItemBarcodes { get; set; }
        public IInventItemRepository InventItems { get; set; }

        public IBarcodeSourceRepository BarcodeSources { get; set; }
        public ISalesPriceDefinitionLineRepository SalesPriceDefinitionLines { get; set; }
        public ICustomerPriceGroupRepository CustomerPriceGroups { get; set; }

        public IPurchQuotationApprovalRoleRepository PurchQuotationApprovalRoles { get; set; }
        public IPurchQuotationApprovalRuleConditionStepRepository PurchQuotationApprovalRuleConditionSteps { get; set; }

        public IInventItemPurchPriceLogRepository InventItemPurchPriceLog { get; set; }

        public IExchangeRateRepository ExchangeRate { get; set; }

        public ISuppliesRepository Supplies { get; set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
