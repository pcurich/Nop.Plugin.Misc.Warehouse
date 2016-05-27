using System;

namespace Nop.Plugin.Misc.Warehouse.Documents.Models
{
    public class ChargeSummary
    {
        public decimal PriorCharge { get; set; }
        public decimal PriorPaymentAmount { get; set; }
        public decimal CurrentChargeAmount { get; set; }
        public decimal SalesTaxValue { get; set; }
        public decimal AmountDue { get; set; }
        public DateTime PriorPaymentDate { get; set; }
        public DateTime BillCreatedDate { get; set; }
        public DateTime DueDate { get; set; }
        public double SalesTaxRate { get; set; }
        public int AccountNumber { get; set; }
    }
}