using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using DiunsaSCM.Data;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Utils;
using Microsoft.EntityFrameworkCore;

namespace DiunsaSCM.Service
{
    public class PurchOrderShipmentHeaderService : IPurchOrderShipmentHeaderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PurchOrderShipmentHeaderService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ServiceResult<PurchOrderShipmentHeaderDataTransferObject> Add(PurchOrderShipmentHeaderDataTransferObject purchOrderShipmentHeaderDataTransferObject)
        {
            try
            {
                var purchOrderShipmentHeader = _mapper.Map<PurchOrderShipmentHeader>(purchOrderShipmentHeaderDataTransferObject);
                purchOrderShipmentHeader.DateCreated = DateTime.Now;

                _unitOfWork.PurchOrderShipmentHeaders.Add(purchOrderShipmentHeader);
                _unitOfWork.Complete();

                purchOrderShipmentHeaderDataTransferObject.Id = purchOrderShipmentHeader.Id;

                return ServiceResult<PurchOrderShipmentHeaderDataTransferObject>.SuccessResult(purchOrderShipmentHeaderDataTransferObject);
            }
            catch (Exception ex)
            {
                return ServiceResult<PurchOrderShipmentHeaderDataTransferObject>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        } 

        public ServiceResult<IEnumerable<PurchOrderShipmentHeaderDataTransferObject>> GetAll(string searchString)
        {
            try
            {
                var purchOrderShipments = _unitOfWork.PurchOrderShipmentHeaders.All(searchString)
                    .Select(x => _mapper.Map<PurchOrderShipmentHeaderDataTransferObject>(x));

                return ServiceResult<IEnumerable<PurchOrderShipmentHeaderDataTransferObject>>.SuccessResult(purchOrderShipments);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<PurchOrderShipmentHeaderDataTransferObject>>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }           
        }

