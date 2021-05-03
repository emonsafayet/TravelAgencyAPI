using System;
using System.Collections.Generic;

namespace MIS.Library
{
    public class TimeConvert
    {
        public static string toAmPm(string time)
        {
            try
            {
                if (string.IsNullOrEmpty(time)) return "";

                string[] t = time.Split(':');
                int Hour = int.Parse(t[0]);

                if (Hour < 12) return Hour.ToString("D2") + t[1] + "AM";
                else if (Hour == 12) return Hour.ToString("D2") + t[1] + "PM";
                else return (Hour - 12).ToString("D2") + t[1] + "PM";
            }
            catch { return time; }
        }

        public static string getMonthName(int MonthNumber)
        {
            try
            {
                switch (MonthNumber)
                {
                    case 1:
                        return "January";

                    case 2:
                        return "February";

                    case 3:
                        return "March";

                    case 4:
                        return "April";

                    case 5:
                        return "May";

                    case 6:
                        return "June";

                    case 7:
                        return "July";

                    case 8:
                        return "August";

                    case 9:
                        return "September";

                    case 10:
                        return "October";

                    case 11:
                        return "November";

                    case 12:
                        return "December";

                    default:
                        return MonthNumber.ToString();
                }
            }
            catch { return MonthNumber.ToString(); }
        }

        public static int getCurrentMonthWorkingDayTotal()
        {
            try
            {
                int day = DateTime.Now.Day;

                if (day < 7) return day;
                else if (day < 10) return day = day - 1;
                else if (day < 16) return day = day - 2;
                else if (day < 21) return day = day - 3;
                else return day = day - 4;
            }
            catch { return 0; }
        }

        public static string getNullableDateValue(Nullable<DateTime> DateValue, string format)
        {
            return (DateValue == null ? "" : DateTime.Parse(DateValue.ToString()).ToString(format));
        }
    }
}