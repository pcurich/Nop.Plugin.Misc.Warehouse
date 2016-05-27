using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Tables;

namespace Nop.Plugin.Misc.Warehouse.Documents.Builder
{
    public class BillSummaryTableBuilder
    {
        public static void Build(Document document, DocumentBuilder builder)
        {
            var summaryTextBox = new Shape(document, ShapeType.TextBox)
            {
                Width = 182,
                Height = 65,
                Stroked = false, //ninguna otra forma se creara al rededor
                WrapType = WrapType.None, //Si esta o no redeado en texto
                RelativeHorizontalPosition = RelativeHorizontalPosition.Margin,
                RelativeVerticalPosition = RelativeVerticalPosition.Margin,
                Top = 35,
                HorizontalAlignment = HorizontalAlignment.Right
            };

            var table = new Table(document);
            var chargeSummary = HelperMethods.CreateChargeSummary();
            var customerInfo = HelperMethods.CreateCustomerContactInfo();

            document.FirstSection.Body.AppendChild(table);

            #region AccountNumer

            var accountNumberRow = new Row(document);

            var accountNumberLabelCell = new Cell(document);
            var accountNumberLabelParagraph = new Paragraph(document);
            var accountNumberLabelRun = new Run(document, "Account Number");

            accountNumberLabelParagraph.AppendChild(accountNumberLabelRun);
            accountNumberLabelCell.AppendChild(accountNumberLabelParagraph);
            accountNumberRow.AppendChild(accountNumberLabelCell);

            var accountNumberValueCell = new Cell(document);
            var accountNumberValueParagraph = new Paragraph(document);
            var accountNumberValueRun = new Run(document, customerInfo.AccountNumber.ToString("c"));

            accountNumberValueParagraph.AppendChild(accountNumberValueRun);
            accountNumberValueCell.AppendChild(accountNumberValueParagraph);
            accountNumberRow.AppendChild(accountNumberValueCell);

            #endregion

            #region AmountDue

            var amountDueRow = new Row(document);

            var amountDueLabelCell = new Cell(document);
            var amountDueLabelParagraph = new Paragraph(document);
            var amountDueLabelRun = new Run(document, "Amount Due");

            amountDueLabelParagraph.AppendChild(amountDueLabelRun);
            amountDueLabelCell.AppendChild(amountDueLabelParagraph);
            amountDueRow.AppendChild(amountDueLabelCell);

            var amountDueValueCell = new Cell(document);
            var amountDueValueParagraph = new Paragraph(document);
            var amountDueValueRun = new Run(document, customerInfo.AmountDue.ToString("C"));

            amountDueValueParagraph.AppendChild(amountDueValueRun);
            amountDueValueCell.AppendChild(amountDueValueParagraph);
            amountDueRow.AppendChild(amountDueValueCell);

            #endregion

            #region DueDate

            var dueDateRow = new Row(document);

            var dueDateLabelCell = new Cell(document);
            var dueDateLabelParagraph = new Paragraph(document);
            var dueDateLabelRun = new Run(document, "Due Date");

            dueDateLabelParagraph.AppendChild(dueDateLabelRun);
            dueDateLabelCell.AppendChild(dueDateLabelParagraph);
            dueDateRow.AppendChild(dueDateLabelCell);

            var dueDateValueCell = new Cell(document);
            var dueDateValueParagraph = new Paragraph(document);
            var dueDateValueRun = new Run(document, customerInfo.DueDate.ToString());

            dueDateValueParagraph.AppendChild(dueDateValueRun);
            dueDateValueCell.AppendChild(dueDateValueParagraph);
            dueDateRow.AppendChild(dueDateValueCell);

            #endregion

            table.AppendChild(accountNumberRow);
            table.AppendChild(amountDueRow);
            table.AppendChild(dueDateRow);

            //CellTextFont=Run
            //HorizontalAlignment=Paragraph
            //VerticalAlignment =Cell

            foreach (Row row in table.Rows)
            {
                foreach (Cell cell in row.Cells)
                {
                    cell.CellFormat.VerticalAlignment=CellVerticalAlignment.Center;
                    var runs = cell.GetChildNodes(NodeType.Run, true);
                    foreach (Run run in runs)
                    {
                        run.Font.Name = GlobalDocumentSettings.FontName;
                        run.Font.Size= GlobalDocumentSettings.FontSize;
                    }

                    foreach (Paragraph paragraph in cell.Paragraphs)
                    {
                        paragraph.ParagraphFormat.Alignment=ParagraphAlignment.Center;
                    }
                }
            }
            table.AutoFit(AutoFitBehavior.AutoFitToContents);
            summaryTextBox.AppendChild(table);
            builder.InsertNode(summaryTextBox);
        } 
    }
}