        public ServiceResult<PurchOrderShipmentHeaderDataTransferObject> GetById(long id)
        {
            try
            {
                var purchOrderShipmentHeader = _unitOfWork.PurchOrderShipmentHeaders.GetById(id);
                var purchOrderShipmentHeaderDataTransferObject = _mapper.Map<PurchOrderShipmentHeaderDataTransferObject>(purchOrderShipmentHeader);
                return ServiceResult<PurchOrderShipmentHeaderDataTransferObject>.SuccessResult(purchOrderShipmentHeaderDataTransferObject);
            }
            catch (Exception ex)
            {
                return ServiceResult<PurchOrderShipmentHeaderDataTransferObject>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
            
        }

        public ServiceResult<IEnumerable<PurchOrderShipmentHeaderDataTransferObject>> GetByPurchOrdertHeaderId(long purchOrdertHeaderId)
        {
            try
            {
                var purchOrderShipments = _unitOfWork.PurchOrderShipmentHeaders.All()
                    .Include(x => x.ShipmentImport)
                    .Include(x => x.PurchOrderHeader)
                    .Where(x => x.PurchOrderHeaderId == purchOrdertHeaderId)
                    .Select(x => _mapper.Map<PurchOrderShipmentHeaderDataTransferObject>(x));

                return ServiceResult<IEnumerable<PurchOrderShipmentHeaderDataTransferObject>>.SuccessResult(purchOrderShipments);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<PurchOrderShipmentHeaderDataTransferObject>>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }                 
        }

        public ServiceResult<PurchOrderShipmentHeaderDataTransferObject> Delete(long id)
        {
            try
            {
                var purchOrderShipmentHeader = _unitOfWork.PurchOrderShipmentHeaders.GetById(id);
                purchOrderShipmentHeader = _unitOfWork.PurchOrderShipmentHeaders.Delete(purchOrderShipmentHeader);
                _unitOfWork.Complete();

                var PurchOrderShipmentDetailDataTransferObject = _mapper.Map<PurchOrderShipmentHeaderDataTransferObject>(purchOrderShipmentHeader);

                return ServiceResult<PurchOrderShipmentHeaderDataTransferObject>.SuccessResult(PurchOrderShipmentDetailDataTransferObject);
            }
            catch (Exception ex)
            {
                return ServiceResult<PurchOrderShipmentHeaderDataTransferObject>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }          
        }

        public ServiceResult<PurchOrderShipmentHeaderDataTransferObject> Update(PurchOrderShipmentHeaderDataTransferObject purchOrderShipmentHeaderDataTransferObject)
        {
            try
            {
                var purchOrderShipmentHeader = _mapper.Map<PurchOrderShipmentHeader>(purchOrderShipmentHeaderDataTransferObject);
                purchOrderShipmentHeader = _unitOfWork.PurchOrderShipmentHeaders.Update(purchOrderShipmentHeader);
                _unitOfWork.Complete();

                return ServiceResult<PurchOrderShipmentHeaderDataTransferObject>.SuccessResult(purchOrderShipmentHeaderDataTransferObject);
            }
            catch (Exception ex)
            {
                return ServiceResult<PurchOrderShipmentHeaderDataTransferObject>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }

        public ServiceResult<IEnumerable<PurchOrderShipmentHeaderDataTransferObject>> GetByShipmentImportId(long shipmentImportId)
        {
            try
            {
                var purchOrderShipments = _unitOfWork.PurchOrderShipmentHeaders.GetByShipmentImportId(shipmentImportId)
                                .Select(x => _mapper.Map<PurchOrderShipmentHeaderDataTransferObject>(x));

                return ServiceResult<IEnumerable<PurchOrderShipmentHeaderDataTransferObject>>.SuccessResult(purchOrderShipments);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<PurchOrderShipmentHeaderDataTransferObject>>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
            
        }

        public ServiceResult<IEnumerable<PurchOrderShipmentHeaderDataTransferObject>> GetAllByFilterModel(FilterBaseDTO filterModel)
        {
            try
            {
                FilterPurchOrderShipmentDTO filterPurchOrderShipmentDTO = filterModel as FilterPurchOrderShipmentDTO;
                var query = _unitOfWork.PurchOrderShipmentHeaders.All()
                    .Include(x => x.PurchOrderHeader)
                    .Include(x => x.PurchOrderHeader)
                    .Include(x => x.ShippingRoute)
                    .ThenInclude(x => x.ShippingRouteSteps)
                    .ThenInclude(x => x.ShippingStepType)
                    .Include(x => x.PreparationShippingRoute)
                    .ThenInclude(x => x.ShippingRouteSteps)
                    .ThenInclude(x => x.ShippingStepType)
                    .Include(x => x.ShipmentImport)
                    .Include(x => x.ShipmentLogEntries)
                    .ThenInclude(x => x.ShippingRouteStep)
                    .ThenInclude(x => x.ShippingStepType)
                    .Include(x => x.ShipmentContainers)
                    .Include(x => x.ShippingCompany)
                    .Include(x => x.ShipmentType)
                    .Include(x => x.PurchOrderShipmentDetails)
                    .ThenInclude(x => x.PurchOrderOrderDetail)
                    .Where(x => string.IsNullOrEmpty(filterPurchOrderShipmentDTO.Code) || x.Code.Contains(filterPurchOrderShipmentDTO.Code))
                    .Where(x => string.IsNullOrEmpty(filterPurchOrderShipmentDTO.PurchId) || x.PurchOrderHeader.Code.Contains(filterPurchOrderShipmentDTO.PurchId))
                    .Where(x => string.IsNullOrEmpty(filterPurchOrderShipmentDTO.VendorAccount) || x.PurchOrderHeader.VendorAccount.Contains(filterPurchOrderShipmentDTO.VendorAccount))
                    .Where(x => string.IsNullOrEmpty(filterPurchOrderShipmentDTO.PurchName) || x.PurchOrderHeader.PurchName.Contains(filterPurchOrderShipmentDTO.PurchName))
                    .Where(x => string.IsNullOrEmpty(filterPurchOrderShipmentDTO.BLNumber) || x.ShipmentImport.BLNumber.Contains(filterPurchOrderShipmentDTO.BLNumber))
                    .Where(x => string.IsNullOrEmpty(filterPurchOrderShipmentDTO.ShippingCompanyName) || x.ShippingCompany.Name.Contains(filterPurchOrderShipmentDTO.ShippingCompanyName))
                    .Where(x => string.IsNullOrEmpty(filterPurchOrderShipmentDTO.InvoiceNumber) || x.InvoiceNumber.Contains(filterPurchOrderShipmentDTO.InvoiceNumber))
                    .Where(x => string.IsNullOrEmpty(filterPurchOrderShipmentDTO.Username)
                        || x.CreatedBy.Contains(filterPurchOrderShipmentDTO.Username)
                        || x.UpdatedBy.Contains(filterPurchOrderShipmentDTO.Username)
                        || x.PurchOrderHeader.CreatedBy.Contains(filterPurchOrderShipmentDTO.Username)
                        || x.PurchOrderHeader.UpdatedBy.Contains(filterPurchOrderShipmentDTO.Username))
                    .Where(x => string.IsNullOrEmpty(filterPurchOrderShipmentDTO.Barcode) || x.PurchOrderShipmentDetails.Any(z => z.PurchOrderOrderDetail.Barcode.Contains(filterPurchOrderShipmentDTO.Barcode)))
                    .Where(x => string.IsNullOrEmpty(filterPurchOrderShipmentDTO.ContainerNumber) || x.ShipmentContainers.Any(z => z.ContainerNumber.Contains(filterPurchOrderShipmentDTO.ContainerNumber)))
                    .OrderByDescending(x => x.Id);
                    
                var modelList = query.Select(x => _mapper.Map<PurchOrderShipmentHeaderDataTransferObject>(x));

                return ServiceResult<IEnumerable<PurchOrderShipmentHeaderDataTransferObject>>.SuccessResult(modelList);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<PurchOrderShipmentHeaderDataTransferObject>>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }
    }
}
