using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Enums;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Providers;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Services;
using DiunsaSCM.Utils;
using Microsoft.EntityFrameworkCore;

namespace DiunsaSCM.Service
{
    public class PurchQuotationService : ServiceBase<PurchQuotation, PurchQuotationDTO>, IPurchQuotationService
    {
        private SessionProvider _sessionProvider;
        private readonly IEmailService _emailService;

        public PurchQuotationService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<PurchQuotation> repository, SessionProvider sessionProvider, IEmailService emailService)
            : base(mapper, unitOfWork, repository)
        {
            _sessionProvider = sessionProvider;
            _emailService = emailService;
        }

        public ServiceResult<PurchQuotationDTO> GetById(long id)
        {
            try
            {
                var approvalRoles = _unitOfWork.PurchQuotationApprovalRoles.All()
                    .Include(x => x.PurchQuotationApproval)
                    .Where(x => x.PurchQuotationApproval.Code == _sessionProvider.Session.Username)
                    .ToList();

                var entity = _repository.All()
                    .Include(x => x.PurchQuotationApprovalRuleConditionStep)
                    .FirstOrDefault(x=> x.Id == id);

                var model = _mapper.Map<PurchQuotationDTO>(entity);

                if (entity.PurchQuotationStatus == Core.Enums.PurchQuotationStatus.PendingApproval
                    && entity.PurchQuotationApprovalRuleConditionStep != null
                    && approvalRoles.Any(z => z.PurchCommercialDepartmentId == entity.PurchCommercialDepartmentId
                        && z.PurchRoleId == entity.PurchQuotationApprovalRuleConditionStep.PurchRoleId))
                {
                    model.IsCurrentApproval = true;
                }
                else
                {
                    model.IsCurrentApproval = false;
                }
                
                return ServiceResult<PurchQuotationDTO>.SuccessResult(model);
            }
            catch (Exception ex)
            {
                return ServiceResult<PurchQuotationDTO>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos.");
            }
        }

        public ServiceResult<PurchQuotationDTO> Update(PurchQuotationDTO model)
        {
            try
            {
                var entity = _mapper.Map<PurchQuotation>(model);

                /*var entityCurrentValue = _repository.GetById(model.Id);
                if (entityCurrentValue.PurchQuotationStatus != Core.Enums.PurchQuotationStatus.Open)
                {
                    return ServiceResult<PurchQuotationDTO>.ErrorResult("El estado actual del registro no permite modificaciones.");
                }*/

                if (entity.PurchQuotationStatus == Core.Enums.PurchQuotationStatus.Completed)
                {
                    entity.PurchQuotationStatus = Core.Enums.PurchQuotationStatus.PendingApproval;
                    if (entity.PurchQuotationApprovalRuleConditionId == null || entity.PurchQuotationApprovalRuleConditionStepId == null)
                    {
                        setPurchQuotationApprovalRuleCondition(entity);
                        if (entity.PurchQuotationApprovalRuleConditionId == null || entity.PurchQuotationApprovalRuleConditionStepId == null)
                        {
                            var purchOrderHeader = new PurchOrderHeader(entity, _unitOfWork);
                            _unitOfWork.PurchOrderHeaders.Add(purchOrderHeader);
                            entity.PurchOrderHeader = purchOrderHeader;
                            entity.PurchQuotationStatus = Core.Enums.PurchQuotationStatus.PurchOrderCreated;

                            this.updatePurchPrices(entity);
                        }
                    }
                }

                _unitOfWork.PurchQuotations.Update(entity);
                _unitOfWork.PurchQuotations.SaveChanges();

                if (entity.PurchQuotationStatus == Core.Enums.PurchQuotationStatus.PendingApproval)
                {
                    SendEmails(entity);
                }

                return ServiceResult<PurchQuotationDTO>.SuccessResult(model);
            }
            catch (Exception ex)
            {
                return ServiceResult<PurchQuotationDTO>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos.");
            }
        }

        private void updatePurchPrices(PurchQuotation purchQuotation)
        {
            foreach (var purchQuotationLine in purchQuotation.PurchQuotationLines)
            {
                var inventItemPurchPriceLog = new InventItemPurchPriceLog();
                inventItemPurchPriceLog.InventItemId = purchQuotationLine.InventItemId;
                inventItemPurchPriceLog.PurchQuotationLineId = purchQuotationLine.Id;
                inventItemPurchPriceLog.PurchPrice = purchQuotationLine.PurchPrice;
                _unitOfWork.InventItemPurchPriceLog.Add(inventItemPurchPriceLog);

                var inventItem = _unitOfWork.InventItems.GetById(purchQuotationLine.InventItemId);
                inventItem.PurchPrice = purchQuotationLine.PurchPrice;
                _unitOfWork.InventItems.Update(inventItem);
            }
        }

