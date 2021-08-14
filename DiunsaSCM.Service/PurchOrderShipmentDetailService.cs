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
using Microsoft.EntityFrameworkCore;
using DiunsaSCM.Utils;
using DiunsaSCMInterfaceERP.Core.Entities.ERPEntities;
using DiunsaSCM.Core.Repositories.ERPRepositories;

namespace DiunsaSCM.Service
{
    public class PurchOrderShipmentDetailService : IPurchOrderShipmentDetailService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IERPRepository<ERPReceiptDetail> _erpReceiptDetailRepository;

        public PurchOrderShipmentDetailService(IMapper mapper, IUnitOfWork unitOfWork, IERPRepository<ERPReceiptDetail> erpReceiptDetailRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _erpReceiptDetailRepository = erpReceiptDetailRepository;
        }

        public ServiceResult<PurchOrderShipmentDetailDataTransferObject> Add(PurchOrderShipmentDetailDataTransferObject purchOrderShipmentDetailDataTransferObject)
        {
            try
            {
                var purchOrderShipmentDetail = _mapper.Map<PurchOrderShipmentDetail>(purchOrderShipmentDetailDataTransferObject);

                _unitOfWork.PurchOrderShipmentDetails.Add(purchOrderShipmentDetail);
                _unitOfWork.Complete();

                purchOrderShipmentDetailDataTransferObject.Id = purchOrderShipmentDetail.Id;

                return ServiceResult<PurchOrderShipmentDetailDataTransferObject>.SuccessResult(purchOrderShipmentDetailDataTransferObject);
            }
            catch (Exception ex)
            {
                return ServiceResult<PurchOrderShipmentDetailDataTransferObject>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
            
        }

        public ServiceResult<PurchOrderShipmentDetailsListDataTransferObject> Add(PurchOrderShipmentDetailsListDataTransferObject purchOrderShipmentDetailsList)
        {
            try
            {
                foreach (PurchOrderShipmentDetailDataTransferObject purchOrderShipmentDetailDataTransferObject in purchOrderShipmentDetailsList.PurchOrderShipmentDetailList)
                {
                    var foundPurchOrderShipmentDetail = this.GetByPurchOrderDetailId(purchOrderShipmentDetailDataTransferObject.PurchOrderDetailId, purchOrderShipmentDetailsList.PurchOrderShipmentHeaderId);
                    if (foundPurchOrderShipmentDetail == null)
                    {
                        purchOrderShipmentDetailDataTransferObject.PurchOrderShipmentHeaderId = purchOrderShipmentDetailsList.PurchOrderShipmentHeaderId;
                        var purchOrderShipmentDetail = _mapper.Map<PurchOrderShipmentDetail>(purchOrderShipmentDetailDataTransferObject);
                        _unitOfWork.PurchOrderShipmentDetails.Add(purchOrderShipmentDetail);
                    }
                    else
                    {
                        foundPurchOrderShipmentDetail.QtyOnShipment = purchOrderShipmentDetailDataTransferObject.QtyOnShipment;
                    }
                }
                _unitOfWork.Complete();
                return ServiceResult<PurchOrderShipmentDetailsListDataTransferObject>.SuccessResult(purchOrderShipmentDetailsList);
            }
            catch (Exception ex)
            {
                return ServiceResult<PurchOrderShipmentDetailsListDataTransferObject>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
            
        }

        public ServiceResult<IEnumerable<PurchOrderShipmentDetailDataTransferObject>> GetAll()
        {
            throw new NotImplementedException();
        }

        public ServiceResult<PurchOrderShipmentDetailDataTransferObject> GetById(long id)
        {
            try
            {
                var purchOrderShipmentDetail = _unitOfWork.PurchOrderShipmentDetails.GetById(id);

                if (purchOrderShipmentDetail == null)
                {
                    return ServiceResult<PurchOrderShipmentDetailDataTransferObject>.ErrorResult($"No se ha encontrado el registro de Detalle de Envío de Pedido de Compras con el Id de Registro: {id}.");
                }

                var purchOrderShipmentDetailDataTransferObject = _mapper.Map<PurchOrderShipmentDetailDataTransferObject>(purchOrderShipmentDetail);

                return ServiceResult<PurchOrderShipmentDetailDataTransferObject>.SuccessResult(purchOrderShipmentDetailDataTransferObject);
            }
            catch (Exception ex)
            {
                return ServiceResult<PurchOrderShipmentDetailDataTransferObject>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }

        }

        public ServiceResult<IEnumerable<PurchOrderShipmentDetailDataTransferObject>> GetByPurchShipmentHeaderId(long purchOrderShipmentHeaderId)
        {
            try
            {
                var purchOrderShipmentHeader = _unitOfWork.PurchOrderShipmentHeaders.GetById(purchOrderShipmentHeaderId);
                var purchOrderHeader = _unitOfWork.PurchOrderHeaders.GetById(purchOrderShipmentHeader.PurchOrderHeaderId);
                var purchOrderShipmentDetails = _unitOfWork.PurchOrderShipmentDetails.GetByPurchOrderShipmentHeaderId(purchOrderShipmentHeaderId);

                /*var erpReceiptDetails = _erpReceiptDetailRepository.AllByFilterModel(new FilterPurchShipmentDTO {
                    PurchId = purchOrderHeader.Code,
                    PurchOrderShipmentHeaderId = purchOrderShipmentHeaderId
                }).ToList();
                */


                var purchOrderShipmentDetailDataTransferObjects = purchOrderShipmentDetails.Select(x => _mapper.Map<PurchOrderShipmentDetailDataTransferObject>(x));
                purchOrderShipmentDetailDataTransferObjects = purchOrderShipmentDetailDataTransferObjects.Select(x =>
                {
                    //x.QtyOnReceipt = erpReceiptDetails.Where(r => x.PurchOrderDetailId == r.ERPRecId).Select(r => r.Qty).FirstOrDefault();
                    return x;
                });

                return ServiceResult<IEnumerable<PurchOrderShipmentDetailDataTransferObject>>.SuccessResult(purchOrderShipmentDetailDataTransferObjects);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<PurchOrderShipmentDetailDataTransferObject>>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }

        }

        public PurchOrderShipmentDetail GetByPurchOrderDetailId(long purchOrderDetailId, long purchOrderShipmentId)
        {
            var purchOrderShipmentDetail = _unitOfWork.PurchOrderShipmentDetails.All()
                .FirstOrDefault(x => x.PurchOrderDetailId == purchOrderDetailId && x.PurchOrderShipmentHeaderId == purchOrderShipmentId);
            return purchOrderShipmentDetail;

        }

        public ServiceResult<PurchOrderShipmentDetailDataTransferObject> Delete(long id)
        {
            try
            {
                var purchOrderShipmentDetail = _unitOfWork.PurchOrderShipmentDetails.GetById(id);
                if (purchOrderShipmentDetail == null)
                {
                    return ServiceResult<PurchOrderShipmentDetailDataTransferObject>.ErrorResult($"No se ha encontrado el registro de Detalle de Envío de Pedido de Compras con el Id de Registro: {id}.");
                }

                purchOrderShipmentDetail = _unitOfWork.PurchOrderShipmentDetails.Delete(purchOrderShipmentDetail);
                _unitOfWork.Complete();

                var purchOrderShipmentDetailDataTransferObject = _mapper.Map<PurchOrderShipmentDetailDataTransferObject>(purchOrderShipmentDetail);

                return ServiceResult<PurchOrderShipmentDetailDataTransferObject>.SuccessResult(purchOrderShipmentDetailDataTransferObject);
            }
            catch (Exception ex)
            {
                return ServiceResult<PurchOrderShipmentDetailDataTransferObject>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }

        }

        public ServiceResult<PurchOrderShipmentDetailDataTransferObject> Update(PurchOrderShipmentDetailDataTransferObject purchOrderShipmentDetailDataTransferObject)
        {
            try
            {
                var purchOrderShipmentDetail = _mapper.Map<PurchOrderShipmentDetail>(purchOrderShipmentDetailDataTransferObject);

                purchOrderShipmentDetail = _unitOfWork.PurchOrderShipmentDetails.Update(purchOrderShipmentDetail);
                _unitOfWork.Complete();

                return ServiceResult<PurchOrderShipmentDetailDataTransferObject>.SuccessResult(purchOrderShipmentDetailDataTransferObject);
            }
            catch (Exception ex)
            {
                return ServiceResult<PurchOrderShipmentDetailDataTransferObject>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }

        }
    }
}
