using System;
using System.Text;
using Nop.Plugin.Misc.Warehouse.Documents.Models;

namespace Nop.Plugin.Misc.Warehouse.Documents
{
    public class HelperMethods
    {
        public static DateTime[] CreateHistoricalUsageChartDatesAtrray()
        {
            return new[]
            {
                new DateTime(2016, 1, 1),new DateTime(2016,2,1), new DateTime(2016,3,1), 
                new DateTime(2016, 4, 1),new DateTime(2016,5,1), new DateTime(2016,6,1), 
                new DateTime(2016, 7, 1),new DateTime(2016,8,1), new DateTime(2016,9,1), 
                new DateTime(2016, 10, 1),new DateTime(2016,11,1), new DateTime(2016,12,1),
            };
        }

        public static double[] CreateHistoricalUsageChartValuesArray()
        {
            return new double[]
            {
                850, 897, 904,
                976, 1034, 1087,
                1145, 1431, 1350,
                1293, 903, 875
            };
        }

        public static CompanyContactInfo CreateCompanyContactInfo()
        {
            return new CompanyContactInfo
            {
                CompanyName = "Globomantics Electronic Company",
                Line1 = "1234 Power Grid Way",
                City = "Electric City",
                State = "PA",
                Zip = "9888-4231",
                Phone = "1-800-POWER-UP",
                Email = "help@globomantics.com"
            };
        }

        public static string CreateCompanyContactInfoText(bool includeAllContactInfo)
        {
            var contactInfo = CreateCompanyContactInfo();
            var sb = new StringBuilder();
            if (includeAllContactInfo)
            {
                sb.AppendLine(contactInfo.Line1);
                sb.AppendLine(contactInfo.CityStateZip);
                sb.AppendLine(contactInfo.Phone);
                sb.AppendLine(contactInfo.Email);
            }
            else
            {
                sb.AppendLine(contactInfo.CompanyName);
                sb.AppendLine(contactInfo.Line1);
                sb.AppendLine(contactInfo.CityStateZip);
            }
            return sb.ToString();
        }

        public static ChargeSummary CreateChargeSummary()
        {
            return new ChargeSummary
            {
                PriorCharge = 5M,
                PriorPaymentAmount = 50M,
                PriorPaymentDate = DateTime.Now,
                BillCreatedDate = DateTime.Now,
                CurrentChargeAmount = 20M,
                SalesTaxRate = 18.0,
                SalesTaxValue = 18M,
                DueDate = DateTime.Now,
                AmountDue = 100M
            };
        }

        public static CustomerContactInfo CreateCustomerContactInfo()
        {

            return new CustomerContactInfo
            {
                AccountNumber = 1111,
                DueDate = DateTime.Now,
                AmountDue = 100.0M,
            };
        }
    }
}