namespace MIS.Library
{
    public class TextConvert
    {
        public static string removeUnexpectedChars(string st)
        {
            try
            {
                return st.Replace("\r\n", "").Trim();
            }
            catch { return st; }
        }

        public static string getFirstWord(string st)
        {
            try
            {
                return st.Split(' ')[0];
            }
            catch { return st; }
        }

        public static string removeLastComma(string str)
        {
            try
            {
                if (string.IsNullOrEmpty(str) || str.IndexOf(',') == -1) return str;
                str = str.Trim();
                return str.Substring(0, str.Length - 1);
            }
            catch { return str; }
        }

        public static string ShortSubject(string subject)
        {
            try
            {
                return subject.Replace("for", "").Replace("  ", " ");
            }
            catch { return subject; }
        }
    }
}