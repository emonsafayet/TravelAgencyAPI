using MIS.Data.ClientModel;
using MIS.Data.Repositories;
using MIS.Dto.Report;
using MIS.Dto.TransactionDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.BusinessService.ReportService
{
    public class ReportService
    {
        public Exception Error = new Exception();

        public List<Report> GetReportList()
        {
            try
            {
                return new BusinessManageGenericRepository<Report>().GetAll().OrderBy(o => o.ReportName).ToList();
            }
            catch (Exception ex) { Error = ex; return null; }
        }
        public List<ServiceTransactionSummaryDTO> GetServiceTransactionSummaryList(string fromDate, string toDate)
        {
            try
            {
                return new BusinessManageGenericRepository<ServiceTransactionSummaryDTO>().FindUsingSP("getTransactionServiceSummary @FromDate,@ToDate",
                                                                                    new SqlParameter("@FromDate", fromDate),
                                                                                    new SqlParameter("@ToDate", toDate));
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        // START Service Transaction 
        public List<rptCreditCardStatementDto> GetCreditCardStatement(string FromDate, string ToDate, string Code)
        {
            try
            {
                if (Code == null) Code = "";
                return new BusinessManageGenericRepository<rptCreditCardStatementDto>().FindUsingSP("rptgetCreditCardStatement @FromDate,@ToDate,@cardCode",
                                                                                    new SqlParameter("@FromDate", FromDate),
                                                                                    new SqlParameter("@ToDate", ToDate),
                                                                                    new SqlParameter("@cardCode", Code)).OrderByDescending(i => i.TransactionDate).ToList();

            }
            catch (Exception ex) { Error = ex; return null; }
        }
        //Get Customer Due Statement Report
        public List<rptCustomerDueStatusDto> GetCustomerDueStatus(string ASONDate, string cardCode)
        {
            try
            {
                if (cardCode == null) cardCode = "";
                return new BusinessManageGenericRepository<rptCustomerDueStatusDto>().FindUsingSP("rptGetCustomerDueStatus @ASONDate,@CustomerCode",
                                                                                   new SqlParameter("@ASONDate", ASONDate),
                                                                                   new SqlParameter("@CustomerCode", cardCode)).OrderByDescending(i => i.InvoiceDate).ToList();
            }
            catch (Exception ex) { Error = ex; return null; }
        }
        public List<ServiceTransactionDetailDTO> getTransactionServicedetailsbyServiceCode(string fromDate, string toDate, string serviceCode)
        {
            try
            {
                return new BusinessManageGenericRepository<ServiceTransactionDetailDTO>().FindUsingSP("getTransactionServicedetailsbyServiceCode @FromDate,@ToDate,@ServiceCode",
                                                                                    new SqlParameter("@FromDate", fromDate),
                                                                                    new SqlParameter("@ToDate", toDate),
                                                                                    new SqlParameter("@ServiceCode", serviceCode));
            }
            catch (Exception ex) { Error = ex; return null; }
        }
        public List<RPTgetProviderStatementDTO> GetProviderSatement(string fromDate, string toDate, string ProviderCode)
        {
            try
            {
                if (ProviderCode == null) ProviderCode = "";
                return new BusinessManageGenericRepository<RPTgetProviderStatementDTO>().FindUsingSP("RPTgetProviderStatement @FromDate,@ToDate,@ProviderCode",
                                                                                    new SqlParameter("@FromDate", fromDate),
                                                                                    new SqlParameter("@ToDate", toDate),
                                                                                    new SqlParameter("@ProviderCode", ProviderCode));
            }
            catch (Exception ex) { Error = ex; return null; }
        }
        public List<rptGetCustomerStatement> GetCustomerStatement(string code)
        {
            try
            {
                if (code == null) code = "";
                List<rptGetCustomerStatement> list = new BusinessManageGenericRepository<rptGetCustomerStatement>().
                    FindUsingSP("rptGetCustomerStatement @CustomerCode",
            new SqlParameter("@CustomerCode", code)).OrderByDescending(i => i.TransactionDate).ToList();
                return list;
            }
            catch (Exception ex) { Error = ex; return null; }
        }
        // END Service Transaction 


        //Start Transaction CollectionDetails 
        public List<TransactionCollectionSummaryDTO> getTransactionCollectionSummary(string fromDate, string toDate)
        {
            try
            {
                return new BusinessManageGenericRepository<TransactionCollectionSummaryDTO>().FindUsingSP("getTransactionCollectionSummary @FromDate,@ToDate",
                                                                                    new SqlParameter("@FromDate", fromDate),
                                                                                    new SqlParameter("@ToDate", toDate));
            }
            catch (Exception ex) { Error = ex; return null; }
        }
        public List<TransactionCollectionDetailsDto> getTransactionCollectionDetailsByServiceCode(string fromDate, string toDate, string ServiceCode)
        {
            try
            {
                List<TransactionCollectionDetailsDto> list = new BusinessManageGenericRepository<TransactionCollectionDetailsDto>().FindUsingSP("getTransactionCollectionDetailsByServiceCode @FromDate,@ToDate,@ServiceCode",
                                                                                                    new SqlParameter("@FromDate", fromDate),
                                                                                                    new SqlParameter("@ToDate", toDate), new SqlParameter("@ServiceCode", ServiceCode));
                return list;
            }
            catch (Exception ex) { Error = ex; return null; }
        }
        public List<CustomerAdvanceSummaryDto> getCustomerAdvanceSummary(string fromDate, string toDate)
        {
            try
            {
                return new BusinessManageGenericRepository<CustomerAdvanceSummaryDto>().FindUsingSP("getCustomerAdvanceSummary @FromDate,@ToDate",
                                                                                    new SqlParameter("@FromDate", fromDate),
                                                                                    new SqlParameter("@ToDate", toDate));
            }
            catch (Exception ex) { Error = ex; return null; }
        }
        //END  Transaction CollectionDetails 


        //START Transaction Dues
        public List<DueStatusASONDto> GetDueStatusASON(string ASONDate)
        {
            try
            {
                return new BusinessManageGenericRepository<DueStatusASONDto>().FindUsingSP("GetDueStatusASON @ASONDate",
                                                                                    new SqlParameter("@ASONDate", ASONDate));
            }
            catch (Exception ex) { Error = ex; return null; }
        }
        public List<DueStatusASONDetailsDto> GetDueStatusASONDetails(string ASONDate, string ServiceCode)
        {
            try
            {
                return new BusinessManageGenericRepository<DueStatusASONDetailsDto>().FindUsingSP("GetDueStatusASONDetails @ASONDate,@ServiceCode",
                                                                                    new SqlParameter("@ASONDate", ASONDate),
                                                                                    new SqlParameter("@ServiceCode", ServiceCode));
            }
            catch (Exception ex) { Error = ex; return null; }
        }
        //END Transaction Dues


        //START Print Money receipt 
        public List<rptMRServiceDetailsDTO> GetMoneyReceiptServiceList(string receiptCode, string CustomerCode)
        {
            return new BusinessManageGenericRepository<rptMRServiceDetailsDTO>().FindUsingSP("getEditServiceDetailByReceiptCode @ReceiptCode,  @CustomerCode",
                                                                                                    new SqlParameter("@ReceiptCode", receiptCode),
                                                                                                     new SqlParameter("@CustomerCode", CustomerCode)).ToList();
        }
        public List<rptMRPaymentDetailsDTO> GetMRPaymentDetailsList(string receiptCode)
        {
            return new BusinessManageGenericRepository<rptMRPaymentDetailsDTO>().FindUsingSP("rptMRPaymentDetails @ReceiptCode", new SqlParameter("@ReceiptCode", receiptCode)).ToList();
        }
        public List<rptMoneyreceiptMasterDTO> GetMoneyReceipt(string receiptCode)
        {
            return new BusinessManageGenericRepository<rptMoneyreceiptMasterDTO>().FindUsingSP("rptMoneyreceiptMaster @ReceiptCode", new SqlParameter("@ReceiptCode", receiptCode)).ToList();
        }
        //END Print Money receipt 


        //START TOP UP REPORT
        public List<rptTopUpDetailsDto> GetTopUpDetailByTopUpCode(string topUpCode)
        {
            return new BusinessManageGenericRepository<rptTopUpDetailsDto>().FindUsingSP("rptTopUpDetails @topUpCode", new SqlParameter("@topUpCode", topUpCode)).ToList();
        }
        //END TOP UP REPORT

        //START Online Registration REPORT
        public List<rptgetOnlineRegistationByregCodeDto> GetOnelineRegistrationByRegCode(string regCode)
        {
            return new BusinessManageGenericRepository<rptgetOnlineRegistationByregCodeDto>().FindUsingSP("rptgetOnlineRegistationByregCode @regCode", new SqlParameter("@regCode", regCode)).ToList();
        }
        //END Online Registration REPORT

        //START Visa Registration Report
        public List<rptGetVisaRegistationByVisaRegCodeDto> GetVisaRegistrationByVisaRegCode(string transactionCode)
        {
            return new BusinessManageGenericRepository<rptGetVisaRegistationByVisaRegCodeDto>().FindUsingSP("rptgetVisaRegistationByVisaRegCode @TransactionCode", new SqlParameter("@TransactionCode", transactionCode)).ToList();
        }
        //END Visa Registration Report

        //START Airticket Reg
        public List<AirTicketRegDto> GetAirTicketRegistrationByAirTicketRegCode(string airTicketTransCode)
        {
            return new BusinessManageGenericRepository<AirTicketRegDto>().FindUsingSP("rptGetAirTicketRegistrationByArTktTransCode @AirTicketTransCode", new SqlParameter("@AirTicketTransCode", airTicketTransCode)).ToList();
        }
        //END Airticket Reg


        //START Hotel Booking
        public List<HotelBookingByTransCodeDto> GetHotelBookingTransactionCode(string transactionCode)
        {
            return new BusinessManageGenericRepository<HotelBookingByTransCodeDto>().FindUsingSP("rptgetHotelBookingByTransCode @TransactionCode", new SqlParameter("@TransactionCode", transactionCode)).ToList();
        }
        //END  Hotel Booking


        //Start Group Tour Informations
        public List<rptGetGroupTourbytransCodeDto> GetGroupTourCustomerAndBasicinformations(string TransactionCode)
        {
            return new BusinessManageGenericRepository<rptGetGroupTourbytransCodeDto>().FindUsingSP("rptgetGroupTourbytransCode @TransactionCode", new SqlParameter("@TransactionCode", TransactionCode)).ToList();
        }

        public List<rptGetGroupMemberbytransCodeDto> GetGroupTourParticipantinformations(string TransactionCode)
        {
            return new BusinessManageGenericRepository<rptGetGroupMemberbytransCodeDto>().FindUsingSP("rptgetGroupMemberbytransCode @TransactionCode", new SqlParameter("@TransactionCode", TransactionCode)).ToList();
        }

        public List<rptGetGroupDetailsbytransCodeDto> GetGroupTourDetailsInformations(string TransactionCode)
        {
            return new BusinessManageGenericRepository<rptGetGroupDetailsbytransCodeDto>().FindUsingSP("rptgetGroupDetailsbytransCode @TransactionCode", new SqlParameter("@TransactionCode", TransactionCode)).ToList();
        }

        //End Group Tour Informations


    }
}
