using Aspose.Words;

namespace Nop.Plugin.Misc.Warehouse.Documents.Builder
{
    public class CompanyContactInfoBuilder
    {
        public static void Build( DocumentBuilder builder)
        {
            builder.Writeln();
            builder.Writeln(HelperMethods.CreateCompanyContactInfoText(true));
        }
    }
}