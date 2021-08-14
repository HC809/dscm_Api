using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Enums;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using DiunsaSCM.Utils;
using Microsoft.EntityFrameworkCore;

namespace DiunsaSCM.Service
{
    public class ShippingRouteTimelineEntryService : IShippingRouteTimelineEntryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ShippingRouteTimelineEntryService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public ServiceResult<IEnumerable<ShippingRouteTimelineEntry>> GetAllByPurchOrderShimentHeaderId(long purchOrderShimentHeaderId)
        {
            try
            {
                var purchOrderShimentHeader = _unitOfWork.PurchOrderShipmentHeaders.GetById(purchOrderShimentHeaderId);

                List<ShippingRouteTimelineEntry> preparationShippingRouteTimeLineEntries = new List<ShippingRouteTimelineEntry>();
                List<ShippingRouteTimelineEntry> shippingRouteTimeLineEntries = new List<ShippingRouteTimelineEntry>();
                if (purchOrderShimentHeader.PreparationShippingRoute != null)
                {
                    preparationShippingRouteTimeLineEntries = purchOrderShimentHeader.PreparationShippingRoute.ShippingRouteSteps
                        .OrderBy(x => x.StepNumber)
                        .Select(x => _mapper.Map<ShippingRouteTimelineEntry>(x))
                        .ToList();
                }
                if (purchOrderShimentHeader.ShippingRoute != null)
                {
                    shippingRouteTimeLineEntries = purchOrderShimentHeader.ShippingRoute.ShippingRouteSteps
                        .OrderBy(x => x.StepNumber)
                        .Select(x => _mapper.Map<ShippingRouteTimelineEntry>(x))
                        .ToList();
                }

                List<ShippingRouteTimelineEntry> shippingRouteTimeLineList = preparationShippingRouteTimeLineEntries.Concat(shippingRouteTimeLineEntries).ToList();

                int estimatedTransitTimeDaysAcumulated = 0;
                //DateTime startDate = purchOrderShimentHeader.PurchOrderHeader.CreatedDatetime;
                DateTime startDate = purchOrderShimentHeader.DateCreated;
                DateTime lastExecutionDate = startDate;
                DateTime lastStimatedDate = startDate;
                bool onExcecutionStepFound = false;
                int i = 0;
                foreach (ShippingRouteTimelineEntry entry in shippingRouteTimeLineList)
                {
                    estimatedTransitTimeDaysAcumulated += entry.EstimatedTransitTimeDays;
                    entry.EstimatedTransitTimeDaysAcumulated = estimatedTransitTimeDaysAcumulated;
                    entry.EstimatedDate = startDate.AddDays(entry.EstimatedTransitTimeDaysAcumulated);
                    entry.FromDateStimated = lastStimatedDate;
                    lastStimatedDate = entry.EstimatedDate;
                    entry.FromDate = lastExecutionDate;
                    entry.RecalculatedDate = entry.FromDate.AddDays(entry.EstimatedTransitTimeDays);

                    var logEntrys = purchOrderShimentHeader.ShipmentLogEntries.Where(x => x.ShippingRouteStepId == entry.Id && x.Completed == true);
                    if (logEntrys.Count() > 0)
                    {
                        entry.ExecutionDate = logEntrys.Min(x => x.Date);
                        entry.RealTransitTimeDaysAcumulated = (entry.ExecutionDate - startDate).Days;
                        entry.RealTransitTimeDays = (entry.ExecutionDate - lastExecutionDate).Days;
                        lastExecutionDate = entry.ExecutionDate;
                        entry.Status = 2;
                    }
                    else if (!onExcecutionStepFound)
                    {
                        entry.ExecutionDate = DateTime.Today;
                        entry.RealTransitTimeDaysAcumulated = (entry.ExecutionDate - startDate).Days;
                        entry.RealTransitTimeDays = (entry.ExecutionDate - lastExecutionDate).Days;
                        entry.Status = 1;
                        onExcecutionStepFound = true;
                        entry.ShippingRouteStatusRisk = getShippingRouteStatusRisk(entry);
                    }
                    else
                    {
                        entry.Status = 0;
                    }
                    i++;
                }

                return ServiceResult<IEnumerable<ShippingRouteTimelineEntry>>.SuccessResult(shippingRouteTimeLineList);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<ShippingRouteTimelineEntry>>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }

        private ShippingRouteStatusRisk getShippingRouteStatusRisk(ShippingRouteTimelineEntry entry)
        {
            var route = _unitOfWork.ShippingRoutes.All()
                .Include(x => x.ShippingRouteStatusPresentationSchema)
                .FirstOrDefault(x => x.Id == entry.ShippingRouteId);

            if (route.ShippingRouteStatusPresentationSchema == null || entry.EstimatedTransitTimeDays == 0)
            {
                return ShippingRouteStatusRisk.NoRisk;
            }

            decimal rate = (decimal) entry.RealTransitTimeDays / entry.EstimatedTransitTimeDays;

            if (rate >= route.ShippingRouteStatusPresentationSchema.HighRisk)
            {
                return ShippingRouteStatusRisk.HighRisk;
            }
            else if (rate >= route.ShippingRouteStatusPresentationSchema.LowRisk)
            {
                return ShippingRouteStatusRisk.LowRisk;
            }
            else if (rate >= route.ShippingRouteStatusPresentationSchema.OnTime)
            {
                return ShippingRouteStatusRisk.OnTime;
            }
            return ShippingRouteStatusRisk.NoRisk;
        }
    }
}
