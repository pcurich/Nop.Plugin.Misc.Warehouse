using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Nop.Plugin.Misc.Warehouse.Documents.MailMerge
{
    public class MailMergeHelperMethod
    {
        public static void GetMergeInfoFromObject(object source,
            out List<string> mergeFilds,
            out List<object> mergeValues)
        {
            var properties = source.GetType().GetProperties();
            mergeFilds = properties.Select(p => p.Name).ToList();
            mergeValues = properties.Select(p => p.GetValue(source, null)).ToList();
        }

        public static DataTable CreateBillHistoryDataTable(int numberOfMonths)
        {
            var table = new DataTable();
            table.Columns.Add("Month", typeof (string));
            table.Columns.Add("Usage", typeof(string));
            table.Columns.Add("Amount", typeof(string));

            var dateArray = HelperMethods.CreateHistoricalUsageChartDatesAtrray();
            var usageArray = HelperMethods.CreateHistoricalUsageChartValuesArray();

            return null;
        }
    }
}