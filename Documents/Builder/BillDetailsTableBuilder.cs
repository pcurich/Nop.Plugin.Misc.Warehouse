using Aspose.Words;
using Aspose.Words.Tables;

namespace Nop.Plugin.Misc.Warehouse.Documents.Builder
{
    public class BillDetailsTableBuilder
    {
        public static void Build(DocumentBuilder builder)
        {
            var chargeSummary = HelperMethods.CreateChargeSummary();

            builder.Font.Bold = true;
            builder.Writeln();
            builder.Writeln("Billing Details");
            builder.Font.Bold = false;

            builder.RowFormat.Height = 20;
            builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
            builder.CellFormat.Borders.Left.LineStyle = LineStyle.None;
            builder.CellFormat.Borders.Right.LineStyle = LineStyle.None;
            builder.CellFormat.Borders.Top.LineStyle = LineStyle.None;
            builder.CellFormat.Borders.Bottom.LineStyle = LineStyle.None;

            builder.InsertCell();
            builder.CellFormat.Borders.Top.LineStyle = LineStyle.Single;
            builder.CellFormat.Borders.Top.LineWidth = 2;
            builder.Writeln("Total From Last Bill");

            //CELL PARAGRAPH RUN

            builder.InsertCell();
            builder.Writeln(chargeSummary.PriorCharge.ToString("C"));
            builder.EndRow();

            builder.InsertCell();
            builder.CellFormat.Borders.Top.LineStyle = LineStyle.None;
            builder.Writeln(chargeSummary.PriorPaymentDate.ToShortDateString() + "Payment Receive - Thank You!");

            builder.InsertCell();
            builder.Writeln(chargeSummary.PriorPaymentAmount.ToString("C"));
            builder.EndRow();

            #region Current Charge

            builder.InsertCell();
            builder.CellFormat.Borders.LineWidth = 1;
            builder.Font.Bold = true;
            builder.Write("Current Charges");
            builder.InsertCell();
            builder.EndRow();

            builder.InsertCell();
            builder.CellFormat.Borders.Top.LineStyle = LineStyle.Single;
            builder.Font.Bold = false;
            builder.CellFormat.LeftPadding = 30;
            builder.Write("Current Charge" + chargeSummary.BillCreatedDate.ToShortDateString());

            builder.InsertCell();
            builder.CellFormat.LeftPadding = 5;
            builder.Write(chargeSummary.CurrentChargeAmount.ToString("C"));
            builder.EndRow();

            #endregion

            #region Item1

            builder.InsertCell();
            builder.CellFormat.LeftPadding = 30;
            builder.Write("Electicity city sales Tax" + chargeSummary.SalesTaxRate + "%");

            builder.InsertCell();
            builder.CellFormat.LeftPadding = 5;
            builder.Write(chargeSummary.SalesTaxValue.ToString("C"));
            builder.EndRow();

            builder.InsertCell();
            builder.CellFormat.LeftPadding = 5;
            builder.CellFormat.Borders.Top.LineStyle = LineStyle.Single;
            builder.CellFormat.Borders.Top.LineWidth = 1;
            builder.Write("Bill Due Date");

            builder.InsertCell();
            builder.Write(chargeSummary.DueDate.ToShortDateString());
            builder.EndRow();

            builder.InsertCell();
            builder.CellFormat.Borders.Top.LineStyle = LineStyle.None;
            builder.CellFormat.Borders.Bottom.LineStyle = LineStyle.Single;
            builder.CellFormat.Borders.Bottom.LineWidth = 2;
            builder.Write("Total Amount Due");

            #endregion

            builder.InsertCell();
            builder.Write(chargeSummary.AmountDue.ToString("C"));
            builder.EndRow();

            builder.EndTable();
            builder.Writeln();
            builder.Writeln();
        }
    }
}