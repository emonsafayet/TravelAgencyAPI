using MIS.BusinessService.BusinessService;
using MIS.Data.ClientModel;
using MIS.Dto.BusinessDTO;
using MIS.Dto.TransactionDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MIS.APIMVC.MasterEntryController
{
    public class TransactionController : ApiController
    {
        public TransactionCommonService transactionCommonService = new TransactionCommonService();

        //POST TopUp
        [HttpPost]
        [Route("~/api/client/business/travel/transaction/topUp/save/update")]
        public HttpResponseMessage saveUpdateToUp(TopUp topUp)
        {
            try
            {
                return MISResponse.Return(transactionCommonService.SaveUpdateTopUp(topUp), transactionCommonService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        //GET TopUp LIST
        [HttpGet]
        [Route("~/api/client/business/travel/transaction/topUp/list")]
        public HttpResponseMessage GetTopUpList()
        {
            try
            {
                return MISResponse.Return(transactionCommonService.GetTopUpList(), transactionCommonService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

       

        //GET TopUp LIST
        [HttpGet]
        [Route("~/api/client/business/travel/transaction/topUp/type/list")]
        public HttpResponseMessage GetTopUptypeList()
        {
            try
            {
                return MISResponse.Return(transactionCommonService.GetTopUpTypeList(), transactionCommonService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        //GET Online Registaion LIST
        [HttpGet]
        [Route("~/api/client/business/travel/transaction/online/registation/list")]
        public HttpResponseMessage GetOnlineRegisationList()
        {
            try
            {
                return MISResponse.Return(transactionCommonService.GetOnlineRegisationList(), transactionCommonService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        //GET Online Registaion Details
        [HttpGet]
        [Route("~/api/client/business/travel/transaction/online/registation/details/by/transactionCode/{transactionCode}")]
        public HttpResponseMessage getOnlineRegistrationDetailsByTransactionCode(string transactionCode)
        {
            try
            {
                return MISResponse.Return(transactionCommonService.getOnlineRegistrationDetailsByTransactionCode(transactionCode), transactionCommonService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        //POST Online Registaion
        [HttpPost]
        [Route("~/api/client/business/travel/transaction/online/registation/save/update")]
        public HttpResponseMessage SaveUpdateOnlineRegisation(OnlineRegistationDTO onlineRegistation)
        {
            try
            {
                return MISResponse.Return(transactionCommonService.SaveUpdateOnlineRegisation(onlineRegistation), transactionCommonService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        //GET Company Dropdown List
        [HttpGet]
        [Route("~/api/client/business/travel/transaction/company/list")]
        public HttpResponseMessage GETCompanyLIST()
        {
            try
            {
                return MISResponse.Return(transactionCommonService.GETCompanyLIST(), transactionCommonService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpGet]
        [Route("~/api/client/business/travel/transaction/sales/staff/list")]
        public HttpResponseMessage GETSalesStaffLIST()
        {
            try
            {
                return MISResponse.Return(transactionCommonService.GETSalesStaffLIST(), transactionCommonService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
       
        [HttpGet]
        [Route("~/api/client/business/travel/transaction/Active/Currency/Rate/list")]
        public HttpResponseMessage GETActiveCurrencyRateLIST()
        {
            try
            {
                return MISResponse.Return(transactionCommonService.GETActiveCurrencyRateLIST(), transactionCommonService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpGet]
        [Route("~/api/client/business/travel/transaction/Visa/Type/list")]
        public HttpResponseMessage GETVisaTypeLIST()
        {
            try
            {
                return MISResponse.Return(transactionCommonService.GETVisaTypeLIST(), transactionCommonService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        //POST Visa Type
        [HttpPost]
        [Route("~/api/client/business/travel/transaction/Visa/Type/save/update")]
        public HttpResponseMessage SaveUpdateVisaType(VisaType visaType)
        {
            try
            {
                return MISResponse.Return(transactionCommonService.SaveUpdateVisaType(visaType), transactionCommonService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        //GET Visa Registation
        [HttpGet]
        [Route("~/api/client/business/travel/transaction/Visa/Registation/list")]
        public HttpResponseMessage GETVisaRegistationLIST()
        {

            try
            {
                return MISResponse.Return(transactionCommonService.GETVisaRegistationLIST(), transactionCommonService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        //POST Visa Registationn
        [HttpPost]
        [Route("~/api/client/business/travel/transaction/Visa/Registation/save/update")]
        public HttpResponseMessage SaveUpdateVisaRegisation(VisaRegistationDTO dto)
        {
            try
            {
                return MISResponse.Return(transactionCommonService.SaveUpdateVisaRegisation(dto), transactionCommonService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        //GET Visa Registration Details By TransactionCode
        [HttpGet]
        [Route("~/api/client/business/travel/transaction/Visa/Registration/details/by/transactionCode/{transactionCode}")]
        public HttpResponseMessage getVisaRegDetailsByTransactionCode(string transactionCode)
        {

            try
            {
                return MISResponse.Return(transactionCommonService.getVisaRegDetailsByTransactionCode(transactionCode), transactionCommonService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        //GET Air Ticket Registration
        [HttpGet]
        [Route("~/api/client/business/travel/transaction/Air/Ticket/Registration/list")]
        public HttpResponseMessage GETAirTicketLIST()
        {

            try
            {
                return MISResponse.Return(transactionCommonService.GetAirTickeLIST(), transactionCommonService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        //GET Air Ticket Registration
        [HttpGet]
        [Route("~/api/client/business/travel/transaction/Air/Ticket/Registration/details/by/transactionCode/{transactionCode}")]
        public HttpResponseMessage getAirTicketDetailsByTransactionCode(string transactionCode)
        {

            try
            {
                return MISResponse.Return(transactionCommonService.getAirTicketDetailsByTransactionCode(transactionCode), transactionCommonService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        

        // POST Air Ticket Registration
        [HttpPost]
        [Route("~/api/client/business/travel/transactionSeat/Air/Ticket/Registration/save/update")]
        public HttpResponseMessage SaveUpdateAirTicketRegistration(AirTicketRegMasterDTO dto)
        {
            try
            {
                return MISResponse.Return(transactionCommonService.SaveUpdateAirTicketRegisation(dto), transactionCommonService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        // Forward Air Ticket Registration
        [HttpPost]
        [Route("~/api/client/business/travel/transactionSeat/Air/Ticket/Registration/update/forward")]
        public HttpResponseMessage UpdateForwardAirTicketRegistration(AirTicketRegMasterDTO dto)
        {
            try
            {
                return MISResponse.Return(transactionCommonService.UpdateForwardAirTicketRegistration(dto), transactionCommonService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        // Cancellation Air Ticket Registration
        [HttpPost]
        [Route("~/api/client/business/travel/transactionSeat/Air/Ticket/Registration/update/client")]
        public HttpResponseMessage UpdateCancellingAirTicketRegistration(AirTicketRegMasterDTO dto)
        {
            try
            {
                return MISResponse.Return(transactionCommonService.UpdateCancellingAirTicketRegistration(dto), transactionCommonService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        //GET hotel Booking
        [HttpGet]
        [Route("~/api/client/business/travel/transaction/hotel/booking/list")]
        public HttpResponseMessage GETHotelBookingLIST()
        {

            try
            {
                return MISResponse.Return(transactionCommonService.GetHotelBookinLIST(), transactionCommonService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        //POST hotel  Booking
        [HttpPost]
        [Route("~/api/client/business/travel/transactionSeat/hotel/booking/save/update")]
        public HttpResponseMessage SaveUpdateHotelBooking(HotelBookingDTO dto)
        {
            try
            {
                return MISResponse.Return(transactionCommonService.SaveUpdateHotelBooking(dto), transactionCommonService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        //GET HotelBooking Details By TransactionCode
        [HttpGet]
        [Route("~/api/client/business/travel/transaction/hotel/booking/details/by/transactionCode/{transactionCode}")]
        public HttpResponseMessage getHotelDetailsByTransactionCode(string transactionCode)
        {

            try
            {
                return MISResponse.Return(transactionCommonService.getHotelDetailsByTransactionCode(transactionCode), transactionCommonService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        
        //Post Holiday Package Tour
        [HttpPost]
        [Route("~/api/client/business/travel/transaction/holiday/package/tour/save/update")]
        public HttpResponseMessage saveUpdateHolidayPackageTour([FromBody] HolidayPackageTourMasterDTO holidayPackageTourMasterDTO)
        {
            try
            {
                return MISResponse.Return(transactionCommonService.saveUpdateHolidayPackageTour(holidayPackageTourMasterDTO), transactionCommonService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        //GET Holiday Package Tour List
        [HttpGet]
        [Route("~/api/client/business/travel/transaction/holiday/package/tour/list")]
        public HttpResponseMessage getholidayPackageTourList()
        {

            try
            {
                return MISResponse.Return(transactionCommonService.getholidayPackageTourList(), transactionCommonService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        //GET Holiday Package Details By HOPCode
        [HttpGet]
        [Route("~/api/client/business/travel/holiday/package/tour/hop/code/{hopCode}")]
        public HttpResponseMessage getHolidayPackageDetailByHOPCodeList(string hopCode)
        {
            try
            {
                return MISResponse.Return(transactionCommonService.getHolidayPackageDetailByHOPCodeList(hopCode), transactionCommonService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // Client  Advance Payment 


        //Post Holiday Package Tour
        [HttpPost]
        [Route("~/api/client/business/travel/transaction/advance/payment/save/update")]
        public HttpResponseMessage saveUpdateAdvancePayment(ClientAdvancePayment advancePayment)
        {
            try
            {
                return MISResponse.Return(transactionCommonService.saveUpdateAdvancePayment(advancePayment), transactionCommonService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet]
        [Route("~/api/client/business/travel/transaction/advance/payment/list")]
        public HttpResponseMessage getAdvancePayment()
        {
            try
            {
                return MISResponse.Return(transactionCommonService.getAdvancePaymentList(), transactionCommonService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Payment information By Customer
        [HttpGet]
        [Route("~/api/client/business/travel/transaction/money/receipt/service/list/{customerCode}")]
        public HttpResponseMessage getServiceListByCustomerCode(string customerCode)
        {
            try
            {
                return MISResponse.Return(transactionCommonService.getServiceListByCustomerCode(customerCode), transactionCommonService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Post Money Receipt
        [HttpPost]
        [Route("~/api/client/business/travel/transaction/money/receipt/save/update")]
        public HttpResponseMessage saveUpdateMoenyReceipt([FromBody] MoneyReceiptDTO moneyReceiptDTO)
        {
            try
            {
                return MISResponse.Return(transactionCommonService.saveUpdateMoenyReceipt(moneyReceiptDTO), transactionCommonService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Money List
        [HttpGet]
        [Route("~/api/client/business/travel/transaction/money/receipt/list/{fromDate}/{toDate}")]
        public HttpResponseMessage getMoneyReceiptList(string fromDate, string toDate)
        {
            try
            {
                return MISResponse.Return(transactionCommonService.getMoneyReceiptList(fromDate, toDate), transactionCommonService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }        

        //GET Money Receipt Invoice Detail Data By ReceiptCode
        [HttpGet]
        [Route("~/api/client/business/travel/money/receipt/invoice/payment/detail/code/{receiptCode}/{customerCode}")]
        public HttpResponseMessage getMoneyReceiptInvoiceAndPaymentDetailsDetail(string receiptCode, string customerCode)
        {
            try
            {
                return MISResponse.Return(transactionCommonService.getMoneyReceiptInvoiceAndPaymentDetailsDetail(receiptCode, customerCode), transactionCommonService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        //GET Money Receipt Invoice Detail Data By ReceiptCode
        [HttpGet]
        [Route("~/api/client/business/travel/money/receipt/customer/advance/amount/{customerCode}")]
        public HttpResponseMessage GetCustomerAdvanceAmount(string customerCode)
        {
            try
            {
                return MISResponse.Return(transactionCommonService.GetCustomerAdvanceAmount(customerCode), transactionCommonService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        } 


        //GET MR Customer List
        [HttpGet]
        [Route("~/api/client/business/travel/MR/customer/list")]
        public HttpResponseMessage getMRcustomerList()
        {
            try
            {
                return MISResponse.Return(transactionCommonService.getMRcustomerList(), transactionCommonService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        //GET Advance Payment Not Clearance On Cheque
        [HttpGet]
        [Route("~/api/client/business/travel/advance/payment/clearance/list")]
        public HttpResponseMessage getAdvancePaymentNotClearanceList()
        {
            try
            {
                return MISResponse.Return(transactionCommonService.getAdvancePaymentNotClearanceList(), transactionCommonService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        //Update  Payment Not Clearance On Cheque
        [HttpPost]
        [Route("~/api/client/business/travel/advance/payment/clearance/update")]
        public HttpResponseMessage updateadvanceClearance(ClientAdvancePayment dto)
        {
            try
            {
                return MISResponse.Return(transactionCommonService.updateadvanceClearance(dto), transactionCommonService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        //GET Group Tour Registration List
        [HttpGet]
        [Route("~/api/client/business/travel/transaction/group/tour/list")]
        public HttpResponseMessage getGroupTourList()
        {
            try
            {
                return MISResponse.Return(transactionCommonService.getGroupTourList(), transactionCommonService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // POST Group Tour Registration
        [HttpPost]
        [Route("~/api/client/business/travel/transaction/group/tour/save/update")]
        public HttpResponseMessage saveUpdateGroupTour(GrouptourMasterDTO dto)
        {
            try
            {
                return MISResponse.Return(transactionCommonService.saveUpdateGroupTour(dto), transactionCommonService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        //GET Group Tour Registration Details by Transaction Code
        [HttpGet]
        [Route("~/api/client/business/travel/transaction/group/tour/by/transaction/Code/{TransactionCode}")]
        public HttpResponseMessage GetGroupTourDetailsbyTransactionCode(string TransactionCode)
        {
            try
            {
                return MISResponse.Return(transactionCommonService.GetGroupTourDetailsbyTransactionCode(TransactionCode), transactionCommonService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // Cancellation Group Tour Registration
        [HttpPost]
        [Route("~/api/client/business/travel/transaction/group/tour/cancellation")]
        public HttpResponseMessage updateGroupTourCancellation(GrouptourMasterDTO dto)
        {
            try
            {
                return MISResponse.Return(transactionCommonService.updateGroupTourCancellation(dto), transactionCommonService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
