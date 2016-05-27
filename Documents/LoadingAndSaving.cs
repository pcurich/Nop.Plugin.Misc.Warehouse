using System.IO;
using System.Runtime.InteropServices;
using Aspose.Words;
using Aspose.Words.Saving;
using Nop.Plugin.Misc.Warehouse.Documents.MailMerge;

namespace Nop.Plugin.Misc.Warehouse.Documents
{
    public class LoadingAndSaving
    {
        public static void LoadAndSaveToStream()
        {
            //Create a new document
            var doc = new Document(MailMergeGoblaDocumentSettings.MailMergeOutputFileName);

            //Convert to PDF and Save to the stream
            var outputStream = new MemoryStream();
            doc.Save(outputStream, SaveFormat.Pdf);

            //Deserialize document to a byte array
            var byteArray = outputStream.ToArray();

            //Here is where you should do something - maybe save the deserialized document to a database


            //Now, serialize the byte array and save the psical document
            File.WriteAllBytes(MailMergeGoblaDocumentSettings.MailMergeOutputFileNameStream,byteArray);
        }


        public static void LoadEncryptedDocument()
        {
            //Specify decryption password in a new LoadOptions object to open passwrd-encrypted documents
            var doc = new Document(MailMergeGoblaDocumentSettings.MailMergeOutputFileName, new LoadOptions("password"));

            //Change the password
            var saveOptions = new DocSaveOptions {Password = "NewPassord"};

            //Save a new document with new password
            doc.Save(MailMergeGoblaDocumentSettings.NewEncryptedDocumentOutputFileName, saveOptions);
        }
    }
}