using System;
namespace DiunsaSCM.Core.Entities
{
    public class PurchCostDefinitionLine : AuditableEntity
    {
        public long Id { get; set; }
        public int LineNumber { get; set; }
        public decimal QtyOrdered { get; set; }
        public string UnitCode { get; set; }
        public string LineDescription { get; set; }
        public string CustomsTariffCode { get; set; }
        public string CustomsTariffPosition { get; set; }
        public string CBM { get; set; }
        public string EmptyField { get; set; }
        public string ItemNumber { get; set; }
        public string ItemBarcode { get; set; }
        public string InventItemCode { get; set; }
        public decimal PurchPrice { get; set; }
        public decimal PurchLineAmount { get; set; }
        public decimal CIFMarkupAmount { get; set; }
        public decimal CostWithCIF { get; set; }
        public decimal CostWithCIFLocalCurrency { get; set; }
        public decimal CustomsFee { get; set; }
        public decimal CustomsSelectiveFeeAmount { get; set; }
        public decimal LocalExpensesMarkupAmount { get; set; }
        public decimal CostWithLocalExpensesLocalCurrency { get; set; }
        public decimal CostWithLocalExpenses { get; set; }
        public decimal SuggestedSalesPriceStore { get; set; }
        public decimal SuggestedSalesPriceWholesaleCredit { get; set; }
        public decimal SuggestedSalesPriceWholesaleCash { get; set; }

        public string PurchOrderCode { get; set; }

        public long PurchCostDefinitionId { get; set; }

        public virtual PurchCostDefinition PurchCostDefinition { get; set; }
    }
}
