using System;
using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Services;
using DiunsaSCM.Utils;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DiunsaSCM.Service
{
    public class PurchQuotationApprovalLogService : ServiceBase<PurchQuotationApprovalLog, PurchQuotationApprovalLogDTO>, IPurchQuotationApprovalLogService
    {

        private readonly IEmailService _emailService;

        public PurchQuotationApprovalLogService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<PurchQuotationApprovalLog> repository, IEmailService emailService)
            : base(mapper, unitOfWork, repository)
        {
            _emailService = emailService;
        }

        public override async Task<ServiceResult<IEnumerable<PurchQuotationApprovalLogDTO>>> GetAllByParentAsync(long parentId)
        {
            try
            {
                var entities = _repository.All()
                    .Where(x => x.PurchQuotationId == parentId);

                var entitieDTOs = entities.Select(x => _mapper.Map<PurchQuotationApprovalLogDTO>(x));

                return ServiceResult<IEnumerable<PurchQuotationApprovalLogDTO>>.SuccessResult(entitieDTOs);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<PurchQuotationApprovalLogDTO>>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }

        public override ServiceResult<PurchQuotationApprovalLogDTO> Add(PurchQuotationApprovalLogDTO model)
        {
            try
            {
                var purchQuotationApprovalLog = _mapper.Map<PurchQuotationApprovalLog>(model);

                PurchQuotation purchQuotation = _unitOfWork.PurchQuotations.All()
                .Include(x => x.PurchQuotationApprovalRuleCondition)
                .ThenInclude(x => x.PurchQuotationApprovalRuleConditionSteps)
                .FirstOrDefault(x => x.Id == purchQuotationApprovalLog.PurchQuotationId);

                bool sendNotificationToNextApprovals = false;

                if (purchQuotation.PurchQuotationApprovalRuleConditionStepId != model.PurchQuotationApprovalRuleConditionStepId)
                {
                    return ServiceResult<PurchQuotationApprovalLogDTO>.ErrorResult("El estado actual del flujo de aprobación es diferente al definido en la acción ejecutada.");
                }

                if (purchQuotationApprovalLog.PurchQuotationApprovalAction == Core.Enums.PurchQuotationApprovalAction.Aprobado) {
                    this.setPurchQuotationApprovalRuleConditionStep(purchQuotation, purchQuotationApprovalLog);
                    sendNotificationToNextApprovals = true;
                    if (purchQuotation.PurchQuotationApprovalRuleConditionId == null || purchQuotation.PurchQuotationApprovalRuleConditionStepId == null)
                    {
                        var purchOrderHeader = new PurchOrderHeader(purchQuotation, _unitOfWork);
                        _unitOfWork.PurchOrderHeaders.Add(purchOrderHeader);
                        purchQuotation.PurchOrderHeader = purchOrderHeader;
                        purchQuotation.PurchQuotationStatus = Core.Enums.PurchQuotationStatus.PurchOrderCreated;
                        sendNotificationToNextApprovals = false;
                    }
                }
                if (purchQuotationApprovalLog.PurchQuotationApprovalAction == Core.Enums.PurchQuotationApprovalAction.Rechazado)
                {
                    this.resetPurchQuotationApprovalRuleConditionSteps(purchQuotation, purchQuotationApprovalLog);
                    purchQuotation.PurchQuotationStatus = Core.Enums.PurchQuotationStatus.Open;
                }
                if (purchQuotationApprovalLog.PurchQuotationApprovalAction == Core.Enums.PurchQuotationApprovalAction.Revisar)
                {
                    purchQuotation.PurchQuotationStatus = Core.Enums.PurchQuotationStatus.Open;
                    
                }

                purchQuotationApprovalLog = _unitOfWork.PurchQuotationApprovalLogs.Add(purchQuotationApprovalLog);
                _unitOfWork.PurchQuotations.Update(purchQuotation);
                _unitOfWork.Complete();

                this.SendEmails(purchQuotation,purchQuotationApprovalLog, sendNotificationToNextApprovals);

                model = _mapper.Map<PurchQuotationApprovalLogDTO>(purchQuotationApprovalLog);
                return ServiceResult<PurchQuotationApprovalLogDTO>.SuccessResult(model);
            }
            catch (Exception ex)
            {
                return ServiceResult<PurchQuotationApprovalLogDTO>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos.");
            }
        }


        private void setPurchQuotationApprovalRuleConditionStep(PurchQuotation purchQuotation, PurchQuotationApprovalLog purchQuotationApprovalLog)
        {
            var steps = purchQuotation.PurchQuotationApprovalRuleCondition.PurchQuotationApprovalRuleConditionSteps;
            var currentStep = steps
                .FirstOrDefault(x => x.Id == purchQuotationApprovalLog.PurchQuotationApprovalRuleConditionStepId);
            var nextStep = steps
                .OrderBy(x => x.Order)
                .FirstOrDefault(x => x.Order >= currentStep.Order
                    && x.Id != currentStep.Id);

            if (nextStep == null)
            {
                purchQuotation.PurchQuotationApprovalRuleConditionStepId = null;
            }
            else
            {
                purchQuotation.PurchQuotationApprovalRuleConditionStepId = nextStep.Id;
            }
        }

        private void resetPurchQuotationApprovalRuleConditionSteps(PurchQuotation purchQuotation, PurchQuotationApprovalLog purchQuotationApprovalLog)
        {
            var steps = purchQuotation.PurchQuotationApprovalRuleCondition.PurchQuotationApprovalRuleConditionSteps;
            var nextStep = steps
                .OrderBy(x => x.Order)
                .FirstOrDefault();

            if (nextStep == null)
            {
                purchQuotation.PurchQuotationApprovalRuleConditionStepId = null;
            }
            else
            {
                purchQuotation.PurchQuotationApprovalRuleConditionStepId = nextStep.Id;
            }
        }

        private void SendEmails(PurchQuotation purchQuotation, PurchQuotationApprovalLog purchQuotationApprovalLog, bool sendNotificationToNextApprovals)
        {
            var approvalUsers = _unitOfWork.PurchQuotationApprovalRoles.All()
                    .Include(x => x.PurchQuotationApproval)
                    .Where(x => x.PurchCommercialDepartmentId == purchQuotation.PurchCommercialDepartmentId)
                    .ToList()
                    .Select(x => new {
                        x.PurchRoleId,
                        x.PurchCommercialDepartmentId,
                        Username = x.PurchQuotationApproval.Code,
                        UserSetting = _unitOfWork.UserSettings.All().FirstOrDefault(z => z.Username == x.PurchQuotationApproval.Code) })
                    .Where(x => x.UserSetting != null);

            var steps = purchQuotation.PurchQuotationApprovalRuleCondition.PurchQuotationApprovalRuleConditionSteps;
            var currentStep = steps
                .FirstOrDefault(x => x.Id == purchQuotationApprovalLog.PurchQuotationApprovalRuleConditionStepId);
            var previosSteps = steps
                .Where(x => x.Order <= currentStep.Order);
            var nextStep = steps
                .FirstOrDefault(x => x.Id == purchQuotation.PurchQuotationApprovalRuleConditionStepId);

            var previousUsers = approvalUsers
                .Where(x => previosSteps.Any(z => z.PurchRoleId == x.PurchRoleId));
            var nextUsers = approvalUsers
                .Where(x => nextStep != null && x.PurchRoleId == nextStep.PurchRoleId);

            string strLink = "http://dscm.diunsa.hn/purch-quotations/{0}/purch-quotation-lines";
            strLink = string.Format(strLink, purchQuotation.Id);

            string strSubject = "Actualización de flujo de Compras - {0} - {1}";
            strSubject = string.Format(strSubject, purchQuotation.Code, purchQuotation.Description);
            string strBody = "El usuario {0} ha actualizado el flujo de proceso de compras de {1} - {2} con estado: {3}. Puede acceder a la requisisicón de compras a través del enlace: {4}";
            string strPurchQuotationApprovalAction = _mapper.Map<string>(purchQuotationApprovalLog.PurchQuotationApprovalAction);
            strBody = string.Format(strBody, purchQuotationApprovalLog.CreatedBy, purchQuotation.Code, purchQuotation.Description, strPurchQuotationApprovalAction, strLink);

            foreach (var user in previousUsers)
            {
                string toAddress = user.UserSetting.Email;
                _emailService.Enqueue(new EmailDTO { Body = strBody, Subject = strSubject, ToAddress = toAddress });
            }

            var owners = _unitOfWork.UserSettings.All()
                .Where(z => !string.IsNullOrEmpty(z.Username)
                    && !string.IsNullOrEmpty(z.Email)
                    && (z.Username == purchQuotation.CreatedBy
                        || z.Username == purchQuotation.UpdatedBy));
            foreach (var user in owners)
            {
                string toAddress = user.Email;
                _emailService.Enqueue(new EmailDTO { Body = strBody, Subject = strSubject, ToAddress = toAddress });
            }

            if (sendNotificationToNextApprovals)
            {
                strSubject = "Solicitud de Aprobación de Compras - {0} - {1}";
                strSubject = string.Format(strSubject, purchQuotation.Code, purchQuotation.Description);
                strBody = "El proceso de compras {0} - {1} requiere su aprobación. Puede acceder a la requisisicón de compras a través del enlace: {2}";
                strBody = string.Format(strBody, purchQuotation.Code, purchQuotation.Description, strLink);
                foreach (var user in nextUsers)
                {
                    string toAddress = user.UserSetting.Email;
                    _emailService.Enqueue(new EmailDTO { Body = strBody, Subject = strSubject, ToAddress = toAddress });
                }
            }
            
        }
    }
}