using System.Data;
using System.Drawing;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Saving;
using Aspose.Words.Tables;

namespace Nop.Plugin.Misc.Warehouse.Documents.Builder
{
    public class PaymentStubBuilder
    {
        public static void Build(DocumentBuilder builder)
        {
            var chargeSummaryTextBox = new Shape(builder.Document, ShapeType.TextBox)
            {
                RelativeHorizontalPosition = RelativeHorizontalPosition.Margin,
                RelativeVerticalPosition = RelativeVerticalPosition.Margin,
                Top = 550,
                Stroked = false,
                Width = 300,
                Height = 80
            };

            chargeSummaryTextBox.Left = builder.PageSetup.PageWidth - chargeSummaryTextBox.Width;

            var chargeSummaryDataTable = HelperMethods.CreateChargeSumaryDataTable();
            var table = builder.StartTable();

            foreach (DataRow row in chargeSummaryDataTable.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    builder.InsertCell();
                    builder.Write(item.ToString());
                }
                builder.EndRow();
            }

            table.AutoFit(AutoFitBehavior.AutoFitToContents);
            table.ClearBorders();
            table.SetBorder(BorderType.Left, LineStyle.Thick, 1.5, Color.Black, true);
            table.SetBorder(BorderType.Right, LineStyle.Thick, 1.5, Color.Black, true);
            table.SetBorder(BorderType.Top, LineStyle.Thick, 1.5, Color.Black, true);
            table.SetBorder(BorderType.Bottom, LineStyle.Thick, 1.5, Color.Black, true);

            builder.EndTable();
            chargeSummaryTextBox.AppendChild(table);
            builder.Document.FirstSection.Body.FirstParagraph.AppendChild(chargeSummaryTextBox);


            var companyAddressTextBox = new Shape(builder.Document, ShapeType.TextBox)
            {
                RelativeHorizontalPosition = RelativeHorizontalPosition.Margin,
                RelativeVerticalPosition = RelativeVerticalPosition.Margin,
                Top = 650,
                Stroked = false,
                Width = 220,
                Height = 80
            };
            companyAddressTextBox.Left = builder.PageSetup.PageWidth - companyAddressTextBox.Width*.135;

            var companyAddressParagraph = new Paragraph(builder.Document);
            var companyAddressRun = new Run(builder.Document, HelperMethods.CreateCompanyContactInfoText(false));

            companyAddressParagraph.AppendChild(companyAddressRun);
            companyAddressTextBox.AppendChild(companyAddressParagraph);

            foreach (Run run in companyAddressParagraph.Runs)
            {
                run.Font.Name = GlobalDocumentSettings.FontName;
                run.Font.Size = GlobalDocumentSettings.FontSize;
            }

            builder.Document.FirstSection.Body.FirstParagraph.AppendChild(companyAddressTextBox);

            var customerAddressTextBox = new Shape(builder.Document, ShapeType.TextBox)
            {
                RelativeHorizontalPosition = RelativeHorizontalPosition.Margin,
                RelativeVerticalPosition = RelativeVerticalPosition.Margin,
                Top = 650,
                Stroked = false,
                Width = 180,
                Height = 80
            };
            customerAddressTextBox.Left =   customerAddressTextBox.Width/5;

            var customerAddressParagraph = new Paragraph(builder.Document);
            var customerAddressRun = new Run(builder.Document, HelperMethods.CreateCustomerContactInfoText());

            customerAddressParagraph.AppendChild(customerAddressRun);
            customerAddressTextBox.AppendChild(customerAddressParagraph);

            foreach (Run run in customerAddressParagraph.Runs)
            {
                run.Font.Name = GlobalDocumentSettings.FontName;
                run.Font.Size = GlobalDocumentSettings.FontSize;
            }

            builder.Document.FirstSection.Body.FirstParagraph.AppendChild(customerAddressTextBox);

        }
    }
}