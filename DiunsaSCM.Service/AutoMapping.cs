using System;
using AutoMapper;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Enums;

namespace DiunsaSCM.Core
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<string, string>().ConvertUsing(s => s ?? string.Empty);

            CreateMap<TransportationMethod, string>().ConvertUsing(src => src.ToString());
            CreateMap<PurchQuotationApprovalRuleConditionField, string>().ConvertUsing(src => src.ToString());
            CreateMap<PurchQuotationApprovalRuleConditionComparisonOperation, string>().ConvertUsing(src => src.ToString());
            CreateMap<ShippingStepERPAction, string>().ConvertUsing(src => src.ToString());
            CreateMap<ItemType, string>().ConvertUsing(src => src.ToString());
            CreateMap<SalesPriceDefinitionStatus, string>().ConvertUsing(src => src.ToString());
            CreateMap<VendorType, string>().ConvertUsing(src => src.ToString());
            CreateMap<ItemHierarchyLevel, string>().ConvertUsing(src => src.ToString());
            CreateMap<PurchQuotationApprovalAction, string>().ConvertUsing(src => src.ToString());

            CreateMap<PurchOrderShipmentHeader, PurchOrderShipmentHeaderDataTransferObject>()
                .ForMember(d => d.PurchId, o => o.MapFrom(s => s.PurchOrderHeader.Code))
                .ForMember(d => d.PurchName, o => o.MapFrom(s => s.PurchOrderHeader.PurchName))
                .ForMember(d => d.BLNumber, o => o.MapFrom(s => s.ShipmentImport.BLNumber))
                .ForMember(d => d.PreparationShippingRouteDescription, o => o.MapFrom(s => s.PreparationShippingRoute.Description));

            CreateMap<PurchOrderShipmentHeaderDataTransferObject, PurchOrderShipmentHeader>();
            CreateMap<PurchOrderShipmentDetail, PurchOrderShipmentDetailDataTransferObject>()
                .ForMember(d => d.PurchId, o => o.MapFrom(s => s.PurchOrderShipmentHeader.PurchOrderHeader.Code))
                .ForMember(d => d.BLNumber, o => o.MapFrom(s => s.PurchOrderShipmentHeader.ShipmentImport.BLNumber))
                .ForMember(d => d.ItemId, o => o.MapFrom(s => s.PurchOrderOrderDetail.ItemId))
                .ForMember(d => d.PurchUnit, o => o.MapFrom(s => s.PurchOrderOrderDetail.PurchUnit))
                .ForMember(d => d.QtyOrdered, o => o.MapFrom(s => s.PurchOrderOrderDetail.QtyOrdered))
                .ForMember(d => d.ItemName, o => o.MapFrom(s => s.PurchOrderOrderDetail.ItemName))
                .ForMember(d => d.NameAlias, o => o.MapFrom(s => s.PurchOrderOrderDetail.NameAlias))
                .ForMember(d => d.Barcode, o => o.MapFrom(s => s.PurchOrderOrderDetail.Barcode))
                .ForMember(d => d.InventColorId, o => o.MapFrom(s => s.PurchOrderOrderDetail.InventColorId))
                .ForMember(d => d.InventSizeId, o => o.MapFrom(s => s.PurchOrderOrderDetail.InventSizeId));
            CreateMap<PurchOrderShipmentDetailDataTransferObject, PurchOrderShipmentDetail>();

            CreateMap<ShipmentContainer, ShipmentContainerDataTransferObject>()
                .ForMember(d => d.PurchId, o => o.MapFrom(s => s.PurchOrderShipmentHeader.PurchOrderHeader.Code))
                .ForMember(d => d.BLNumber, o => o.MapFrom(s => s.PurchOrderShipmentHeader.ShipmentImport.BLNumber));
            CreateMap<ShipmentContainerDataTransferObject, ShipmentContainer>();
            CreateMap<ShipmentContainerDetail, ShipmentContainerDetailDataTransferObject>()
                .ForMember(d => d.PurchId, o => o.MapFrom(s => s.ShipmentContainer.PurchOrderShipmentHeader.PurchOrderHeader.Code))
                .ForMember(d => d.BLNumber, o => o.MapFrom(s => s.ShipmentContainer.PurchOrderShipmentHeader.ShipmentImport.BLNumber))
                .ForMember(d => d.ContainerNumber, o => o.MapFrom(s => s.ShipmentContainer.ContainerNumber))
                .ForMember(d => d.ItemId, o => o.MapFrom(s => s.PurchOrderOrderDetail.ItemId))
                .ForMember(d => d.PurchUnit, o => o.MapFrom(s => s.PurchOrderOrderDetail.PurchUnit))
                .ForMember(d => d.QtyOrdered, o => o.MapFrom(s => s.PurchOrderOrderDetail.QtyOrdered))
                .ForMember(d => d.ItemName, o => o.MapFrom(s => s.PurchOrderOrderDetail.ItemName))
                .ForMember(d => d.NameAlias, o => o.MapFrom(s => s.PurchOrderOrderDetail.NameAlias))
                .ForMember(d => d.Barcode, o => o.MapFrom(s => s.PurchOrderOrderDetail.Barcode))
                .ForMember(d => d.InventColorId, o => o.MapFrom(s => s.PurchOrderOrderDetail.InventColorId))
                .ForMember(d => d.InventSizeId, o => o.MapFrom(s => s.PurchOrderOrderDetail.InventSizeId));
            CreateMap<ShipmentContainerDetailDataTransferObject, ShipmentContainerDetail>();

            CreateMap<ShipmentContainerType, ShipmentContainerTypeDataTransferObject>();
            CreateMap<ShipmentContainerTypeDataTransferObject, ShipmentContainerType>();
            CreateMap<Port, PortDataTransferObject>()
                .ForMember(d => d.CountryName, o => o.MapFrom(s => s.Country.Name));
            CreateMap<PortDataTransferObject, Port>();
            CreateMap<ShippingCompany, ShippingCompanyDataTransferObject>();
            CreateMap<ShippingCompanyDataTransferObject, ShippingCompany>();

            CreateMap<PurchOrderDetailDTO, PurchOrderDetail>();
            CreateMap<PurchOrderDetail, PurchOrderDetailDTO>();

            CreateMap<Country, CountryDataTransferObject>();
            CreateMap<CountryDataTransferObject, Country>();
            CreateMap<ShipmentLogEntry, ShipmentLogEntryDataTransferObject>()
                .ForMember(d => d.ShippingRouteStepDescription, o => o.MapFrom(s => s.ShippingRouteStep.ShippingStepType.Description));
            CreateMap<ShipmentLogEntryDataTransferObject, ShipmentLogEntry>();
            CreateMap<ShippingRoute, ShippingRouteDTO> ()
                .ForMember(d => d.PortOfOriginName, o => o.MapFrom(s => s.PortOfOrigin.Name))
                .ForMember(d => d.PortOfDestinationName, o => o.MapFrom(s => s.PortOfDestination.Name))
                .ForMember(d => d.ShippingRouteStatusPresentationSchemaDescription, o => o.MapFrom(s => s.ShippingRouteStatusPresentationSchema.Description));
            CreateMap<ShippingRouteDTO, ShippingRoute>();
            CreateMap<ShippingRouteStep, ShippingRouteStepDataTransferObject> ()
                .ForMember(d => d.ShippingStepTypeDescription, o => o.MapFrom(s => s.ShippingStepType.Description)); ;
            CreateMap<ShippingRouteStepDataTransferObject, ShippingRouteStep>();
            CreateMap<ShippingStepType, ShippingStepTypeDTO>()
                .ForMember(d => d.ShippingStepERPActionDescription, o => o.MapFrom(s => s.ShippingStepERPAction));
            CreateMap<ShippingStepTypeDTO, ShippingStepType>();

            CreateMap<ShipmentImport, ShipmentImportDTO>();
            CreateMap<ShipmentImportDTO, ShipmentImport>();

            CreateMap<ShippingRouteStep, ShippingRouteTimelineEntry>()
                .ForMember(d => d.ShippingStepTypeDescription, o => o.MapFrom(s => s.ShippingStepType.Description))
                .ForMember(d => d.ShippingRouteDescription, o => o.MapFrom(s => s.ShippingRoute.Description))
                .ForMember(d => d.EstimatedTransitTimeDays, o => o.MapFrom(s => s.TransitTimeDays));

            CreateMap<Incoterm, IncotermDTO>();
            CreateMap<IncotermDTO, Incoterm>();

            CreateMap<Unit, UnitDTO>();
            CreateMap<UnitDTO, Unit>();
            CreateMap<Brand, BrandDTO>();
            CreateMap<BrandDTO, Brand>();
            CreateMap<TaxItemGroupHeading, TaxItemGroupHeadingDTO>();
            CreateMap<TaxItemGroupHeadingDTO, TaxItemGroupHeading>();
            CreateMap<TaxOnItem, TaxOnItemDTO>();
            CreateMap<TaxOnItemDTO, TaxOnItem>();
            CreateMap<UnitConvert, UnitConvertDTO>();
            CreateMap<UnitConvertDTO, UnitConvert>();
            CreateMap<Size, SizeDTO>();
            CreateMap<SizeDTO, Size>();
            CreateMap<InventDim, InventDimDTO>()
                .ForMember(d => d.Description,
                    o => o.MapFrom(s => String.Format("Talla:{0} - Color:{1}", (s.Size != null ? s.Size.Code : ""), (s.Color != null ? s.Color.Code : ""))));

            CreateMap<InventDimDTO, InventDim>();
            CreateMap<Store, StoreDTO>();
            CreateMap<StoreDTO, Store>();
            CreateMap<InventItemGroup, InventItemGroupDTO>();
            CreateMap<InventItemGroupDTO, InventItemGroup>();
            CreateMap<InventDimGroup, InventDimGroupDTO>();
            CreateMap<InventDimGroupDTO, InventDimGroup>();
            CreateMap<Color, ColorDTO>();
            CreateMap<ColorDTO, Color>();

            CreateMap<PurchQuotationApproval, PurchQuotationApprovalDTO>();
            CreateMap<PurchQuotationApprovalDTO, PurchQuotationApproval>();
            CreateMap<PurchQuotationApprovalRule, PurchQuotationApprovalRuleDTO>();
            CreateMap<PurchQuotationApprovalRuleDTO, PurchQuotationApprovalRule>();
            CreateMap<PurchQuotationApprovalRuleCondition, PurchQuotationApprovalRuleConditionDTO>();
            CreateMap<PurchQuotationApprovalRuleConditionDTO, PurchQuotationApprovalRuleCondition>();
            CreateMap<PurchQuotationApprovalRuleConditionTerm, PurchQuotationApprovalRuleConditionTermDTO>()
                .ForMember(d => d.PurchQuotationApprovalRuleConditionFieldDescription, o => o.MapFrom(s => s.PurchQuotationApprovalRuleConditionField))
                .ForMember(d => d.PurchQuotationApprovalRuleConditionComparisonOperationDescription, o => o.MapFrom(s => s.PurchQuotationApprovalRuleConditionComparisonOperation));
            CreateMap<PurchQuotationApprovalRuleConditionTermDTO, PurchQuotationApprovalRuleConditionTerm>();
            CreateMap<PurchQuotationApprovalLog, PurchQuotationApprovalLogDTO>()
                .ForMember(d => d.PurchQuotationApprovalActionDescription, o => o.MapFrom(s => s.PurchQuotationApprovalAction));
            CreateMap<PurchQuotationApprovalLogDTO, PurchQuotationApprovalLog>();
            CreateMap<PurchQuotation, PurchQuotationDTO>();
            CreateMap<PurchQuotationDTO, PurchQuotation>();
            CreateMap<PurchQuotationLine, PurchQuotationLineDTO>()
                .ForMember(d => d.InventItemItemTypeDescription, o => o.MapFrom(s => s.InventItem.ItemType));
            CreateMap<PurchQuotationLineDTO, PurchQuotationLine>();

            CreateMap<PurchOrderShipmentRouteStepSuscription, PurchOrderShipmentRouteStepSuscriptionDTO>()
                .ForMember(d => d.ShippingRouteStepDescription, o => o.MapFrom(s => s.ShippingRouteStep.ShippingStepType.Description))
                .ForMember(d => d.PurchId, o => o.MapFrom(s => s.PurchOrderShipmentHeader.PurchOrderHeader.Code))
                .ForMember(d => d.PurchName, o => o.MapFrom(s => s.PurchOrderShipmentHeader.PurchOrderHeader.PurchName));
            CreateMap<PurchOrderShipmentRouteStepSuscriptionDTO, PurchOrderShipmentRouteStepSuscription>();
            CreateMap<ShippingRouteStatusPresentationSchema, ShippingRouteStatusPresentationSchemaDTO>();
            CreateMap<ShippingRouteStatusPresentationSchemaDTO, ShippingRouteStatusPresentationSchema>();

            CreateMap<UserSetting, UserSettingDTO>();
            CreateMap<UserSettingDTO, UserSetting>();
            CreateMap<ShipmentType, ShipmentTypeDTO > ();
            CreateMap<ShipmentTypeDTO, ShipmentType>();
            CreateMap<CommercialEvent, CommercialEventDTO> ();
            CreateMap<CommercialEventDTO, CommercialEvent>();

            CreateMap<InventItem, InventItemDTO>();
            CreateMap<InventItemDTO, InventItem>();

            CreateMap<Vendor, VendorDTO>()
                .ForMember(d => d.VendorTypeDescription, o => o.MapFrom(s => s.VendorType));
            CreateMap<VendorDTO, Vendor>();
            CreateMap<EmployeeDiscount, EmployeeDiscountDTO>();
            CreateMap<EmployeeDiscountDTO, EmployeeDiscount>();
            CreateMap<InventItemStoreConfiguration, InventItemStoreConfigurationDTO>();
            CreateMap<InventItemStoreConfigurationDTO, InventItemStoreConfiguration>();
            CreateMap<InventModelGroup, InventModelGroupDTO>();
            CreateMap<InventModelGroupDTO, InventModelGroup>();
            CreateMap<ItemHierarchy, ItemHierarchyDTO>()
                .ForMember(d => d.ParentCode, o => o.MapFrom(s => s.Parent.Code))
                .ForMember(d => d.ItemHierarchyLevelDescription, o => o.MapFrom(s => s.ItemHierarchyLevel));
            CreateMap<ItemHierarchyDTO, ItemHierarchy>();

            CreateMap<PurchOrderHeader, PurchOrderHeaderDTO>()
                .ForMember(d => d.PurchId, o => o.MapFrom(s => s.Code));
            CreateMap<PurchOrderHeaderDTO, PurchOrderHeader>()
                .ForMember(d => d.Code, o => o.MapFrom(s => s.PurchId)); ;
            CreateMap<PurchOrderDetail, PurchOrderDetailDTO>();
            CreateMap<PurchOrderDetailDTO, PurchOrderDetail>();

            CreateMap<SalesPrice, SalesPriceDTO>();
            CreateMap<SalesPriceDTO, SalesPrice>();
            CreateMap<SalesPriceDefinition, SalesPriceDefinitionDTO>()
                .ForMember(d => d.SalesPriceDefinitionStatusDescription, o => o.MapFrom(s => s.SalesPriceDefinitionStatus));
            CreateMap<SalesPriceDefinitionDTO, SalesPriceDefinition>();
            CreateMap<SalesPriceDefinitionLine, SalesPriceDefinitionLineDTO>();
            CreateMap<SalesPriceDefinitionLineDTO, SalesPriceDefinitionLine>();
            CreateMap<Barcode, BarcodeDTO>();
            CreateMap<BarcodeDTO, Barcode>();
            CreateMap<BarcodeBatch, BarcodeBatchDTO>();
            CreateMap<BarcodeBatchDTO, BarcodeBatch>();
            CreateMap<BarcodeSource, BarcodeSourceDTO>();
            CreateMap<BarcodeSourceDTO, BarcodeSource>();
            CreateMap<CustomerPriceGroup, CustomerPriceGroupDTO>();
            CreateMap<CustomerPriceGroupDTO, CustomerPriceGroup>();

            CreateMap<ItemBarcode, ItemBarcodeDTO>()
                .ForMember(d => d.InventDimDescription,
                    o => o.MapFrom(s => String.Format("Talla:{0} - Color:{1}", (s.InventDim.Size !=null ? s.InventDim.Size.Code : ""), (s.InventDim.Color != null ? s.InventDim.Color.Code : ""))));
            CreateMap<ItemBarcodeDTO, ItemBarcode>();

            CreateMap<PurchPaymentCondition, PurchPaymentConditionDTO>();
            CreateMap<PurchPaymentConditionDTO, PurchPaymentCondition>();
            CreateMap<Currency, CurrencyDTO>();
            CreateMap<CurrencyDTO, Currency>();

            CreateMap<ItemSeasonalCategory, ItemSeasonalCategoryDTO>();
            CreateMap<ItemSeasonalCategoryDTO, ItemSeasonalCategory>();
            CreateMap<Warehouse, WarehouseDTO>();
            CreateMap<WarehouseDTO, Warehouse>();

            CreateMap<PurchCostDefinition, PurchCostDefinitionDTO>();
            CreateMap<PurchCostDefinitionDTO, PurchCostDefinition>();
            CreateMap<PurchCostDefinitionLine, PurchCostDefinitionLineDTO>();
            CreateMap<PurchCostDefinitionLineDTO, PurchCostDefinitionLine>();

            CreateMap<PurchCommercialDepartment, PurchCommercialDepartmentDTO>();
            CreateMap<PurchCommercialDepartmentDTO, PurchCommercialDepartment>();
            CreateMap<PurchRole, PurchRoleDTO>();
            CreateMap<PurchRoleDTO, PurchRole>();
            CreateMap<PurchQuotationApprovalRole, PurchQuotationApprovalRoleDTO>();
            CreateMap<PurchQuotationApprovalRoleDTO, PurchQuotationApprovalRole>();
            CreateMap<PurchQuotationApprovalRuleConditionStep, PurchQuotationApprovalRuleConditionStepDTO>();
            CreateMap<PurchQuotationApprovalRuleConditionStepDTO, PurchQuotationApprovalRuleConditionStep>();

            CreateMap<PurchOrderShipmentCrossDocking, PurchOrderShipmentCrossDockingDTO>();
            CreateMap<PurchOrderShipmentCrossDockingDTO, PurchOrderShipmentCrossDocking>();
            CreateMap<InventItemPrepackBarcode, InventItemPrepackBarcodeDTO>();
            CreateMap<InventItemPrepackBarcodeDTO, InventItemPrepackBarcode>();

            CreateMap<PurchQuotation, PurchApprovalWorkDTO>();

            CreateMap<PurchQuotationLinePrepackDetail, PurchQuotationLinePrepackDetailDTO>();
            CreateMap<PurchQuotationLinePrepackDetailDTO, PurchQuotationLinePrepackDetail>();

            CreateMap<CommercialAgreement, CommercialAgreementDTO>();
            CreateMap<CommercialAgreementDTO, CommercialAgreement>();
            CreateMap<VendorItemHierarchy, VendorItemHierarchyDTO>();
            CreateMap<VendorItemHierarchyDTO, VendorItemHierarchy>();
            CreateMap<PurchRoleItemHierarchy, PurchRoleItemHierarchyDTO>();
            CreateMap<PurchRoleItemHierarchyDTO, PurchRoleItemHierarchy>();
            CreateMap<PurchQuotationCreator, PurchQuotationCreatorDTO>();
            CreateMap<PurchQuotationCreatorDTO, PurchQuotationCreator>();
            CreateMap<PurchQuotationCreatorRole, PurchQuotationCreatorRoleDTO>();
            CreateMap<PurchQuotationCreatorRoleDTO, PurchQuotationCreatorRole>();
            CreateMap<InventItemPurchPriceLog, InventItemPurchPriceLogDTO>()
                .ForMember(d => d.PurchQuotationCode, o => o.MapFrom(s => s.PurchQuotationLine.PurchQuotation.Code));
            CreateMap<InventItemPurchPriceLogDTO, InventItemPurchPriceLog>();
            CreateMap<InventItemEnrolment, InventItemEnrolmentDTO>();
            CreateMap<InventItemEnrolmentDTO, InventItemEnrolment>();
            CreateMap<InventItemEnrolmentDetail, InventItemEnrolmentDetailDTO>();
            CreateMap<InventItemEnrolmentDetailDTO, InventItemEnrolmentDetail>();

        }
    }
}
