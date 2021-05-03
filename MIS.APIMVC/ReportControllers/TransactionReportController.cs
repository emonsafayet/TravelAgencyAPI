using MIS.Library;
using Microsoft.Reporting.WebForms; 
using MIS.BusinessService.ReportService; 
using System.Collections.Generic; 
using System.Web.Mvc;
using ReportViewer = Microsoft.Reporting.WebForms.ReportViewer;
using MIS.Dto.Report;
using Newtonsoft.Json;

namespace MIS.APIMVC.ReportControllers
{
    public class TransactionReportController : Controller
    {
        private ReportService reportService = new ReportService();

        ReportViewer rptViewer = new ReportViewer();
        List<ReportParameter> parameters = new List<ReportParameter>();
        byte[] bytes = null;
        private object obj;
        public ActionResult GetDueStatusASONDetails(string ServiceCode, string FromDate)
        {
            var infos = reportService.GetDueStatusASONDetails(FromDate,ServiceCode);
            if (infos == null) return null;
            parameters.Add(new ReportParameter("FromDate", "FromDate Value"));  
            parameters.Add(new ReportParameter("ServiceCode", "ServiceCode Value"));
            rptViewer.ProcessingMode = ProcessingMode.Local;
            rptViewer.Width = 100;
            rptViewer.LocalReport.ReportPath = Server.MapPath("~/Reports/ServicerReport/DueReport.rdlc");

            rptViewer.LocalReport.EnableExternalImages = true;
            rptViewer.LocalReport.DataSources.Add(new ReportDataSource("GetDueStatusASONDetailsDataSet", infos));
            reportviewer();
            return File(bytes, "application/pdf");
        }
        public ActionResult GetSeriveCollectionDetails(string ServiceCode, string FromDate, string ToDate)
        {
            var infos = reportService.getTransactionCollectionDetailsByServiceCode(FromDate, ToDate, ServiceCode);
            if (infos == null) return null;
            parameters.Add(new ReportParameter("FromDate", "FromDate Value"));
            parameters.Add(new ReportParameter("ToDate", "ToDate Value"));
            parameters.Add(new ReportParameter("ServiceCode", "ServiceCode Value"));
            rptViewer.ProcessingMode = ProcessingMode.Local;
            rptViewer.Width = 100;
            rptViewer.LocalReport.ReportPath = Server.MapPath("~/Reports/ServicerReport/ServiceCollectionDetailsReportByServiceCode.rdlc");

            rptViewer.LocalReport.EnableExternalImages = true;
            rptViewer.LocalReport.DataSources.Add(new ReportDataSource("ServiceCollectionDataSet", infos));
            reportviewer();
            return File(bytes, "application/pdf");
        }
        public ActionResult GetSeriveDetails(string ServiceCode,string FromDate, string ToDate)
        {
            var infos = reportService.getTransactionServicedetailsbyServiceCode(FromDate,ToDate, ServiceCode);
            if (infos == null) return null;
            parameters.Add(new ReportParameter("FromDate", "FromDate Value"));
            parameters.Add(new ReportParameter("ToDate", "ToDate Value"));
            parameters.Add(new ReportParameter("ServiceCode", "ServiceCode Value"));
            rptViewer.ProcessingMode = ProcessingMode.Local;
            rptViewer.Width = 100;
            rptViewer.LocalReport.ReportPath = Server.MapPath("~/Reports/ServicerReport/ServiceDetailsReportByServiceCode.rdlc");

            rptViewer.LocalReport.EnableExternalImages = true;
            rptViewer.LocalReport.DataSources.Add(new ReportDataSource("TransactionServiceDetailsDataSet", infos));
            reportviewer();
            return File(bytes, "application/pdf");
        } 
        public ActionResult StatementReport(string objstr)
        {
            if (objstr == null) return null;
            JSONSerialize serialize = new JSONSerialize();
            ReportParamDto reqItems = serialize.JSONTextToObj<ReportParamDto>(objstr);
           

            if (reqItems.ReportName == null) return null;

            var rptFileName = reportName(reqItems.ReportName);
            if (rptFileName == "") return null;
            var dataSet= dataSetName(reqItems.ReportName);
            if (dataSet == "") return null;           

            if (reqItems.ReportName == "Card Statement")
            {
                obj =  reportService.GetCreditCardStatement(reqItems.FromDate, reqItems.ToDate, reqItems.Code);
                if (obj == null) return null;
                parameters.Add(new ReportParameter("FromDate", "FromDate Value"));
                parameters.Add(new ReportParameter("ToDate", "ToDate Value"));
                parameters.Add(new ReportParameter("cardCode", "cardCode Value")); 
            }              
            else if(reqItems.ReportName == "Customer Due")
            {
                obj = reportService.GetCustomerDueStatus(reqItems.ToDate, reqItems.Code);
                if (obj == null) return null;
                parameters.Add(new ReportParameter("ASONDate", "ASONDate Value"));
                parameters.Add(new ReportParameter("CustomerCode", "CustomerCode Value"));
            }
            else if (reqItems.ReportName == "Cutomser Statement")
            {
                obj = reportService.GetCustomerStatement(reqItems.Code);
                if (obj == null) return null; 
                parameters.Add(new ReportParameter("CustomerCode", "CustomerCode Value"));
            }
            else if (reqItems.ReportName == "Provider Statement")
            {
                obj = reportService.GetProviderSatement(reqItems.FromDate, reqItems.ToDate, reqItems.Code);
                if (obj == null) return null;
                parameters.Add(new ReportParameter("FromDate", "FromDate Value"));
                parameters.Add(new ReportParameter("ToDate", "ToDate Value"));
                parameters.Add(new ReportParameter("ProviderCode", "ProviderCode Value"));
            }
            printreportviewer(dataSet, rptFileName);
            return File(bytes, "application/pdf");
        }       
        public ActionResult MoneyReceipt(string receiptCode, string customerCode)
        {
            var mrMasterobj = reportService.GetMoneyReceipt(receiptCode);
            var mrPaymentDetailList = reportService.GetMRPaymentDetailsList(receiptCode);
            var mrServiceList = reportService.GetMoneyReceiptServiceList(receiptCode, customerCode);


            parameters.Add(new ReportParameter("ReceiptCode", "ReceiptCode Value"));
            parameters.Add(new ReportParameter("CustomerCode", "CustomerCode value"));

            rptViewer.ProcessingMode = ProcessingMode.Local;
            rptViewer.Width = 100;
            rptViewer.LocalReport.ReportPath = Server.MapPath("~/Reports/TransactionReport/MoneyReceipt.rdlc");

            rptViewer.LocalReport.EnableExternalImages = true;
            rptViewer.LocalReport.DataSources.Add(new ReportDataSource("MoneyReceiptMaster", mrMasterobj));
            rptViewer.LocalReport.DataSources.Add(new ReportDataSource("PaymentDetail", mrPaymentDetailList));
            rptViewer.LocalReport.DataSources.Add(new ReportDataSource("ServiceDetail", mrServiceList));
            reportviewer();
            return File(bytes, "application/pdf");


        }
        public ActionResult TopUpDetail(string topUpCode)
        {
            var obj = reportService.GetTopUpDetailByTopUpCode(topUpCode);


            parameters.Add(new ReportParameter("topUpCode", "topUpCode Value"));

            rptViewer.ProcessingMode = ProcessingMode.Local;
            rptViewer.Width = 100;
            rptViewer.LocalReport.ReportPath = Server.MapPath("~/Reports/TransactionReport/TopUpDetail.rdlc");

            rptViewer.LocalReport.EnableExternalImages = true;
            rptViewer.LocalReport.DataSources.Add(new ReportDataSource("TopUpDataSet", obj));
            reportviewer();
            return File(bytes, "application/pdf");


        }
        public ActionResult onlineRegistrationDetail(string onlineRegCode)
        {
            var obj = reportService.GetOnelineRegistrationByRegCode(onlineRegCode);


            parameters.Add(new ReportParameter("regCode", "regCode Value"));

            rptViewer.ProcessingMode = ProcessingMode.Local;
            rptViewer.Width = 100;
            rptViewer.LocalReport.ReportPath = Server.MapPath("~/Reports/TransactionReport/OnlineReg.rdlc");

            rptViewer.LocalReport.EnableExternalImages = true;
            rptViewer.LocalReport.DataSources.Add(new ReportDataSource("OnlineRegDataSet", obj));
            reportviewer();
            return File(bytes, "application/pdf");


        }
        public ActionResult VisaRegistrationPrint(string transactionCode)
        {
            var obj = reportService.GetVisaRegistrationByVisaRegCode(transactionCode);

            parameters.Add(new ReportParameter("TransactionCode", "TransactionCode Value"));

            rptViewer.ProcessingMode = ProcessingMode.Local;
            rptViewer.Width = 100;
            rptViewer.LocalReport.ReportPath = Server.MapPath("~/Reports/TransactionReport/VisaRegistration.rdlc");

            rptViewer.LocalReport.EnableExternalImages = true;
            rptViewer.LocalReport.DataSources.Add(new ReportDataSource("VisaRegDataSet", obj));
            reportviewer();
            return File(bytes, "application/pdf");


        }
        public ActionResult GetAirTicketRegistrationByAirTicketRegCode(string airticketRegCode)
        {
            var obj = reportService.GetAirTicketRegistrationByAirTicketRegCode(airticketRegCode);


            parameters.Add(new ReportParameter("AirTicketTransCode", "AirTicketTransCode Value"));

            rptViewer.ProcessingMode = ProcessingMode.Local;
            rptViewer.Width = 100;
            rptViewer.LocalReport.ReportPath = Server.MapPath("~/Reports/TransactionReport/AirticketReg.rdlc");

            rptViewer.LocalReport.EnableExternalImages = true;
            rptViewer.LocalReport.DataSources.Add(new ReportDataSource("AirTicketRegDataSet", obj));
            reportviewer();
            return File(bytes, "application/pdf");


        }
        public ActionResult GetHotelBookingTransactionCode(string transactionCode)
        {
            var obj = reportService.GetHotelBookingTransactionCode(transactionCode);


            parameters.Add(new ReportParameter("TransactionCode", "TransactionCode Value"));

            rptViewer.ProcessingMode = ProcessingMode.Local;
            rptViewer.Width = 100;
            rptViewer.LocalReport.ReportPath = Server.MapPath("~/Reports/TransactionReport/HotelBooking.rdlc");

            rptViewer.LocalReport.EnableExternalImages = true;
            rptViewer.LocalReport.DataSources.Add(new ReportDataSource("HotelBookingDataSet", obj));
            reportviewer();
            return File(bytes, "application/pdf");


        }
        public ActionResult GroupTour(string TransactionCode)
        {
            var basicAndCustomerInfo = reportService.GetGroupTourCustomerAndBasicinformations(TransactionCode);
            var participantInfo = reportService.GetGroupTourParticipantinformations(TransactionCode);
            var detailsInfo = reportService.GetGroupTourDetailsInformations(TransactionCode);


            parameters.Add(new ReportParameter("TransactionCode", "TransactionCode Value")); 

            rptViewer.ProcessingMode = ProcessingMode.Local;
            rptViewer.Width = 100;
            rptViewer.LocalReport.ReportPath = Server.MapPath("~/Reports/TransactionReport/GroupTour.rdlc");

            rptViewer.LocalReport.EnableExternalImages = true;
            rptViewer.LocalReport.DataSources.Add(new ReportDataSource("GroupTourCustomerInfoDataSet", basicAndCustomerInfo));
            rptViewer.LocalReport.DataSources.Add(new ReportDataSource("GrouptourPartitipantInfoDataSet", participantInfo));
            rptViewer.LocalReport.DataSources.Add(new ReportDataSource("GrouptourDetailsInfoDataSet", detailsInfo));
            reportviewer();
            return File(bytes, "application/pdf");


        }
        public void reportviewer()
        {
            
            rptViewer.LocalReport.SetParameters(parameters);
            rptViewer.LocalReport.Refresh();
            Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;
            bytes = rptViewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

        }
        public void printreportviewer(string dataSet, string reportFileName)
        {
            rptViewer.ProcessingMode = ProcessingMode.Local;
            rptViewer.Width = 100;
            rptViewer.LocalReport.ReportPath = Server.MapPath("~/Reports/StatementReport/" + reportFileName + ".rdlc");

            rptViewer.LocalReport.EnableExternalImages = true;
            rptViewer.LocalReport.DataSources.Add(new ReportDataSource("" + dataSet + "", obj));

            rptViewer.LocalReport.SetParameters(parameters);
            rptViewer.LocalReport.Refresh();
            Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;
            bytes = rptViewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

        }
        public string reportName(string ReportName)
        {

            var reportName = "";
            if (ReportName == "Card Statement")
                reportName = "CreditCardStatement";
            else if (ReportName == "Customer Due")
                reportName = "CustomerDueStatement";
            else if (ReportName == "Provider Statement")
                reportName = "ProviderStatement";
            else if (ReportName == "Cutomser Statement")
                reportName = "CustomerStatement";
            else
                reportName = "";
            return reportName;
        }
        public string dataSetName(string ReportName)
        {
            var dataSetName = "";
            if (ReportName == "Card Statement")
                dataSetName = "CreditCardStatementDataSet";
            else if (ReportName== "Customer Due")
                dataSetName = "CustomerDueStatementDataSet";
            else if (ReportName == "Provider Statement")
                dataSetName = "ProviderStatementDataSet";
            else if (ReportName == "Cutomser Statement")
                dataSetName = "CustomerStatementDataSet";
            else
                dataSetName = "";
            return dataSetName;
        }
    }
}