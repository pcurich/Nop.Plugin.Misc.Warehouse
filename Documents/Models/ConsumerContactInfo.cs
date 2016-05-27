using System;

namespace Nop.Plugin.Misc.Warehouse.Documents.Models
{
    public class CustomerContactInfo
    {
        public int AccountNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Line1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public DateTime DueDate { get; set; }
        public Decimal AmountDue { get; set; }
        
        
    }
}