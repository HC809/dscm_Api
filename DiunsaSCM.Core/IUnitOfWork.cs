using System;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;

namespace DiunsaSCM.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IPurchOrderHeaderRepository PurchOrderHeaders { get; }
        IPurchOrderDetailRepository PurchOrderDetails { get; }
        IPurchOrderShipmentHeaderRepository PurchOrderShipmentHeaders { get; }
        IPurchOrderShipmentDetailRepository PurchOrderShipmentDetails { get; }
        IShipmentContainerRepository ShipmentContainers { get; }
        IShipmentContainerDetailRepository ShipmentContainerDetails { get;  }
        IShippingCompanyRepository ShippingCompanies { get; }
        IShipmentContainerTypeRepository ShipmentContainerTypes { get; set; }
        IPortRepository Ports { get; set; }
        ICountryRepository Countries { get; set; }
        IShipmentLogEntryRepository ShipmentLogEntries { get; set; }
        IShippingRouteRepository ShippingRoutes { get; set; }
        IShippingRouteStepRepository ShippingRouteSteps { get; set; }
        IShippingStepTypeRepository ShippingStepTypes { get; set; }
        IShipmentImportRepository ShipmentImports { get; set; }

        IPurchOrderShipmentRouteStepSuscriptionRepository PurchOrderShipmentRouteStepSuscriptions { get; set; }

        IUserSettingRepository UserSettings { get; set; }
        IShipmentTypeRepository ShipmentTypes { get; set; }
        ICommercialEventRepository CommercialEvents { get; set; }


        IInventItemRepository InventItems { get; set; }
        IItemBarcodeRepository ItemBarcodes { get; set; }
        IColorRepository Colors { get; set; }
        ISizeRepository Sizes { get; set; }

        IBarcodeSourceRepository BarcodeSources { get; set; }
        ISalesPriceDefinitionLineRepository SalesPriceDefinitionLines { get; set; }
        ISalesPriceRepository SalesPrices { get; set; }

        ICustomerPriceGroupRepository CustomerPriceGroups { get; set; }
        IPurchQuotationLineRepository PurchQuotationLines { get; set; }
        IInventDimGroupRepository InventDimGroups { get; set; }
        IItemHierarchyRepository ItemHierarchies { get; set; }
        IVendorRepository Vendors { get; set; }
        IBrandRepository Brands { get; set; }
        ITaxItemGroupHeadingRepository TaxItemGroupHeadings { get; set; }
        IEmployeeDiscountRepository EmployeeDiscounts { get; set; }

        IInventDimRepository InventDims { get; set; }
        IPurchQuotationRepository PurchQuotations { get; set; }

        ICurrencyRepository Currencies { get; set; }
        IPurchPaymentConditionRepository PurchPaymentConditions { get; set; }

        IItemSeasonalCategoryRepository ItemSeasonalCategories { get; set; }
        IInventItemStoreConfigurationRepository InventItemStoreConfigurations { get; set; }

        IStoreRepository Stores { get; set; }
        IWarehouseRepository Warehouses { get; set; }
        IUnitConvertRepository UnitConverts { get; set; }
        IUnitRepository Units { get; set; }
        IPurchCostDefinitionLineRepository PurchCostDefinitionLines { get; set; }
        IPurchCostDefinitionRepository PurchCostDefinitions { get; set; }
        IPurchQuotationApprovalRepository PurchQuotationApprovals { get; }
        IPurchQuotationApprovalRoleRepository PurchQuotationApprovalRoles { get; }
        IPurchQuotationApprovalRuleConditionRepository PurchQuotationApprovalRuleConditions { get; }
        IPurchQuotationApprovalRuleConditionStepRepository PurchQuotationApprovalRuleConditionSteps { get; }
        IPurchQuotationApprovalLogRepository PurchQuotationApprovalLogs { get; }
        IShippingRouteStatusPresentationSchemaRepository ShippingRouteStatusPresentationSchemas { get; }
        IPurchQuotationLinePrepackDetailRepository PurchQuotationLinePrepackDetails { get; }
        IPurchOrderShipmentCrossDockingRepository PurchOrderShipmentCrossDockings { get; }
        IInventItemPrepackBarcodeRepository InventItemPrepackBarcodes { get; }
        IInventItemPurchPriceLogRepository InventItemPurchPriceLog { get; }

        int Complete();
    }
}
