using Aspose.Words;
using Aspose.Words.Drawing;

namespace Nop.Plugin.Misc.Warehouse.Documents.Builder
{
    public class QrCodeBuilder
    {
        public static void Build(DocumentBuilder builder)
        {
            builder.InsertImage(
               fileName: GlobalDocumentSettings.CompanyLogoFileName,
               horzPos: RelativeHorizontalPosition.Margin,
               vertPos: RelativeVerticalPosition.Margin,
               left: 0,
               top: 550,
               width: 75,
               height: 75,
               wrapType: WrapType.TopBottom);

            var message = new Shape(builder.Document, ShapeType.TextBox)
            {
                RelativeHorizontalPosition = RelativeHorizontalPosition.Margin,
                RelativeVerticalPosition = RelativeVerticalPosition.Margin,
                Stroked = false,
                WrapType = WrapType.None,
                Width = 200,
                Height = 50,
                Top = 570,
                Left = 100,
            };

            var paragraph = new Paragraph(builder.Document);
            paragraph.AppendChild(new Run(builder.Document, "Scan this QR code"));

            message.AppendChild(paragraph);
            builder.InsertNode(message);
        }
    }
}