using MIS.BusinessService.ReportService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MIS.APIMVC.ReportControllers
{
    public class ReportController : ApiController
    {
        public ReportService reportService = new ReportService(); 
        
        //Get Report List
        [HttpGet]
        [Route("~/api/client/business/travel/transaction/report/list")]
        public HttpResponseMessage GetReportList()
        {
            try
            {
                return MISResponse.Return(reportService.GetReportList(), reportService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        //Get Service Summary
        [HttpGet]
        [Route("~/api/client/business/travel/transaction/report/service/transaction/summary/list/{fromDate}/{toDate}")]
        public HttpResponseMessage GetServiceTransactionSummaryList(string fromDate,string toDate)
        {
            try
            {
                return MISResponse.Return(reportService.GetServiceTransactionSummaryList(fromDate, toDate), reportService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        [HttpGet]
        [Route("~/api/client/business/travel/transaction/report/service/transaction/detail/list/{fromDate}/{toDate}/{serviceCode}")]
        public HttpResponseMessage GetServiceTransactionSummaryList(string fromDate, string toDate,string serviceCode)
        {
            try
            {
                return MISResponse.Return(reportService.getTransactionServicedetailsbyServiceCode(fromDate, toDate, serviceCode), reportService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpGet]
        [Route("~/api/client/business/travel/transaction/report/service/transaction/collection/summary/list/{fromDate}/{toDate}")]
        public HttpResponseMessage getTransactionCollectionSummary(string fromDate, string toDate)
        {
            try
            {
                return MISResponse.Return(reportService.getTransactionCollectionSummary(fromDate, toDate), reportService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        [HttpGet]
        [Route("~/api/client/business/travel/transaction/report/service/transaction/collection/details/service/code/{fromDate}/{toDate}/{serviceCode}")]
        public HttpResponseMessage getTransactionCollectionDetailsByServiceCode(string fromDate, string toDate,string serviceCode)
        {
            try
            {
                return MISResponse.Return(reportService.getTransactionCollectionDetailsByServiceCode(fromDate, toDate, serviceCode), reportService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        [HttpGet]
        [Route("~/api/client/business/travel/transaction/report/service/customer/advance/collection/list/{fromDate}/{toDate}")]
        public HttpResponseMessage getCustomerAdvanceSummary(string fromDate, string toDate)
        {
            try
            {
                return MISResponse.Return(reportService.getCustomerAdvanceSummary(fromDate, toDate), reportService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpGet]
        [Route("~/api/client/business/travel/transaction/report/service/transaction/due/summary/{asondate}")]
        public HttpResponseMessage GetDueStatusASON(string asondate)
        {
            try
            {
                return MISResponse.Return(reportService.GetDueStatusASON(asondate), reportService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpGet]
        [Route("~/api/client/business/travel/transaction/report/service/transaction/due/detail/{asondate}/{serviceCode}")]
        public HttpResponseMessage GetDueStatusASONDetails(string asondate,string serviceCode)
        {
            try
            {
                return MISResponse.Return(reportService.GetDueStatusASONDetails(asondate, serviceCode), reportService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
 
    }
}
