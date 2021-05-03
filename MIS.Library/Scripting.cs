using System;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;

namespace MIS.Library
{
    public static class Scripting
    {
        public static string error = "";

        public static Boolean ClosingApplication = false;
        public static Boolean AbrotEverything = false;
        public static string colorCodes = "#C71585,#2201C6,#F2773F,#587F09,#00C4CD,#8B8B83,#FF2023,#BA3CE8,#5F2E80,#919B62,#0F7AF9";

        public static string getColorCode(int index)
        {
            try
            {
                return colorCodes.Split(',')[index];
            }
            catch { return "#252526"; }
        }

        public static int randomNumber(int min, int max)
        {
            try
            {
                Random random = new Random();
                return random.Next(min, max);
            }
            catch { return min; }
        }

        public static Boolean createDirectory(string path)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(path);
                if (di.Exists == true) return true;
                di.Create();
                return true;
            }
            catch { return false; }
        }

        public static Boolean deleteDirectory(string path)
        {
            try
            {
                Directory.Delete(path, true);
                return true;
            }
            catch { return false; }
        }

        /**************************** FILE READ WRITE **************************/

        public static Boolean writeFile(ref string SourceString, string FileName)
        {
            try
            {
                StreamWriter sw = new StreamWriter(FileName);
                sw.Write(SourceString);
                sw.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static Boolean readFile(ref string SourceString, string FileName)
        {
            try
            {
                StreamReader sr = new StreamReader(FileName);
                SourceString = sr.ReadToEnd();
                sr.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static Boolean WriteFile(ref string SourceString, string AbsolutePath, Boolean Append)
        {
            try
            {
                StreamWriter sw = new StreamWriter(AbsolutePath, Append);
                sw.Write(SourceString);
                sw.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static Boolean WriteFile(ref string SourceString, string Dir, string FileName, Boolean Append)
        {
            try
            {
                CheckAndCreateDir(Dir);
                StreamWriter sw = new StreamWriter(Dir + "\\" + FileName, Append);
                sw.Write(SourceString);
                sw.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static Boolean writeFile(string SourceString, string FileName)
        {
            try
            {
                StreamWriter sw = new StreamWriter(FileName);
                sw.Write(SourceString);
                sw.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static Boolean ReadFile(string AbsolutePath, ref string SourceString)
        {
            try
            {
                StreamReader sr = new StreamReader(AbsolutePath);
                SourceString = sr.ReadToEnd();
                sr.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static Boolean ReadFile(ref string SourceString, string Dir, string FileName)
        {
            try
            {
                StreamReader sr = new StreamReader(Dir + "\\" + FileName);
                SourceString = sr.ReadToEnd();
                sr.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static Boolean deleteFile(string fileLocation)
        {
            try
            {
                FileInfo fi = new FileInfo(fileLocation);
                fi.Delete();
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public static Boolean moveFile(string fileLocation)
        {
            try
            {
                FileInfo fi = new FileInfo(fileLocation);
                File.Move(fileLocation, Path.Combine(fi.Directory.FullName, fi.FullName + "old" + randomNumber(0, 999999) + fi.Extension));
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public static Boolean CheckAndCreateDir(string Dir)
        {
            try
            {
                string[] dr = Dir.Split('\\');
                string curDir = "";

                foreach (string st in dr)
                {
                    if (curDir.Length == 0) curDir = st;
                    else curDir = curDir + "\\" + st;
                    DirectoryInfo di = new DirectoryInfo(curDir);
                    if (di.Exists == false)
                    {
                        di.Create();
                    }
                }

                return true;
            }
            catch { return false; }
        }

        public static int valueInt(string Value)
        {
            try
            {
                if (string.IsNullOrEmpty(Value)) return 0;

                if (Value.IndexOf(".") == -1)
                {
                    try
                    {
                        return int.Parse(Value);
                    }
                    catch { }
                }

                int i, x = 0;
                string rtv = "";
                if (Value.IndexOf(".") > -1) Value = Value.Substring(0, Value.IndexOf("."));

                Value = Value.Replace("$", "");
                Value = Value.Replace(",", "");
                Value = Value.Trim();

                foreach (char c in Value)
                {
                    i = (int)c;
                    if (i == 46 || (i > 47 && i < 58))
                        rtv = rtv + c;
                    else break;

                    x++;
                }

                if (x == 0) return 0;
                else if (Value.Substring(0, 1).CompareTo("-") == 0) return -int.Parse(rtv);
                else return int.Parse(rtv);
            }
            catch { return 0; }
        }

        public static decimal valueDouble(string Value)
        {
            try
            {
                if (string.IsNullOrEmpty(Value)) return 0;
                try
                {
                    return decimal.Parse(Value);
                }
                catch { }

                int i;
                string rtv = "";

                Value = Value.Replace("$", "");
                Value = Value.Replace(",", "");
                Value = Value.Trim();

                foreach (char c in Value)
                {
                    i = (int)c;
                    if (i == 46 || (i > 47 && i < 58))
                        rtv = rtv + c;
                    else
                        break;
                }

                if (Value.Substring(0, 1).CompareTo("-") == 0) return -decimal.Parse(rtv);
                else return decimal.Parse(rtv);
            }
            catch { return 0; }
        }

        public static Boolean isWorkstationOnline(string IpAddress, int PingDuration)
        {
            try
            {
                using (Ping p = new Ping())
                {
                    if (p.Send(IpAddress, PingDuration).Status == IPStatus.Success) return true;
                    else return false;
                }
            }
            catch { return false; }
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

        public static string validateUserString(string UserString, int MaxLength = 25)
        {
            try
            {
                return UserString.Substring(0, MaxLength);
            }
            catch { return ""; }
        }

        public static string validateLoginString(string UserString, int MaxLength = 20)
        {
            try
            {
                string S = UserString;
                S = S.Replace("'", "");
                S = S.Replace(";", "");
                S = S.ToLower().Replace("or ", "");
                S = S.ToLower().Replace("drop ", "");
                S = S.Replace("1=1", "");
                S = S.Replace(" ", "");
                S = S.Trim();
                if (S.Length > MaxLength) return S.Substring(0, MaxLength);
                else return S;
            }
            catch { return ""; }
        }

        public static int getFullYearFromMonthYear(string MonthYear)
        {
            try
            {
                string[] st = MonthYear.Split(' ');
                if (st[1].Length == 2) return 2000 + valueInt(st[1]);
                else return valueInt(st[1]);
            }
            catch { return 0; }
        }

        public static int getMonthNumberFromMonthYear(string MonthYear, char Seperator = ' ')
        {
            try
            {
                string[] st = MonthYear.Split(Seperator);
                string Month = st[0].Trim().ToLower();
                if (Month.CompareTo("jan") == 0) return 1;
                else if (Month.CompareTo("feb") == 0) return 2;
                else if (Month.CompareTo("mar") == 0) return 3;
                else if (Month.CompareTo("apr") == 0) return 4;
                else if (Month.CompareTo("may") == 0) return 5;
                else if (Month.CompareTo("jun") == 0) return 6;
                else if (Month.CompareTo("jul") == 0) return 7;
                else if (Month.CompareTo("aug") == 0) return 8;
                else if (Month.CompareTo("sep") == 0) return 9;
                else if (Month.CompareTo("oct") == 0) return 10;
                else if (Month.CompareTo("nov") == 0) return 11;
                else if (Month.CompareTo("dec") == 0) return 12;
                else return 0;
            }
            catch { return 0; }
        }

        public static string RandomString(int length)
        {
            try
            {
                Random random = new Random();
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                return new string(Enumerable.Repeat(chars, length)
                  .Select(s => s[random.Next(s.Length)]).ToArray());
            }
            catch { return " "; }
        }

        public static int validateStringInput(int input1, int input2)
        {
            try
            {
                return (input1 * input2);
                //if (!string.IsNullOrEmpty(UserString)) return !string.IsNullOrEmpty(UserString.Trim());
                //return false;
            }
            catch { return 0; }
        }

        public static decimal getPercentQuantity(decimal Quantity, decimal Percent)
        {
            try
            {
                return Quantity / Percent;
            }
            catch { return 0; }
        }

        public static decimal getProductValue(Nullable<decimal> Quantity, Nullable<decimal> Price)
        {
            try
            {
                return Quantity.GetValueOrDefault() * Price.GetValueOrDefault();
            }
            catch { return 0; }
        }

        public static DateTime getTodaysDateOnly()
        {
            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
        }
    }
}