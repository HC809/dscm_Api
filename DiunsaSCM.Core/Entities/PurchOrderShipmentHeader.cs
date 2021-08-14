using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DiunsaSCM.Core.Entities
{
    public class PurchOrderShipmentHeader : AuditableEntity
    {
        public long Id { get; set; }
        public long PurchOrderHeaderId { get; set; }

        public long? ShipmentImportId { get; set; }
        public long? ShippingRouteId { get; set; }
        public long? PreparationShippingRouteId { get; set; }

        public long? ShippingCompanyId { get; set; }
        public long? IncotermId { get; set; }

        public long? ShipmentTypeId { get; set; }
        public long? CommercialEventId { get; set; }

        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ShipmentDateRequested { get; set; }
        public DateTime ShipmentDateConfirmed { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime ReceiptDateConfirmed { get; set; }
        
        public decimal EstimatedVolume { get; set; }
        public decimal EstimatedWeight { get; set; }
        public decimal EstimatedContainerQty { get; set; }
        public string InvoiceNumber { get; set; }

        private string _code;
        public string Code { get => _code; set => _code = value == "" ? null : value; }

        public virtual PurchOrderHeader PurchOrderHeader { get; set; }
        public virtual ShipmentImport ShipmentImport { get; set; }
        public virtual ShippingCompany ShippingCompany { get; set; }
        public virtual Incoterm Incoterm { get; set; }
        public virtual ShipmentType ShipmentType { get; set; }
        public virtual CommercialEvent CommercialEvent { get; set; }

        [ForeignKey("ShippingRouteId")]
        public virtual ShippingRoute ShippingRoute { get; set; }
        [ForeignKey("PreparationShippingRouteId")]
        public virtual ShippingRoute PreparationShippingRoute { get; set; }

        public virtual IEnumerable<PurchOrderShipmentDetail> PurchOrderShipmentDetails { get; set; }
        public virtual IEnumerable<ShipmentContainer> ShipmentContainers { get; set; }
        public virtual IEnumerable<ShipmentLogEntry> ShipmentLogEntries { get; set; }


        public PurchOrderShipmentHeader()
        {
        }

        public decimal GetTotalVolume()

        {
            return 0;
            if (ShipmentContainers == null)
                return 0;
            return ShipmentContainers.Sum(x => x.Volume);
        }

        public decimal GetTotalWeight()
        {
            return 0;
            if (ShipmentContainers == null)
                return 0;
            return ShipmentContainers.Sum(x => x.Weight);
        }

        public string GetShippingCompanyName()
        {
            if (ShippingCompany != null)
                return ShippingCompany.Name;
            else
                return "";
        }

        public string GetCompleteCode() {
            return this.PurchOrderHeader.Code + "-" + this.Code;
        }

        /*
        public ShippingRouteStep GetLastStepCompleted(long? shippingRouteId)
        {
            if (this.ShipmentLogEntries == null)
            {
                return null;
            }

            var lastStepCompleted = this.ShipmentLogEntries
                .Where(x => x.ShippingRouteStep.ShippingRouteId == shippingRouteId && x.Completed == true)
                .OrderByDescending(x => x.ShippingRouteStep.StepNumber)
                .FirstOrDefault();

            if (lastStepCompleted == null)
            {
                return null;
            }
            return lastStepCompleted.ShippingRouteStep;
        }

        public ShippingRouteStep GetCurrentStep(ShippingRoute shippingRoute) {
            if (shippingRoute == null)
            {
                return null;
            }

            int lastStepNumber = 0;

            var lastStepCompleted = this.GetLastStepCompleted(shippingRoute.Id);
            if (lastStepCompleted != null) {
                lastStepNumber = lastStepCompleted.StepNumber;
            }

            if (shippingRoute.ShippingRouteSteps == null)
            {
                return null;
            }

            var nextStep = shippingRoute.ShippingRouteSteps
                .Where(x => x.StepNumber > lastStepNumber)
                .OrderBy(x => x.StepNumber)
                .FirstOrDefault();

            return nextStep;
        }
        
        public long GetCurrentShippingStepId() {
            var currentStep = GetCurrentStep(this.ShippingRoute);
            if (currentStep == null)
            {
                return 0;
            }
            return currentStep.Id;
        }
        
        public long GetLastShippingStepCompletedId()
        {
            var lastStepCompleted = GetLastStepCompleted(this.ShippingRouteId);
            if (lastStepCompleted == null)
            {
                return 0;
            }
            return lastStepCompleted.Id;
        }

        public long GetCurrentPreparationStepId() {
            var currentStep = GetCurrentStep(this.PreparationShippingRoute);
            if (currentStep == null)
            {
                return 0;
            }
            return currentStep.Id;
        }

        public long GetLastPreparationStepCompletedId()
        {
            var lastStepCompleted = GetLastStepCompleted(this.PreparationShippingRouteId);
            if (lastStepCompleted == null)
            {
                return 0;
            }
            return lastStepCompleted.Id;
        }*/

        /*
        public ShippingRouteStep GetCurrentShippingRouteStep()
        {
            List<ShippingRouteStep> preparationShippingRouteSteps = new List<ShippingRouteStep>();
            List<ShippingRouteStep> shippingRouteSteps = new List<ShippingRouteStep>();
            if (this.PreparationShippingRoute != null && this.PreparationShippingRoute.ShippingRouteSteps != null)
            {
                preparationShippingRouteSteps = this.PreparationShippingRoute.ShippingRouteSteps.OrderBy(x => x.StepNumber).ToList();
            }
            if (this.ShippingRoute != null && this.ShippingRoute.ShippingRouteSteps != null)
            {
                shippingRouteSteps = this.ShippingRoute.ShippingRouteSteps.OrderBy(x => x.StepNumber).ToList();
            }

            var allShippingRouteSteps = preparationShippingRouteSteps.Concat(shippingRouteSteps);

            var current = allShippingRouteSteps.FirstOrDefault(x => !this.ShipmentLogEntries.Any(l => l.ShippingRouteStepId == x.Id && l.Completed == true));

            return current;
        }

        public ShippingRouteStep GetLastShippingRouteStep()
        {
            List<ShippingRouteStep> preparationShippingRouteSteps = new List<ShippingRouteStep>();
            List<ShippingRouteStep> shippingRouteSteps = new List<ShippingRouteStep>();
            if (this.PreparationShippingRoute != null && this.PreparationShippingRoute.ShippingRouteSteps != null)
            {
                preparationShippingRouteSteps = this.PreparationShippingRoute.ShippingRouteSteps.OrderByDescending(x => x.StepNumber).ToList();
            }
            if (this.ShippingRoute != null && this.ShippingRoute.ShippingRouteSteps != null)
            {
                shippingRouteSteps = this.ShippingRoute.ShippingRouteSteps.OrderByDescending(x => x.StepNumber).ToList();
            }

            var allShippingRouteSteps = shippingRouteSteps.Concat(preparationShippingRouteSteps);

            var current = allShippingRouteSteps.FirstOrDefault(x => this.ShipmentLogEntries.Any(l => l.ShippingRouteStepId == x.Id && l.Completed == true));

            return current;
        }*/

        public ShippingRouteStep GetCurrentShippingRouteStep()
        {
            List<ShippingRouteStep> preparationShippingRouteSteps = new List<ShippingRouteStep>();
            List<ShippingRouteStep> shippingRouteSteps = new List<ShippingRouteStep>();

            if (this.PreparationShippingRoute != null && this.PreparationShippingRoute.ShippingRouteSteps != null)
            {
                preparationShippingRouteSteps = this.PreparationShippingRoute.ShippingRouteSteps.OrderBy(x => x.StepNumber).ToList();
            }
            if (this.ShippingRoute != null && this.ShippingRoute.ShippingRouteSteps != null)
            {
                shippingRouteSteps = this.ShippingRoute.ShippingRouteSteps.OrderBy(x => x.StepNumber).ToList();
            }

            var allShippingRouteSteps = preparationShippingRouteSteps.Concat(shippingRouteSteps);

            var currentShippingRouteStep = allShippingRouteSteps
                .Where(x => !this.ShipmentLogEntries.Any(l => l.ShippingRouteStepId == x.Id && l.Completed == true))
                .FirstOrDefault();

            return currentShippingRouteStep;
        }

        public long GetCurrentShippingRouteId()
        {
            var currentShippingRouteStep = GetCurrentShippingRouteStep();
            if (currentShippingRouteStep == null)
            {
                return 0;
            }
            else
                return currentShippingRouteStep.ShippingRouteId;

        }

        public long GetCurrentShippingRouteStepId()
        {
            var currentShippingRouteStep = GetCurrentShippingRouteStep();
            if (currentShippingRouteStep == null)
            {
                return 0;
            }
            else
                return currentShippingRouteStep.Id;

        }

        public string GetCurrentShippingRouteStepDescription()
        {
            var currentShippingRouteStep = GetCurrentShippingRouteStep();
            if (currentShippingRouteStep == null)
            {
                return "";
            }
            else
                return currentShippingRouteStep.ShippingStepType.Description;

        }

    }
}
