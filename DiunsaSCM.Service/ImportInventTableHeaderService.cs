using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Enums;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Services;
using DiunsaSCM.Utils;
using Microsoft.EntityFrameworkCore;

namespace DiunsaSCM.Service
{
    public class ImportInventTableHeaderService : IImportInventTableHeaderService
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;


        public ImportInventTableHeaderService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        public ServiceResult<ImportInventTableHeaderDTO> AddList(ImportInventTableHeaderDTO modelList)
        {
            try
            {
                var itemHierarchies = _unitOfWork.ItemHierarchies.All()
                    .Include(x => x.Parent)
                    .ToList();
                var newInventItems = new List<InventItem>();
                var newColors = new List<Color>();
                var newSizes = new List<Size>();
                var newInventDims = new List<InventDim>();
                var newItemBarcodes = new List<ItemBarcode>();
                int nextLineNum = _unitOfWork.PurchQuotationLines.All().Where(x =>x.PurchQuotationId == modelList.PurchQuotationId).Max(x=> (int?)x.LineNum) ?? 0;
                int importLineNum = 2;
                foreach (var model in modelList.ImportInventTableLines)
                {
                    var vendorId = _unitOfWork.Vendors.All().FirstOrDefault(x => x.Code.ToLower() == model.Accountnum.ToLower())?.Id;

                    PurchQuotationLine purchQuotationLine = new PurchQuotationLine();
                    purchQuotationLine.PurchQuotationId = modelList.PurchQuotationId;
                    purchQuotationLine.PurchPrice = model.Costo;
                    purchQuotationLine.QtyOrdered = model.Cantidad;

                    var itemBarcode = _unitOfWork.ItemBarcodes.All()
                        .Include(x => x.InventItem)
                        .Include(x=> x.InventDim)
                        .ThenInclude(x => x.Color)
                        .Include(x => x.InventDim)
                        .ThenInclude(x => x.Size)
                        .Include(x => x.InventItem)
                        .ThenInclude(x => x.InventItemStoreConfigurations)
                        .Include(x => x.InventItem)
                        .ThenInclude(x => x.UnitConverts)
                        .FirstOrDefault(x => !String.IsNullOrEmpty(model.ItemBarcode) && x.Barcode == model.ItemBarcode);

                    if (itemBarcode == null)
                    {
                        itemBarcode = newItemBarcodes.FirstOrDefault(x => x.Barcode == model.ItemBarcode);
                    }

                    if (itemBarcode != null)
                    {
                        purchQuotationLine.ItemBarcode = itemBarcode;
                        purchQuotationLine.InventItem = itemBarcode.InventItem;
                        if (itemBarcode.InventDim != null)
                        {
                            purchQuotationLine.Color = itemBarcode.InventDim.Color;
                            purchQuotationLine.Size = itemBarcode.InventDim.Size;
                        }
                    }
                    else
                    {
                        /*if (!String.IsNullOrEmpty(model.ItemBarcode))
                        {
                            throw new Exception(String.Format("No existe el artículo con código de barras '{0}'.", model.ItemBarcode));
                        }*/

                        var inventItem = _unitOfWork.InventItems.All()
                            .Include(x => x.Colors)
                            .Include(x => x.Sizes)
                            .Include(x => x.InventDims)
                            .Include(x => x.InventItemStoreConfigurations)
                            .Include(x => x.UnitConverts)
                            .FirstOrDefault(x => (!String.IsNullOrEmpty(model.ItemId) && x.Code == model.ItemId)
                            || (!String.IsNullOrEmpty(model.NameAlias)
                                && x.NameAlias == model.NameAlias
                                && x.VendorId == vendorId));

                        if (inventItem == null)
                        {
                            inventItem = newInventItems.FirstOrDefault(x => x.NameAlias == model.NameAlias && x.VendorId == vendorId);
                        }

                        if (inventItem == null)
                        {
                            if (!String.IsNullOrEmpty(model.ItemId))
                            {
                                return ServiceResult<ImportInventTableHeaderDTO>.ErrorResult(String.Format("Error en la línea {0}. No existe el artículo con código '{1}'.", importLineNum, model.ItemId));
                            }

                            if (String.IsNullOrEmpty(model.NameAlias))
                            {
                                return ServiceResult<ImportInventTableHeaderDTO>.ErrorResult(String.Format("Error en la línea {0}. Debe definirse al menos un campo clave del artículo '{1}'.", importLineNum, model.ItemBarcode));
                            }

                            inventItem = new InventItem();
                            setInventItemProperties(inventItem, model, vendorId, itemHierarchies);
                            _unitOfWork.InventItems.Add(inventItem);
                            newInventItems.Add(inventItem);
                        }
                        
                        purchQuotationLine.InventItem = inventItem;

                        if (!String.IsNullOrEmpty(model.InventSizeId))
                        {
                            var size = _unitOfWork.Sizes.All()
                                .FirstOrDefault(x => x.Code == model.InventSizeId
                                    && x.InventItemId == purchQuotationLine.InventItem.Id);

                            if (size == null)
                            {
                                size = newSizes.FirstOrDefault(x => x.Code == model.InventSizeId
                                    && x.InventItem == purchQuotationLine.InventItem);
                            }

                            if (size == null)
                            {
                                size = new Size();
                                size.InventItem = inventItem;
                                size.Code = model.InventSizeId;
                                size.Description = model.SizeName;
                                if (purchQuotationLine.InventItem.Sizes == null)
                                {
                                    purchQuotationLine.InventItem.Sizes = new List<Size>();
                                }
                                purchQuotationLine.InventItem.Sizes.Add(size);
                                newSizes.Add(size);
                            }
                            purchQuotationLine.Size = size;
                        }
                        if (!String.IsNullOrEmpty(model.InventColorId))
                        {
                            var color = _unitOfWork.Colors.All()
                                .FirstOrDefault(x => x.Code == model.InventColorId
                                    && x.InventItemId == purchQuotationLine.InventItem.Id);

                            if (color == null)
                            {
                                color = newColors.FirstOrDefault(x => x.Code == model.InventColorId
                                    && x.InventItem == purchQuotationLine.InventItem);
                            }

                            if (color == null)
                            {
                                color = new Color();
                                color.InventItem = inventItem;
                                color.Code = model.InventColorId;
                                color.Description = model.ColorName;
                                if (purchQuotationLine.InventItem.Colors == null)
                                {
                                    purchQuotationLine.InventItem.Colors = new List<Color>();
                                }
                                purchQuotationLine.InventItem.Colors.Add(color);
                                newColors.Add(color);
                            }
                            purchQuotationLine.Color = color;
                        }
                        InventDim inventDim = null;
                        if (purchQuotationLine.Color != null || purchQuotationLine.Size != null)
                        {
                            inventDim = _unitOfWork.InventDims.All()
                                .Include(x => x.Color)
                                .Include(x => x.Size)
                                .Where(x => x.InventItemId == purchQuotationLine.InventItem.Id
                                    && ((String.IsNullOrEmpty(model.InventColorId) && x.ColorId == null)
                                        || x.Color.Code == model.InventColorId)
                                    && ((String.IsNullOrEmpty(model.InventSizeId) && x.SizeId == null)
                                        || x.Size.Code == model.InventSizeId)
                                ).FirstOrDefault();

                            if (inventDim == null)
                            {
                                inventDim = newInventDims
                                .Where(x => x.InventItem == purchQuotationLine.InventItem
                                    && ((String.IsNullOrEmpty(model.InventColorId) && x.ColorId == null)
                                        || x.Color.Code == model.InventColorId)
                                    && ((String.IsNullOrEmpty(model.InventSizeId) && x.SizeId == null)
                                        || x.Size.Code == model.InventSizeId)
                                ).FirstOrDefault();
                            }

                            if (inventDim == null)
                            {
                                inventDim = new InventDim();
                                inventDim.InventItem = purchQuotationLine.InventItem;
                                inventDim.Size = purchQuotationLine.Size;
                                inventDim.Color = purchQuotationLine.Color;
                                if (purchQuotationLine.InventItem.InventDims == null)
                                {
                                    purchQuotationLine.InventItem.InventDims = new List<InventDim>();
                                }
                                purchQuotationLine.InventItem.InventDims.Add(inventDim);
                                newInventDims.Add(inventDim);
                            }
                        }

                        if (itemBarcode == null && !String.IsNullOrEmpty(model.ItemBarcode))
                        {
                            itemBarcode = new ItemBarcode();
                            itemBarcode.InventItem = inventItem;
                            itemBarcode.InventDim = inventDim;
                            itemBarcode.Barcode = model.ItemBarcode;
                            if (purchQuotationLine.InventItem.ItemBarcodes == null)
                            {
                                purchQuotationLine.InventItem.ItemBarcodes = new List<ItemBarcode>();
                            }
                            purchQuotationLine.InventItem.ItemBarcodes.Add(itemBarcode);
                            newItemBarcodes.Add(itemBarcode);
                            purchQuotationLine.ItemBarcode = itemBarcode;
                        }
                    }

                    if (purchQuotationLine.InventItem.Id != 0)
                    {
                        setInventItemProperties(purchQuotationLine.InventItem, model, vendorId, itemHierarchies);
                        _unitOfWork.InventItems.Update(purchQuotationLine.InventItem);
                    }

                    setInventItemStoreConfigurations(purchQuotationLine.InventItem, model);
                    var unitConvertsValidation = setInventItemUnitConverts(purchQuotationLine.InventItem, model, importLineNum);
                    if (unitConvertsValidation.ResponseCode == ResponseCode.Error)
                    {
                        return ServiceResult<ImportInventTableHeaderDTO>.ErrorResult(unitConvertsValidation.Error);
                    }

                    purchQuotationLine.InventItemId = purchQuotationLine.InventItem.Id;
                    if (purchQuotationLine.Color != null)
                    {
                        purchQuotationLine.ColorId = purchQuotationLine.Color.Id;
                    }
                    if (purchQuotationLine.Size != null)
                    {
                        purchQuotationLine.SizeId = purchQuotationLine.Size.Id;
                    }
                    purchQuotationLine.LineNum = nextLineNum++;
                    
                    var purchQuotationLineValidation = purchQuotationLine.ValidateWrite();
                    if (purchQuotationLineValidation.ResponseCode == ResponseCode.Error)
                    {
                        return ServiceResult<ImportInventTableHeaderDTO>.ErrorResult(String.Format("Error en la línea {0}. {1}", importLineNum, purchQuotationLineValidation.Error));
                    }

                    _unitOfWork.PurchQuotationLines.Add(purchQuotationLine);
                    importLineNum++;
                }
                _unitOfWork.Complete();
                return ServiceResult<ImportInventTableHeaderDTO>.SuccessResult(modelList);
            }
            catch (Exception ex)
            {
                return ServiceResult<ImportInventTableHeaderDTO>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }

        private void setInventItemProperties(InventItem inventItem, ImportInventTableLineDataTransferObject model, long? vendorId, List<ItemHierarchy> itemHierarchies)
        {
            if (!String.IsNullOrEmpty(model.ItemName))
                inventItem.Description = model.ItemName;
            if (!String.IsNullOrEmpty(model.NameAlias))
                inventItem.NameAlias = model.NameAlias;
            if (!String.IsNullOrEmpty(model.Descripcion_Web))
                inventItem.WebSiteDescription = model.Descripcion_Web;

            if (model.Unidad_Grosor != 0)
                inventItem.GrossDepth = model.Unidad_Grosor;
            if (model.Unidad_Altura != 0)
                inventItem.GrossHeight = model.Unidad_Altura;
            if (model.Unidad_Anchura != 0)
                inventItem.GrossWidth = model.Unidad_Anchura;
            if (model.Unidad_Peso != 0)
                inventItem.GrossWeight = model.Unidad_Peso;

            if (!String.IsNullOrEmpty(model.InventDimGroupId))
                inventItem.InventDimGroupId = _unitOfWork.InventDimGroups.All().FirstOrDefault(x => x.Code.ToLower() == model.InventDimGroupId.ToLower())?.Id;
            if (!String.IsNullOrEmpty(model.Accountnum))
                inventItem.VendorId = vendorId;
            if (!String.IsNullOrEmpty(model.Descontable))
                inventItem.AllowDiscount = model.Descontable.ToUpper() == "S" || model.Descontable.ToUpper() == "SI";
            if (!String.IsNullOrEmpty(model.BrandId))
                inventItem.BrandId = _unitOfWork.Brands.All().FirstOrDefault(x => x.Code.ToLower() == model.BrandId.ToLower())?.Id;
            if (!String.IsNullOrEmpty(model.GrupoId))
            {
                var itemHierarchy = itemHierarchies.FirstOrDefault(x => x.Code.ToLower() == model.GrupoId.ToLower());
                if (itemHierarchy != null)
                {
                    inventItem.ItemHierarchyId = itemHierarchy.Id;
                    inventItem.InventItemGroupId = itemHierarchy.GetParentInventItemGroupId();
                }
            }
            if (!String.IsNullOrEmpty(model.TaxItemGroupId))
                inventItem.TaxItemGroupHeadingId = _unitOfWork.TaxItemGroupHeadings.All().FirstOrDefault(x => x.Code.ToLower() == model.TaxItemGroupId.ToLower())?.Id;
            if (!String.IsNullOrEmpty(model.DescuentoEmpl))
                inventItem.EmployeeDiscountId = _unitOfWork.EmployeeDiscounts.All().FirstOrDefault(x => x.Code.ToLower() == model.DescuentoEmpl.ToLower())?.Id;
            if (!String.IsNullOrEmpty(model.ClasificacionTemporada))
                inventItem.ItemSeasonalCategoryId = _unitOfWork.ItemSeasonalCategories.All().FirstOrDefault(x => x.Code.ToLower() == model.ClasificacionTemporada.ToLower())?.Id;
            inventItem.UME = (UME)model.ItemUME;
            inventItem.IsActive = true;
            inventItem.ItemType = ItemType.Product;
        }

        private void setInventItemStoreConfigurations(InventItem inventItem, ImportInventTableLineDataTransferObject model)
        {
            setInventItemStoreConfiguration(inventItem, "T1", model.CMR_T1);
            setInventItemStoreConfiguration(inventItem, "T2", model.CMR_T2);
            setInventItemStoreConfiguration(inventItem, "T3", model.CMR_T3);
            setInventItemStoreConfiguration(inventItem, "T4", model.CMR_T4);
            setInventItemStoreConfiguration(inventItem, "T5", model.CMR_T5);
            setInventItemStoreConfiguration(inventItem, "T6", model.CMR_T6);
            setInventItemStoreConfiguration(inventItem, "ECOM", model.CMR_ECOM);
            setInventItemStoreConfiguration(inventItem, "MAY", model.CMR_MAY);
        }

        private void setInventItemStoreConfiguration(InventItem inventItem, string storeCode, string storeValue)
        {
            var storeId = _unitOfWork.Stores.All().FirstOrDefault(x => x.Code == storeCode).Id;
            if (inventItem.InventItemStoreConfigurations == null)
            {
                inventItem.InventItemStoreConfigurations = new List<InventItemStoreConfiguration>();
            }
            var inventItemStoreConfiguration = inventItem.InventItemStoreConfigurations.FirstOrDefault(x => x.StoreId == storeId);
            if (inventItemStoreConfiguration == null)
            {
                inventItemStoreConfiguration = new InventItemStoreConfiguration();
                inventItemStoreConfiguration.InventItem = inventItem;
                inventItemStoreConfiguration.StoreId = storeId;
                inventItemStoreConfiguration.AllowToSell = (storeValue.ToUpper() == "S" || storeValue.ToUpper() == "SI");
                _unitOfWork.InventItemStoreConfigurations.Add(inventItemStoreConfiguration);
                inventItem.InventItemStoreConfigurations.Add(inventItemStoreConfiguration);
            }
            else if(inventItemStoreConfiguration.Id != 0)
            {
                inventItemStoreConfiguration.AllowToSell = (storeValue.ToUpper() == "S" || storeValue.ToUpper() == "SI");
                _unitOfWork.InventItemStoreConfigurations.Update(inventItemStoreConfiguration);
            }
        }

        private ServiceResult<InventItem> setInventItemUnitConverts(InventItem inventItem, ImportInventTableLineDataTransferObject model, int importLineNum)
        {
            ServiceResult<UnitConvert> serviceResult = ServiceResult<UnitConvert>.SuccessResult(default);
            serviceResult = setInventItemUnitConvert(inventItem, "Ud", "Cajita", model.Cajita, model.Cajita_Grosor, model.Cajita_Altura, model.Cajita_Anchura, model.Cajita_Peso, true);
            if (serviceResult.ResponseCode == ResponseCode.Error)
            {
                string errorMsg = String.Format("Error en la línea {0}. Dimensión '{1}': {2}", importLineNum, "Cajita", serviceResult.Error);
                return ServiceResult<InventItem>.ErrorResult(errorMsg);
            }

            serviceResult = setInventItemUnitConvert(inventItem, "Ud", "Caja", model.Caja, model.Caja_Grosor, model.Caja_Altura, model.Caja_Anchura, model.Caja_Peso, true);
            if (serviceResult.ResponseCode == ResponseCode.Error)
            {
                string errorMsg = String.Format("Error en la línea {0}. Dimensión: '{1}': {2}", importLineNum, "Caja", serviceResult.Error);
                return ServiceResult<InventItem>.ErrorResult(errorMsg);
            }

            if (model.Pallet != 0)
            {
                setInventItemUnitConvert(inventItem, "Ud", "Pallet", model.Pallet, model.Pallet_Grosor, model.Pallet_Altura, model.Pallet_Anchura, model.Pallet_Peso, false);
            }
            return ServiceResult<InventItem>.SuccessResult(inventItem);
        }

        private ServiceResult<UnitConvert> setInventItemUnitConvert(InventItem inventItem, string fromUnitCode, string toUnitCode,
            decimal factor, decimal grossDepth, decimal grossHeight, decimal grossWidth, decimal grossWeight, bool isRequired)
        {
            ServiceResult<UnitConvert> serviceResult = ServiceResult<UnitConvert>.SuccessResult(default);
            var fromUnitId = _unitOfWork.Units.All().FirstOrDefault(x => x.Code == fromUnitCode).Id;
            var toUnitId = _unitOfWork.Units.All().FirstOrDefault(x => x.Code == toUnitCode).Id;

            if (inventItem.UnitConverts == null)
            {
                inventItem.UnitConverts = new List<UnitConvert>();
            }
            var unitConvert = inventItem.UnitConverts
                .FirstOrDefault(x => x.FromUnitId == fromUnitId
                    && x.ToUnitId == toUnitId);

            if (unitConvert == null)
            {
                unitConvert = new UnitConvert();
                unitConvert.InventItem = inventItem;
                unitConvert.FromUnitId = fromUnitId;
                unitConvert.ToUnitId = toUnitId;
                serviceResult = setInventItemUnitConvertValues(unitConvert, factor, grossDepth, grossHeight, grossWidth, grossWeight, isRequired);
                _unitOfWork.UnitConverts.Add(unitConvert);
                inventItem.UnitConverts.Add(unitConvert);
            }
            else if (unitConvert.Id != 0)
            {
                serviceResult = setInventItemUnitConvertValues(unitConvert, factor, grossDepth, grossHeight, grossWidth, grossWeight, isRequired);
                _unitOfWork.UnitConverts.Update(unitConvert);
            }

            return serviceResult;
        }

        private ServiceResult<UnitConvert> setInventItemUnitConvertValues(UnitConvert unitConvert,
            decimal factor, decimal grossDepth, decimal grossHeight, decimal grossWidth, decimal grossWeight, bool isRequired)
        {
            if (factor != 0)
                unitConvert.Factor = factor;
            if (grossDepth != 0)
                unitConvert.GrossDepth = grossDepth;
            if (grossHeight != 0)
                unitConvert.GrossHeight = grossHeight;
            if (grossWidth != 0)
                unitConvert.GrossWidth = grossWidth;
            if (grossWeight != 0)
                unitConvert.GrossWeight = grossWeight;

            if (isRequired)
                return unitConvert.ValidateWrite();

            return ServiceResult<UnitConvert>.SuccessResult(unitConvert);
        }
    }

    
}
