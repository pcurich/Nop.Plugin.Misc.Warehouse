namespace Nop.Plugin.Misc.Warehouse.Documents.MailMerge
{
    public class RunDemos
    {
        public static void Main2()
        {
            BillProcessor.BuildDocument();
            BillProcessor.BuildMultipleDocuments();
            BillProcessor.CreateDocumentsFromXml();
            LoadingAndSaving.LoadAndSaveToStream();
            LoadingAndSaving.LoadEncryptedDocument();

        }
    }
}