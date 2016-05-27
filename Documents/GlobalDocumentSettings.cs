using Aspose.Words;

namespace Nop.Plugin.Misc.Warehouse.Documents
{
    public class GlobalDocumentSettings
    {
        //Global font properties
        public static string FontName = "Gothan Book";
        public static int FontSize = 12;

        //File Information
        public static string FileName = "BillDemo.docx";
        public static string PaymentInstruccionsFileName = @"..\..\Content\Bill Payment Instruccions.docx";

        //Logo Location
        public static string CompanyLogoFileName = @"..\..\Content\Company.png";

        //WaterMark text
        public static string WaterMarkText = "AUTO\nPAY";

        //QR Code Location
        public static string QrCodeFileName = @"..\..\Content\QRCode.png";

        //Set Page margins
        public static void SetPageMargins(Document doc)
        {
            foreach (Section section in doc.Sections)
            {
                section.PageSetup.TopMargin = 36;
                section.PageSetup.LeftMargin = 36;
                section.PageSetup.BottomMargin = 36;
                section.PageSetup.RightMargin = 36;
            }
        }
    }
}