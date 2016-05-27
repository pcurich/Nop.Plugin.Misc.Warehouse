using System.Drawing;
using Aspose.Words;
using Aspose.Words.Drawing;

namespace Nop.Plugin.Misc.Warehouse.Documents.Builder
{
    public class WatermarkBuilder
    {
        public static void Build(DocumentBuilder builder)
        {
            var waterMark = new Shape(builder.Document, ShapeType.TextPlainText);

            waterMark.TextPath.Text = GlobalDocumentSettings.WaterMarkText;
            waterMark.TextPath.FontFamily = GlobalDocumentSettings.FontName;
            waterMark.Width = 300;
            waterMark.Height=250;
            waterMark.Rotation = -40;
            waterMark.FillColor = Color.Gray;
            waterMark.StrokeColor = Color.Gray;
            waterMark.RelativeHorizontalPosition= RelativeHorizontalPosition.Margin;
            waterMark.RelativeVerticalPosition=RelativeVerticalPosition.Margin;
            waterMark.WrapType = WrapType.None;
            waterMark.Top = 100;
            waterMark.HorizontalAlignment=HorizontalAlignment.Center;
            
            builder.InsertNode(waterMark);

        }
    }
}