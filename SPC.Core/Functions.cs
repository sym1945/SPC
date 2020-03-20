using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPC.Core
{
    public static class Functions
    {
        public static ushort[] BitMask = new ushort[16] { 0x0001, 0x0002, 0x0004, 0x0008, 
                                                                  0x0010, 0x0020, 0x0040, 0x0080, 
                                                                  0x0100, 0x0200, 0x0400, 0x0800,
                                                                  0x1000, 0x2000, 0x4000, 0x8000 };

        public static bool TryBitConvert(short rawValue, ref bool[] result)
        {
            if (result == null)
            {
                return false;
            }

            if (result.Length != BitMask.Length)
            {
                return false;
            }

            for (int i = 0; i < BitMask.Length; i++)
            {
                result[i] = ((rawValue & BitMask[i]) == BitMask[i]);
            }

            return true;
        }




        #region Inner Functions
        static string str2hex(string strData)
        {
            StringBuilder sb = new StringBuilder();
            byte[] arr_byteStr = Encoding.Default.GetBytes(strData);

            foreach (byte byteStr in arr_byteStr)
                sb.Append(string.Format("{0:X2}", byteStr));

            return sb.ToString();
        }
        #endregion



        public static short[] StringToWord(bool _bswap, string _str)
        {
            try
            {
                return (_bswap) ? StringToWord_Swap(_str) : StringToWord_Nonswap(_str);
            }
            catch (Exception ex)
            {
                //Log.WriteLog(eLogType.Error, ex.ToString());
                return null;
            }
        }

        public static short[] StringToWord_Swap(string _str)
        {
            if (_str == null || _str.Length <= 0)
                return null;

            try
            {
                StringBuilder source = new StringBuilder(_str);
                StringBuilder temp = new StringBuilder();

                if (_str.Length % 2 == 1)
                    source.Append(' ');

                List<short> ret = new List<short>();

                for (int i = 0; i < source.Length; i++)
                {
                    if (i % 2 == 0)
                        temp.Append(source[i]);
                    else
                    {
                        temp.Insert(0, source[i]);
                        ret.Add((short)Convert.ToInt32(str2hex(temp.ToString()), 16));
                        temp.Clear();
                    }
                }

                return ret.ToArray();
            }
            catch (Exception ex)
            {
                //Log.WriteLog(eLogType.Error, ex.ToString());
                return null;
            }
        }

        public static short[] StringToWord_Nonswap(string _str)
        {
            if (_str == null || _str.Length <= 0)
                return null;

            try
            {
                StringBuilder source = new StringBuilder(_str);
                StringBuilder temp = new StringBuilder();

                if (_str.Length % 2 == 1)
                    source.Append(' ');

                List<short> ret = new List<short>();

                for (int i = 0; i < source.Length; i++)
                {
                    if (i % 2 == 0)
                        temp.Append(source[i]);
                    else
                    {
                        temp.Append(source[i]);
                        ret.Add((short)Convert.ToInt32(str2hex(temp.ToString()), 16));
                        temp.Clear();
                    }
                }

                return ret.ToArray();
            }
            catch (Exception ex)
            {
                //Log.WriteLog(eLogType.Error, ex.ToString());
                return null;
            }
        }





        public static string WordToString(bool _bswap, params short[] words)
        {
            try
            {
                return (_bswap) ? WordToString_Swap(words) : WordToString_Nonswap(words);
            }
            catch (Exception ex)
            {
                //Log.WriteLog(eLogType.Error, ex.ToString());
                return "";
            }
        }

        public static string WordToString_Swap(params short[] words)
        {
            try
            {
                StringBuilder ret = new StringBuilder();

                for (int i = 0; i < words.Length; i++)
                {
                    char high = Convert.ToChar((words[i] >> 8) & 0xFF);
                    char low = Convert.ToChar(words[i] & 0xFF);

                    ret.Append(low);
                    ret.Append(high);
                }

                return ret.ToString();
            }
            catch (Exception ex)
            {
                //Log.WriteLog(eLogType.Error, ex.ToString());
                return "";
            }
        }

        public static string WordToString_Swap(IEnumerable<short> words)
        {
            try
            {
                StringBuilder ret = new StringBuilder();

                foreach (short word in words)
                {
                    char high = Convert.ToChar((word >> 8) & 0xFF);
                    char low = Convert.ToChar(word & 0xFF);

                    ret.Append(low);
                    ret.Append(high);
                }
                return ret.ToString().Replace('\0', ' ').TrimEnd(new char[] { ' ' });
            }
            catch (Exception ex)
            {
                //Log.WriteLog(eLogType.Error, ex.ToString());
                return "";
            }
        }

        public static string WordToString_Nonswap(params short[] words)
        {
            try
            {
                StringBuilder ret = new StringBuilder();

                for (int i = 0; i < words.Length; i++)
                {
                    char high = Convert.ToChar((words[i] >> 8) & 0xFF);
                    char low = Convert.ToChar(words[i] & 0xFF);

                    ret.Append(high);
                    ret.Append(low);
                }

                return ret.ToString();
            }
            catch (Exception ex)
            {
                //Log.WriteLog(eLogType.Error, ex.ToString());
                return "";
            }
        }

        public static string WordToString_Nonswap(IEnumerable<short> words)
        {
            try
            {
                StringBuilder ret = new StringBuilder();

                foreach (short word in words)
                {
                    char high = Convert.ToChar((word >> 8) & 0xFF);
                    char low = Convert.ToChar(word & 0xFF);

                    ret.Append(high);
                    ret.Append(low);
                }

                return ret.ToString();
            }
            catch (Exception ex)
            {
                //Log.WriteLog(eLogType.Error, ex.ToString());
                return "";
            }
        }

        public static string WordToBitsString(short _word)
        {
            try
            {
                string ret = Convert.ToString(_word, 2).PadLeft(16, '0');
                return ret;
            }
            catch (Exception ex)
            {
                //Log.WriteLog(eLogType.Error, ex.ToString());
                return null;
            }
        }
        public static bool[] WordToBits(short _word)
        {
            bool[] ret = new bool[16];
            
            try
            {
                char[] chars = Convert.ToString(_word, 2).PadLeft(16, '0').Reverse().ToArray();

                int cnt = chars.Count();
                for (int i = 0; i < cnt; i++)
                    ret[i] = (chars[i] != '0');

                chars = null;

                return ret;
            }
            catch (Exception ex)
            {
                //Log.WriteLog(eLogType.Error, ex.ToString());
                return null;
            }
            finally
            {
                ret = null;
            }
        }
        public static short BitToWord(bool[] bits)
        {
            short ret = -1;

            StringBuilder sb = new StringBuilder();

            foreach (bool b in bits)
                sb.Insert(0, b ? "1" : "0");

            ret = Convert.ToInt16(sb.ToString(), 2);

            return ret;
        }

        public static string DecToHexString(eDevice dev, ushort addr)
        {
            return string.Format("{0}{1:X4}", dev, addr);
        }
    }
}
