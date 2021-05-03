using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace MIS.Library
{
    public static class Library
    {
        private static JavaScriptSerializer ser = new JavaScriptSerializer();

        public static string EncodeString(string text)
        {
            return ser.Serialize(text);
        }

        public static string DecodeString(string jsonString)
        {
            return ser.Deserialize<string>(jsonString);
        }

        public static string EncodeSingleObject(object modelObject)
        {
            return ser.Serialize(modelObject);
        }

        public static T DecodeSingleObject<T>(string jsonString)
        {
            return ser.Deserialize<T>(jsonString);
        }

        public static string EncodeListObject(object modelObject)
        {
            return ser.Serialize(modelObject);
        }

        public static List<T> DecodeListObject<T>(string jsonString)
        {
            return ser.Deserialize<List<T>>(jsonString);
        }
    }
}