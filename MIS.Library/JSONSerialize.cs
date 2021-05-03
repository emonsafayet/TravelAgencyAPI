using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Script.Serialization;

namespace MIS.Library
{
    public class JSONSerialize
    {
        public static string ErrorMessage = "";
        public Exception Error = null;

        public List<T> ObjectToJSONText<T>(string JSONString)
        {
            try
            {
                string jsonString = DecodeBase64(JSONString);
                JavaScriptSerializer ser = new JavaScriptSerializer();
                List<T> logs = ser.Deserialize<List<T>>(jsonString);

                return ser.Deserialize<List<T>>(jsonString);
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public T JSONTextToObj<T>(string JSONString)
        {
            try
            {
                string jsonString = DecodeBase64(JSONString);
                JavaScriptSerializer ser = new JavaScriptSerializer();
                T logs = ser.Deserialize<T>(jsonString);

                return ser.Deserialize<T>(jsonString);
            }
            catch (Exception ex)
            {
                Error = ex;
                
                return (T)Convert.ChangeType(ex, typeof(T));
            }
        }

        public static string ObjectToJSONText(object obj)
        {
            try
            {
                ErrorMessage = "";
                return new JavaScriptSerializer().Serialize(obj);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return null;
            }
        }

        public static List<T> getJSON<T>(string JSONString)
        {
            ErrorMessage = "";
            string jsonString = DecodeBase64(JSONString);
            JavaScriptSerializer ser = new JavaScriptSerializer();
            List<T> logs = ser.Deserialize<List<T>>(jsonString);

            return ser.Deserialize<List<T>>(jsonString);
        }

        public static string EncodeBase64(string plainText)
        {
            ErrorMessage = "";
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string DecodeBase64(string EncodedString)
        {
            try
            {
                ErrorMessage = "";
                byte[] data = Convert.FromBase64String(EncodedString);
                return Encoding.UTF8.GetString(data);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return null;
            }
        }
    }
}