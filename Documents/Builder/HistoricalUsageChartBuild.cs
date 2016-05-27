using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Drawing.Charts;

namespace Nop.Plugin.Misc.Warehouse.Documents.Builder
{
    public class HistoricalUsageChartBuild
    {
        public static void Build(DocumentBuilder builder)
        {
            var shape = builder.InsertChart(ChartType.Column, 550, 180);
            var chart = shape.Chart;
            var seriesCollections = chart.Series;
            
            seriesCollections.Clear();
            chart.Legend.Position= LegendPosition.None;

            const string CHART_TITLE = "Historical Electrical  use for 2016";
            var datesArray = HelperMethods.CreateHistoricalUsageChartDatesAtrray();
            var valuesArray = HelperMethods.CreateHistoricalUsageChartValuesArray();

            seriesCollections.Add(CHART_TITLE, datesArray, valuesArray);
            shape.WrapType=WrapType.None;
            shape.RelativeHorizontalPosition= RelativeHorizontalPosition.Page;
            shape.RelativeVerticalPosition = RelativeVerticalPosition.Page;
            shape.BehindText = true;
        }
    }
}