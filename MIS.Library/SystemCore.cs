using System;
using System.Collections.Generic;
using System.Reflection;

namespace MIS.Library
{
    public class SystemCore
    {
        public static object extractObject<T>(object obj, string NameOfTheObject)
        {
            try
            {
                Type myType = obj.GetType();
                IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

                foreach (PropertyInfo prop in props)
                {
                    if (prop.Name == NameOfTheObject) return prop.GetValue(obj, null);
                }

                return null;
            }
            catch { return null; }
        }

        //public static List<T> extractObject<T>(object obj, Type type)
        //{
        //    try
        //    {
        //        Type myType = obj.GetType();
        //        IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

        //        foreach (PropertyInfo prop in props)
        //        {
        //            if (prop.Equals(type)) return prop.GetValue(obj, null);
        //        }

        //        return null;
        //    }
        //    catch { return null; }
        //}
    }
}