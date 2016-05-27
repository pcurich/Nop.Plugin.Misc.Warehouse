using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.HtmlControls;
using Aspose.Words;
using Nop.Plugin.Misc.Warehouse.Documents.Builder;
using Nop.Plugin.Misc.Warehouse.Documents.MailMerge;
using Nop.Plugin.Misc.Warehouse.Documents.Models;

namespace Nop.Plugin.Misc.Warehouse.Documents
{
    public class BillProcessor
    {
        public static void Main()
        {
            //Initialize document object and document builder object
            var doc = new Document();
            var builder = new DocumentBuilder(doc);

            builder.Font.Name = GlobalDocumentSettings.FontName;
            builder.Font.Size = GlobalDocumentSettings.FontSize;

            //New add company logo to the company address
            CompanyLogoBuilder.Build(builder);

            //New add company logo to the company address
            CompanyLogoBuilder.Build(builder);

            //Create watermark
            WatermarkBuilder.Build(builder);

            //Create bill Summary table inside a text Box
            BillSummaryTableBuilder.Build(doc, builder);

            //Create bill details table using Document Builder
            BillDetailsTableBuilder.Build(builder);

            //Create column chart
            HistoricalUsageChartBuild.Build(builder);

            //Create perforated line for payment stub
            PaymentStubPerforatedLineBuilder.Build(builder);

            //Create payment stub
            PaymentStubBuilder.Build(builder);

            //Create Add QR code to pay stub
            QrCodeBuilder.Build(builder);

            //Append bill payment instructions page
            var billPayInstructions = new Document(GlobalDocumentSettings.PaymentInstruccionsFileName);
            doc.AppendDocument(billPayInstructions, ImportFormatMode.KeepSourceFormatting);

            //Set Global page margins
            GlobalDocumentSettings.SetPageMargins(doc);

            //Save Document
            doc.Save(GlobalDocumentSettings.FileName);
        }

        #region MailMerge

        #region Constans

        private static readonly ChargeSummary CHARGE_SUMMARY = HelperMethods.CreateChargeSummary();
        private static readonly CustomerContactInfo CUSTOMER_CONTACT_INFO = HelperMethods.CreateCustomerContactInfo();
        private static readonly List<ChargeSummary> CHARGE_SUMMARY_LIST = HelperMethods.CreateChargeSummaryList();

        private static readonly List<CustomerContactInfo> CUSTOMER_CONTACT_INFO_LIST =
            HelperMethods.CreateCustomerContactInfoList();

        private static readonly string DATA_TABLE_NAME = "UsageHistory";
        private static readonly int NUMBER_OF_MONTH = 12;

        #endregion

        #region BuildDocuments

        public static void BuildDocument()
        {
            //Initialize Document
            var doc = new Document(MailMergeGoblaDocumentSettings.MailMergeIntputFileName);

            //Retain write space from the templeate
            doc.MailMerge.TrimWhitespaces = false;

            //Get the merge lists for the change summary
            List<string> chargeSummaryFields;
            List<object> chargeSummaryValues;
            MailMergeHelperMethod.GetMergeInfoFromObject(CHARGE_SUMMARY, out chargeSummaryFields,
                out chargeSummaryValues);

            //Get the merge lists fos customer contact Info
            List<string> customerContactFields;
            List<object> customerContactValues;
            MailMergeHelperMethod.GetMergeInfoFromObject(CUSTOMER_CONTACT_INFO, out customerContactFields,
                out customerContactValues);

            //Populate teh table taht displays billing history
            var historyTable = MailMergeHelperMethod.CreateBillHistoryDataTable(NUMBER_OF_MONTH);
            historyTable.TableName = DATA_TABLE_NAME;

            //Create final merge arrays
            var mergeFields = chargeSummaryFields.Concat(customerContactFields).ToArray();
            var mergeValues = chargeSummaryValues.Concat(customerContactValues).ToArray();

            //A couple mail merge advance settings
            doc.MailMerge.UseNonMergeFields = true;
            doc.MailMerge.MappedDataFields.Add("BillDueDate", "DueDate");

            //Execute for standar merge fields and ExecuteWithRegions for dynamic table
            doc.MailMerge.Execute(mergeFields, mergeValues);
            doc.MailMerge.ExecuteWithRegions(historyTable);

            //Save document
            doc.Save(MailMergeGoblaDocumentSettings.MailMergeOutputFileName);

        }

        public static void BuildMultipleDocuments()
        {
            foreach (var customer in CUSTOMER_CONTACT_INFO_LIST)
            {
                //Initialize Document
                var doc = new Document(MailMergeGoblaDocumentSettings.MailMergeIntputFileName);

                //Retain write space from the templeate
                doc.MailMerge.TrimWhitespaces = false;

                var chargeSummary = CHARGE_SUMMARY_LIST.First(c => c.AccountNumber == customer.AccountNumber);

                //Get the merge lists for the change summary
                List<string> chargeSummaryFields;
                List<object> chargeSummaryValues;
                MailMergeHelperMethod.GetMergeInfoFromObject(chargeSummary, out chargeSummaryFields,
                    out chargeSummaryValues);

                //Get the merge lists fos customer contact Info
                List<string> customerContactFields;
                List<object> customerContactValues;
                MailMergeHelperMethod.GetMergeInfoFromObject(customer, out customerContactFields,
                    out customerContactValues);

                //Populate teh table taht displays billing history
                var historyTable = MailMergeHelperMethod.CreateBillHistoryDataTable(NUMBER_OF_MONTH);
                historyTable.TableName = DATA_TABLE_NAME;

                //Create final merge arrays
                var mergeFields = chargeSummaryFields.Concat(customerContactFields).ToArray();
                var mergeValues = chargeSummaryValues.Concat(customerContactValues).ToArray();

                //A couple mail merge advance settings
                doc.MailMerge.UseNonMergeFields = true;
                doc.MailMerge.MappedDataFields.Add("BillDueDate", "DueDate");

                //Execute for standar merge fields and ExecuteWithRegions for dynamic table
                doc.MailMerge.Execute(mergeFields, mergeValues);
                doc.MailMerge.ExecuteWithRegions(historyTable);

                var fileName = MailMergeGoblaDocumentSettings.MailMergeOutputFileName + "-" + customer.LastName + "-" + customer.FirstName;

                //Save document
                doc.Save(fileName);

            }
        }


        public static void CreateDocumentsFromXml()
        {
            //Initialize DataSet
            var customers = new DataSet();

            //Read Xml into DataSet
            customers.ReadXml(MailMergeGoblaDocumentSettings.CustomerXmlFileName);
            
            //Create the new document
            var docXml = new Document(MailMergeGoblaDocumentSettings.MailMergeIntputFileNameXml);

            //Use each record int the table to create a new page in the document
            var customerDataTableXml = customers.Tables["customer"];
            docXml.MailMerge.Execute(customerDataTableXml);

            //Save the document
            docXml.Save(MailMergeGoblaDocumentSettings.MailMergeOutputFileNameXml);
        }
        #endregion

        #endregion
    }
}