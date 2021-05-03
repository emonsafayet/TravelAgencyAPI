using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.Owin.Security.OAuth;
using MIS.BusinessService.SysService;
using MIS.Data.SysModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace MIS.APIMVC
{
    public static class MISResponse
    {
        public static HttpResponseMessage Return(object Data, Exception Error, HttpRequestMessage Request)
        {
            try
            {
                try { saveRequest(Request); } catch { }
                if (Data != null) return Request.CreateResponse(HttpStatusCode.OK, Data);
                else
                {
                    try
                    {
                        saveError(Error, Request);
                    }
                    catch { }
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, Error);
                }
            }
            catch { return null; }
        }

        public static void saveError(Exception Error, HttpRequestMessage Request)
        {
            try
            {
                if (Error == null) return;
                string ExceptionTitle = "";
                string ExceptionDetails = "";
                string Route = "";

                if (!string.IsNullOrEmpty(Error.Message)) ExceptionTitle = Error.Message;
                ExceptionDetails = getAllErrorString(Error);

                string validationError = getValidationError(Error);

                if (!string.IsNullOrEmpty(validationError)) ExceptionDetails += ", Validation Error: " + validationError;

                if (Request != null && Request.RequestUri != null && !string.IsNullOrEmpty(Request.RequestUri.AbsolutePath)) Route = Request.RequestUri.AbsolutePath;
                if (!string.IsNullOrEmpty(Route) && Route.IndexOf("/lplmis/api/") > -1) Route = Route.Replace("/lplmis/api/", "");

                if (ExceptionTitle.Length > 500) ExceptionTitle = ExceptionTitle.Substring(0, 500);
                if (ExceptionDetails.Length > 5000) ExceptionDetails = ExceptionDetails.Substring(0, 5000);

                ErrorLog newLog = new ErrorLog();

                newLog.APIURL = Route;
                newLog.EmployeeCode = Request.Headers.CacheControl.ToString();
                newLog.ErrorTitle = ExceptionTitle;
                newLog.ErrorDetail = ExceptionDetails;
                newLog.IsSolved = false;
                newLog.CreatedOn = DateTime.Now;
                newLog.CreatedBy = Request.Headers.CacheControl.ToString();

                new UserService().saveErrorLog(newLog);

                return;
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public static string getAllErrorString(Exception ex)
        {
            try
            {
                string Message = "";

                // Source
                if (!string.IsNullOrEmpty(ex.Source)) Message = "Source -> " + ex.Source + "\r\n";

                // Message
                if (!string.IsNullOrEmpty(ex.Message) && ex.Message.IndexOf("See the inner exception for details") == -1) Message += ex.Message + "\r\n";

                if (ex.InnerException != null)
                {
                    var iEx = ex.InnerException;
                    if (iEx != null && !string.IsNullOrEmpty(iEx.Message))
                    {
                        if (!string.IsNullOrEmpty(iEx.Source) && iEx.Source.IndexOf("See the inner exception for details") == -1) Message += "Source -> " + iEx.Source + "\r\n";

                        if (iEx.Message.IndexOf("See the inner exception for details") > -1)
                        {
                            var dEx = iEx.InnerException;
                            if (dEx != null && !string.IsNullOrEmpty(dEx.Message))
                            {
                                Message += dEx.Message + "\r\n";
                            }
                        }
                        else Message += iEx.Message + "\r\n";
                    }
                }

                return Message;
            }
            catch { return ""; }
        }

        public static string getValidationError(Exception ex)
        {
            try
            {
                var error = (DbEntityValidationException)ex;

                if (error != null)
                {
                    string messages = "";
                    foreach (var validation in error.EntityValidationErrors)
                    {
                        foreach (var item in validation.ValidationErrors)
                        {
                            messages += " --> " + item.PropertyName + " : " + item.ErrorMessage;
                        }
                    }

                    return messages;
                }
                return "";
            }
            catch { return ""; }
        }

        private static void saveRequest(HttpRequestMessage Request)
        {
            try
            {
                string Route = "";

                if (Request != null && Request.RequestUri != null && !string.IsNullOrEmpty(Request.RequestUri.AbsolutePath)) Route = Request.RequestUri.AbsolutePath;
                if (!string.IsNullOrEmpty(Route))
                {
                    APIRequestLog apiLog = new APIRequestLog();
                    apiLog.APIURL = Route;
                    apiLog.RequestOn = DateTime.Now;
                    if (Request.Headers.CacheControl != null)
                    apiLog.EmployeeCode = Request.Headers.CacheControl.ToString();

                    new UserService().saveApiLog(apiLog);
                }

                //using (MaintenanceEntities db = new MaintenanceEntities())
                //{
                //    if (Request != null && Request.RequestUri != null && !string.IsNullOrEmpty(Request.RequestUri.AbsolutePath)) Route = Request.RequestUri.AbsolutePath;

                //    if (!string.IsNullOrEmpty(Route))
                //    {
                //        Route = Route.Replace("/lplmis/api/", "");
                //        Route = Route.Replace("/api/", "");
                //    }

                //    if (!string.IsNullOrEmpty(Route))
                //    {
                //        var route = new SqlParameter("@Route", Route);
                //        db.Database.ExecuteSqlCommand("saveAPIRequest @Route", route);
                //    }

                //    return;
                //}
            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}