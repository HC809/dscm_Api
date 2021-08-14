using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using DiunsaSCM.Utils;
using Microsoft.EntityFrameworkCore;

namespace DiunsaSCM.Service
{
    public class ShipmentLogEntryService : IShipmentLogEntryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public ShipmentLogEntryService(IMapper mapper, IUnitOfWork unitOfWork, IEmailService emailService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _emailService = emailService;
        }

        public ServiceResult<ShipmentLogEntryDataTransferObject> Add(long purchOrderHeaderId, long purchOrderShimentHeaderId, ShipmentLogEntryDataTransferObject shipmentLogEntryDataTransferObject)
        {
            try
            {
                var shipmentLogEntry = _mapper.Map<ShipmentLogEntry>(shipmentLogEntryDataTransferObject);
                shipmentLogEntry = _unitOfWork.ShipmentLogEntries.Add(shipmentLogEntry);
                _unitOfWork.Complete();

                shipmentLogEntryDataTransferObject.Id = shipmentLogEntry.Id;

                var shipmentLogEntryInfo = _unitOfWork.ShipmentLogEntries.GetById(shipmentLogEntry.Id);

                string strLink = "http://dscm.diunsa.hn/purch-orders/{0}/purch-order-shipments/{1}";
                strLink = string.Format(strLink, shipmentLogEntryInfo.PurchOrderShipmentHeader.PurchOrderHeaderId, shipmentLogEntryInfo.PurchOrderShipmentHeaderId);
                string strBody = "Se ha agregado un registro a la bitácora del envío. Puede acceder al envío utilizando el enlace: {0}";
                strBody = string.Format(strBody, strLink);

                string strSubject = String.Format("{0}-{1} {2}", shipmentLogEntryInfo.PurchOrderShipmentHeader.PurchOrderHeader.Code,
                                                          shipmentLogEntryInfo.PurchOrderShipmentHeader.Id.ToString("D8"),
                                                          shipmentLogEntryInfo.ShippingRouteStep.ShippingStepType.Description);

                SendEmails(shipmentLogEntry.ShippingRouteStepId, strSubject, strBody);

                return ServiceResult<ShipmentLogEntryDataTransferObject>.SuccessResult(shipmentLogEntryDataTransferObject);
            }
            catch (Exception ex)
            {
                return ServiceResult<ShipmentLogEntryDataTransferObject>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }

        public ServiceResult<ShipmentLogEntryDataTransferObject> Delete(long purchOrderHeaderId, long purchOrderShimentHeaderId, long id)
        {
            try
            {
                var shipmentLogEntry = _unitOfWork.ShipmentLogEntries.GetById(id);
                var shipmentLogEntryDataTransferObject = _mapper.Map<ShipmentLogEntryDataTransferObject>(shipmentLogEntry);

                var shipmentLogEntryInfo = _unitOfWork.ShipmentLogEntries.GetById(shipmentLogEntry.Id);

                string strLink = "http://dscm.diunsa.hn/purch-orders/{0}/purch-order-shipments/{1}";
                strLink = string.Format(strLink, shipmentLogEntryInfo.PurchOrderShipmentHeader.PurchOrderHeaderId, shipmentLogEntryInfo.PurchOrderShipmentHeaderId);
                string strBody = "Se ha eliminado un registro de la bitácora del envío. Puede acceder al envío utilizando el enlace: {0}";
                strBody = string.Format(strBody, strLink);

                string strSubject = String.Format("{0}-{1} {2}", shipmentLogEntryInfo.PurchOrderShipmentHeader.PurchOrderHeader.Code,
                                                          shipmentLogEntryInfo.PurchOrderShipmentHeader.Id.ToString("D8"),
                                                          shipmentLogEntryInfo.ShippingRouteStep.ShippingStepType.Description);

                _unitOfWork.ShipmentLogEntries.Delete(shipmentLogEntry);
                _unitOfWork.Complete();

                SendEmails(shipmentLogEntry.ShippingRouteStepId, strSubject, strBody);

                return ServiceResult<ShipmentLogEntryDataTransferObject>.SuccessResult(shipmentLogEntryDataTransferObject);
            }
            catch (Exception ex)
            {
                return ServiceResult<ShipmentLogEntryDataTransferObject>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }

        public ServiceResult<IEnumerable<ShipmentLogEntryDataTransferObject>> GetAll(long purchOrderHeaderId, long purchOrderShimentHeaderId)
        {
            try
            {
                var shipmentLogEntries = _unitOfWork.ShipmentLogEntries.All()
                    .Where(x => x.PurchOrderShipmentHeaderId == purchOrderShimentHeaderId)
                    .Include(x => x.ShippingRouteStep)
                    .ThenInclude(x => x.ShippingStepType);
                var shipmentLogEntriesDataTransferObject = shipmentLogEntries.Select(x => _mapper.Map<ShipmentLogEntryDataTransferObject>(x));
                return ServiceResult<IEnumerable<ShipmentLogEntryDataTransferObject>>.SuccessResult(shipmentLogEntriesDataTransferObject);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<ShipmentLogEntryDataTransferObject>>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }

        public ServiceResult<ShipmentLogEntryDataTransferObject> GetById(long purchOrderHeaderId, long purchOrderShimentHeaderId, long id)
        {
            try
            {
                var shipmentLogEntry = _unitOfWork.ShipmentLogEntries.GetById(id);
                var shipmentLogEntryDataTransferObject = _mapper.Map<ShipmentLogEntryDataTransferObject>(shipmentLogEntry);
                return ServiceResult<ShipmentLogEntryDataTransferObject>.SuccessResult(shipmentLogEntryDataTransferObject);
            }
            catch (Exception ex)
            {
                return ServiceResult<ShipmentLogEntryDataTransferObject>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }

        public ServiceResult<ShipmentLogEntryDataTransferObject> Update(long purchOrderHeaderId, long purchOrderShimentHeaderId, ShipmentLogEntryDataTransferObject shippingStepTypeDataTransferObject)
        {
            try
            {
                var shipmentLogEntry = _mapper.Map<ShipmentLogEntry>(shippingStepTypeDataTransferObject);
                shipmentLogEntry = _unitOfWork.ShipmentLogEntries.Update(shipmentLogEntry);
                _unitOfWork.Complete();

                var shipmentLogEntryInfo = _unitOfWork.ShipmentLogEntries.GetById(shipmentLogEntry.Id);

                string strLink = "http://dscm.diunsa.hn/purch-orders/{0}/purch-order-shipments/{1}";
                strLink = string.Format(strLink, shipmentLogEntryInfo.PurchOrderShipmentHeader.PurchOrderHeaderId, shipmentLogEntryInfo.PurchOrderShipmentHeaderId);
                string strBody = "Se ha modificado un registro de la bitácora del envío. Puede acceder al envío utilizando el enlace: {0}";
                strBody = string.Format(strBody, strLink);
                string strSubject = String.Format("{0}-{1} {2}", shipmentLogEntryInfo.PurchOrderShipmentHeader.PurchOrderHeader.Code,
                                                          shipmentLogEntryInfo.PurchOrderShipmentHeader.Id.ToString("D8"),
                                                          shipmentLogEntryInfo.ShippingRouteStep.ShippingStepType.Description);

                SendEmails(shipmentLogEntry.ShippingRouteStepId, strSubject, strBody);

                return ServiceResult<ShipmentLogEntryDataTransferObject>.SuccessResult(shippingStepTypeDataTransferObject);
            }
            catch (Exception ex)
            {
                return ServiceResult<ShipmentLogEntryDataTransferObject>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }

        private void SendEmails(long shippingRouteStepId, string strSubject, string strBody)
        {
            

            var suscriptions = _unitOfWork.PurchOrderShipmentRouteStepSuscriptions
                    .GetAllByShippingRouteStepId(shippingRouteStepId)
                    .ToList();

            var emails = _unitOfWork.UserSettings.All().AsEnumerable()
                .Where(u => suscriptions.Any(s => u.Username == s.Username))
                .Select(u => new EmailDTO
                {
                    ToAddress = u.Email,
                    Subject = strSubject,
                    Body = strBody,
                }).ToList();

            foreach (var email in emails)
            {
                _emailService.Enqueue(email);
            }
        }
    }
}