        private void setPurchQuotationApprovalRuleCondition(PurchQuotation purchQuotation)
        {
            if (purchQuotation.PurchCommercialDepartmentId == null)
            {
                return;
            }

            var purchQuotationApprovalRuleConditions = _unitOfWork.PurchQuotationApprovalRuleConditions.All()
                .Include(x => x.PurchQuotationApprovalRuleConditionSteps)
                .Include(x => x.PurchQuotationApprovalRuleConditionTerms)
                .OrderBy(x => x.Priority)
                .ToList();

            PurchQuotationApprovalRuleCondition purchQuotationApprovalRuleCondition= purchQuotationApprovalRuleConditions
                .Where(x => x.IsActive
                    && validateTerms(purchQuotation, x.PurchQuotationApprovalRuleConditionTerms))
                .FirstOrDefault();

            if (purchQuotationApprovalRuleCondition == null)
            {
                return;
            }
            
            purchQuotation.PurchQuotationApprovalRuleConditionId = purchQuotationApprovalRuleCondition.Id;
            purchQuotation.PurchQuotationApprovalRuleConditionStepId = purchQuotationApprovalRuleCondition.PurchQuotationApprovalRuleConditionSteps
                .OrderBy(x => x.Order)
                .First()
                .Id;
        }

        private bool validateTerms(PurchQuotation purchQuotation, IEnumerable<PurchQuotationApprovalRuleConditionTerm> purchQuotationApprovalRuleConditionTerms)
        {
            foreach(var term in purchQuotationApprovalRuleConditionTerms)
            {
                decimal value = 0;
                bool termValidation = false;

                if (term.PurchQuotationApprovalRuleConditionField == PurchQuotationApprovalRuleConditionField.TotalAmount)
                    value = _unitOfWork.PurchQuotationLines.All()
                        .Where(x => x.PurchQuotationId == purchQuotation.Id)
                        .Sum(x => x.LineAmount);

                if (term.PurchQuotationApprovalRuleConditionComparisonOperation == PurchQuotationApprovalRuleConditionComparisonOperation.Equal
                    && value == term.LowerBound)
                    return true;

                if (term.PurchQuotationApprovalRuleConditionComparisonOperation == PurchQuotationApprovalRuleConditionComparisonOperation.GreaterThan
                    && value > term.LowerBound)
                    return true;

                if (term.PurchQuotationApprovalRuleConditionComparisonOperation == PurchQuotationApprovalRuleConditionComparisonOperation.GreaterThanOrEqualTo
                    && value >= term.LowerBound)
                    return true;

                if (term.PurchQuotationApprovalRuleConditionComparisonOperation == PurchQuotationApprovalRuleConditionComparisonOperation.LessThan
                    && value < term.UpperBound)
                    return true;

                if (term.PurchQuotationApprovalRuleConditionComparisonOperation == PurchQuotationApprovalRuleConditionComparisonOperation.LessThanOrEqualTo
                    && value <= term.UpperBound)
                    return true;

                if (term.PurchQuotationApprovalRuleConditionComparisonOperation == PurchQuotationApprovalRuleConditionComparisonOperation.LessThanOrEqualTo
                    && value <= term.UpperBound)
                    return true;

                if (term.PurchQuotationApprovalRuleConditionComparisonOperation == PurchQuotationApprovalRuleConditionComparisonOperation.Between
                    && value >= term.LowerBound
                    && value <= term.UpperBound)
                    return true;
            }
            return true;
        }


        private void SendEmails(PurchQuotation purchQuotation)
        {
            var approvalUsers = _unitOfWork.PurchQuotationApprovalRoles.All()
                    .Include(x => x.PurchQuotationApproval)
                    .Where(x => x.PurchCommercialDepartmentId == purchQuotation.PurchCommercialDepartmentId)
                    .ToList()
                    .Select(x => new {
                        x.PurchRoleId,
                        x.PurchCommercialDepartmentId,
                        Username = x.PurchQuotationApproval.Code,
                        UserSetting = _unitOfWork.UserSettings.All().FirstOrDefault(z => z.Username == x.PurchQuotationApproval.Code)
                    })
                    .Where(x => x.UserSetting != null);

            var nextStep = _unitOfWork.PurchQuotationApprovalRuleConditionSteps.All()
                .FirstOrDefault(x => x.Id == purchQuotation.PurchQuotationApprovalRuleConditionStepId);

            var nextUsers = approvalUsers
                .Where(x => nextStep != null && x.PurchRoleId == nextStep.PurchRoleId);

            string strLink = "http://dscm.diunsa.hn/purch-quotations/{0}/purch-quotation-lines";
            strLink = string.Format(strLink, purchQuotation.Id);

            string strSubject = "Solicitud de Aprobación de Compras - {0} - {1}";
            strSubject = string.Format(strSubject, purchQuotation.Code, purchQuotation.Description);
            string strBody = "El proceso de compras {0} - {1} requiere su aprobación. Puede acceder a la requisisicón de compras a través del enlace: {2}";
            strBody = string.Format(strBody, purchQuotation.Code, purchQuotation.Description, strLink);
            foreach (var user in nextUsers)
            {
                string toAddress = user.UserSetting.Email;
                _emailService.Enqueue(new EmailDTO { Body = strBody, Subject = strSubject, ToAddress = toAddress });
            }
            

        }


    }
}