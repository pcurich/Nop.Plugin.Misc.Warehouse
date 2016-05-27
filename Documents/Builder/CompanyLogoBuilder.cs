using Aspose.Words;
using Aspose.Words.Drawing;

namespace Nop.Plugin.Misc.Warehouse.Documents.Builder
{
    public class CompanyLogoBuilder
    {
        public static void Build(DocumentBuilder builder)
        {
            builder.InsertImage(
                fileName:GlobalDocumentSettings.CompanyLogoFileName,
                horzPos:RelativeHorizontalPosition.Margin,
                vertPos: RelativeVerticalPosition.Margin,
                left:0,
                top:30,
                width:150,
                height:25,
                wrapType:WrapType.TopBottom);
        }
    }
}