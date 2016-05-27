using Aspose.Words;
using Aspose.Words.Drawing;

namespace Nop.Plugin.Misc.Warehouse.Documents.Builder
{
    public class PaymentStubPerforatedLineBuilder
    {
        public static void Build(DocumentBuilder builder)
        {
            var line = new Shape(builder.Document, ShapeType.Line)
            {
                RelativeHorizontalPosition = RelativeHorizontalPosition.Margin,
                RelativeVerticalPosition = RelativeVerticalPosition.Margin,
                Top = 530,
                Width = 575,
                HorizontalAlignment = HorizontalAlignment.Center,
                StrokeWeight = 2,
                Stroked = true,
                Stroke = {DashStyle = DashStyle.ShortDot}
            };

            builder.InsertNode(line);

            var lineMessageTextBox = new Shape(builder.Document, ShapeType.TextBox)
            {
                RelativeHorizontalPosition = RelativeHorizontalPosition.Margin,
                RelativeVerticalPosition = RelativeVerticalPosition.Margin,
                Top = 510,
                HorizontalAlignment = HorizontalAlignment.Center,
                Stroked = false,
                Width = 450,
                Height = 20
            };

            var lineMessageParagraph = new Paragraph(builder.Document);
            var lineMessageRun = new Run(builder.Document, "Please Detach lower portion and return with payment");
            lineMessageRun.Font.Name = GlobalDocumentSettings.FontName;
            lineMessageRun.Font.Size = GlobalDocumentSettings.FontSize;

            lineMessageParagraph.AppendChild(lineMessageRun);
            lineMessageParagraph.ParagraphFormat.Alignment=ParagraphAlignment.Center;

            lineMessageTextBox.AppendChild(lineMessageParagraph);
            builder.Document.FirstSection.Body.FirstParagraph.AppendChild(lineMessageTextBox);


        }
    }
}