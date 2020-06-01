using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPC.Core
{
    public static class Functions
    {
        private const string HEX_ALPHABET = "0123456789ABCDEF";

        public static bool ArrayEqual(short[] ar1, short[] ar2)
        {
            bool ret = true;
            if (ar1.Length != ar2.Length)
            {
                ret = false;
            }
            else
            {
                for (int i = 0; i < ar1.Length; i++)
                {
                    if (ar1[i] != ar2[i])
                    {
                        ret = false;
                        break;
                    }
                }
            }

            return ret;
        }
        public static bool ArrayCopyWithCompare<T>(T[] sourceArray, T[] destinationArray)
            where T : struct
        {
            bool isDifferent = false;

            if (sourceArray == null || destinationArray == null)
            {
            }
            else if (sourceArray.Length != destinationArray.Length)
            {
            }
            else
            {
                for (int i = 0; i < sourceArray.Length; i++)
                {
                    if (!sourceArray[i].Equals(destinationArray[i]))
                    {
                        isDifferent = true;
                        break;
                    }
                }
            }

            if (isDifferent)
            {
                Array.Copy(sourceArray, destinationArray, destinationArray.Length);
            }

            return isDifferent;
        }
        public static string ArrayToString(bool[] ar, string seperator = " ")
        {
            if (ar == null)
            {
                return "";
            }

            return string.Join(seperator, ar.Select(d => d ? 1 : 0));
        }
        public static string ArrayToString<T>(T[] ar, string seperator = " ")
            where T : struct
        {
            if (ar == null)
            {
                return "";
            }

            return string.Join(seperator, ar);
        }
        public static string ArrayToHEXString(short[] ar, char seperator)
        {
            StringBuilder sb = new StringBuilder(ar.Length * 5);

            foreach (ushort a in ar)
            {
                sb.Append(HEX_ALPHABET[(a >> 12)]);
                sb.Append(HEX_ALPHABET[(a >> 8) & 0xF]);
                sb.Append(HEX_ALPHABET[(a >> 4) & 0xF]);
                sb.Append(HEX_ALPHABET[(a & 0xF)]);
                sb.Append(seperator);
            }

            sb.Remove(sb.Length - 1, 1);

            return sb.ToString();
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
                return new short[0];
            if (_str.Length % 2 != 0)
                _str = _str.PadRight(_str.Length + 1);

            try
            {
                List<short> ret = new List<short>();
                byte[] byteArr = Encoding.ASCII.GetBytes(_str);

                for (int i = 0; i < byteArr.Length; i = i + 2)
                    ret.Add(BitConverter.ToInt16(byteArr, i));

                return ret.ToArray();
            }
            catch (Exception ex)
            {
                //Log.WriteLog(eLogType.Error, ex.ToString());
                return new short[0];
            }
        }
        public static short[] StringToWord_Nonswap(string _str)
        {
            if (_str == null || _str.Length <= 0)
                return new short[0];
            if (_str.Length % 2 != 0)
                _str = _str.PadRight(_str.Length + 1);

            try
            {
                List<short> ret = new List<short>();
                byte[] byteArr = Encoding.ASCII.GetBytes(_str);

                for (int i = 0; i < byteArr.Length; i = i + 2)
                {
                    Array.Reverse(byteArr, i, 2);
                    ret.Add(BitConverter.ToInt16(byteArr, i));
                }

                return ret.ToArray();
            }
            catch (Exception ex)
            {
                //Log.WriteLog(eLogType.Error, ex.ToString());
                return new short[0];
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
        public static short[] BitsToWord(IEnumerable<bool> bits)
        {
            List<short> ret = new List<short>();
            bool[] bitArr = bits.ToArray();
            int n = bitArr.Length % 16;

            if (n != 0)
                Array.Resize(ref bitArr, bitArr.Length + (16 - n));

            int pos = 0;
            var s = 0;
            for (int i = 0; i < bitArr.Length; i++, pos++)
            {
                if (bitArr[i])
                    s = s | (1 << pos);

                if (pos == 15)
                {
                    ret.Add((short)s);
                    s = 0;
                    pos = -1;
                }
            }

            return ret.ToArray();
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
        public static bool[] WordToBits(IEnumerable<short> words)
        {
            bool[] ret = words
                .SelectMany(s => Enumerable.Range(0, 16).Select(i => (s & (1 << i)) != 0))
                .ToArray();

            return ret;
        }

        public static short[] NibblesToWord(IEnumerable<byte> nibbles) => NibblesToWord(nibbles.ToArray());
        public static short[] NibblesToWord(byte[] nibbles)
        {
            int n = nibbles.Length % 4;
            if (n != 0)
                Array.Resize(ref nibbles, nibbles.Length + (4 - n));

            short[] ret = Enumerable.Range(0, nibbles.Length / 4)
                .Select(i => ToInt16FromNibble(nibbles, i * 4))
                .ToArray();

            return ret;
        }
        public static byte[] WordToNibbles(IEnumerable<short> words)
        {
            byte[] ret = words
                .SelectMany(s => Enumerable.Range(0, 4).Select(i => GetNibble(s, i * 4)))
                .ToArray();

            return ret;
        }


        public static short[] BytesToWord(IEnumerable<byte> bytes) => BytesToWord(bytes.ToArray());
        public static short[] BytesToWord(byte[] bytes)
        {
            if (bytes.Length % 2 != 0)
                Array.Resize(ref bytes, bytes.Length + 1);

            short[] ret = Enumerable.Range(0, bytes.Length / 2)
                .Select(i => BitConverter.ToInt16(bytes, i * 2))
                .ToArray();

            return ret;
        }
        public static byte[] WordToBytes(IEnumerable<short> words)
        {
            byte[] ret = words
                .SelectMany(s => BitConverter.GetBytes(s))
                .ToArray();

            return ret;
        }

        public static Int32 WordToInt32(IEnumerable<short> words)
        {
            if (words.Count() < 2)
            {
                return default(Int32);
            }

            return BitConverter.ToInt32(WordToBytes(words), 0);
        }
        public static UInt32 WordToUInt32(IEnumerable<short> words)
        {
            if (words.Count() < 2)
            {
                return default(UInt32);
            }

            return BitConverter.ToUInt32(WordToBytes(words), 0);
        }

        public static Int64 WordToInt64(IEnumerable<short> words)
        {
            if (words.Count() < 4)
            {
                return default(Int64);
            }

            return BitConverter.ToInt64(WordToBytes(words), 0);
        }
        public static UInt64 WordToUInt64(IEnumerable<short> words)
        {
            if (words.Count() < 4)
            {
                return default(UInt64);
            }

            return BitConverter.ToUInt64(WordToBytes(words), 0);
        }

        public static Single WordToSingle(IEnumerable<short> words)
        {
            if (words.Count() < 2)
            {
                return default(Single);
            }

            return BitConverter.ToSingle(WordToBytes(words), 0);
        }
        public static Double WordToDouble(IEnumerable<short> words)
        {
            if (words.Count() < 4)
            {
                return default(Double);
            }

            return BitConverter.ToDouble(WordToBytes(words), 0);
        }

        public static short[] Int32ToWord(int value)
        {
            return BytesToWord(BitConverter.GetBytes(value));
        }
        public static short[] UInt32ToWord(uint value)
        {
            return BytesToWord(BitConverter.GetBytes(value));
        }
        public static short[] Int64ToWord(long value)
        {
            return BytesToWord(BitConverter.GetBytes(value));
        }
        public static short[] UInt64ToWord(ulong value)
        {
            return BytesToWord(BitConverter.GetBytes(value));
        }
        public static short[] SingleToWord(float value)
        {
            return BytesToWord(BitConverter.GetBytes(value));
        }
        public static short[] DoubleToWord(double value)
        {
            return BytesToWord(BitConverter.GetBytes(value));
        }


        public static string DecToHexString(EDevice dev, ushort addr) => $"{dev}{addr:X4}";


        public static bool GetBit(short num, int index) => (num & (1 << index)) != 0;
        public static short SetBit(short num, int index, bool setValue)
        {
            if (setValue)
                return (num |= (short)(1 << index));
            else
                return (num &= (short)~(1 << index));
        }

        public static byte GetNibble(short num, int startIndex)
        {
            if (startIndex > 12)
                return 0;

            int mask = 0xF << startIndex;

            return (byte)((num & mask) >> startIndex);
        }
        public static short SetNibble(short num, int startIndex, byte setValue)
        {
            if (startIndex > 12)
                return num;

            for (int i = 0; i < 4; i++)
                num = SetBit(num, startIndex + i, GetBit(setValue, i));

            return num;
        }
        public static short ToInt16FromNibble(byte[] nibbles, int startindex)
        {
            short ret = 0;

            for (int i = startindex, j = 0; i < startindex + 4; i++, j += 4)
            {
                ret = SetNibble(ret, j, nibbles[i]);
            }

            return ret;
        }

        public static byte GetByte(short num, int startIndex)
        {
            if (startIndex > 8)
                return 0;

            int mask = 0xFF << startIndex;

            return (byte)((num & mask) >> startIndex);
        }
        public static short SetByte(short num, int startIndex, byte setValue)
        {
            if (startIndex > 8)
                return num;

            num &= (short)~(0xFF << startIndex);

            return (short)(num | (short)(setValue << startIndex));
        }

        public static short GetShort(int num, int startIndex)
        {
            if (startIndex > 32)
                return 0;

            int mask = 0xFFFF << startIndex;

            return (short)((num & mask) >> startIndex);
        }
        public static short GetShort(uint num, int startIndex)
        {
            if (startIndex > 32)
                return 0;

            int mask = 0xFFFF << startIndex;

            return (short)((num & mask) >> startIndex);
        }
        public static short SetShort(short num, int startIndex, byte setValue)
        {
            if (startIndex > 8)
                return num;

            num &= (short)~(0xFF << startIndex);

            return (short)(num | (short)(setValue << startIndex));
        }

        /// <summary>
        /// 10 -> 0x10
        /// </summary>
        /// <param name="dec"></param>
        /// <returns></returns>
        public static long ConvertDecToBCD(uint dec)
        {
            long ret = 0;
            int len = 0;
            uint divisor = 1;
            uint n = dec;
            long p = 0;

            do
            {
                len++;
                n /= 10;
            }
            while (n != 0);

            for (int i = len - 1; i >= 0; i--)
            {
                divisor = (uint)Math.Pow(10, i);
                n = dec / divisor;
                p = (long)Math.Pow(16, i);

                ret += (n & 0x1) * p;
                ret += (n & 0x1 << 1) * p;
                ret += (n & 0x1 << 2) * p;
                ret += (n & 0x1 << 3) * p;

                dec -= n * divisor;
            }

            return ret;
        }
        public static short ConvertDecToBCD(byte dec) => (short)ConvertDecToBCD((uint)dec);

        /// <summary>
        /// 0x10 -> 10
        /// </summary>
        /// <param name="bcd"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool TryConvertBCDToDec(long bcd, out uint result)
        {
            bool ret = true;
            int len = 0;
            uint p = 0;
            long n = bcd;
            long divisor = 1;
            byte tmp = 0;

            do
            {
                len++;
                n /= 16;
            }
            while (n != 0);

            result = 0;
            for (int i = len - 1; i >= 0; i--)
            {
                divisor = (long)Math.Pow(16, i);
                p = (uint)Math.Pow(10, i);
                n = bcd / divisor;

                tmp = 0;
                tmp += (n & (0x1 << 0)) != 0 ? (byte)1 : (byte)0;
                tmp += (n & (0x1 << 1)) != 0 ? (byte)2 : (byte)0;
                tmp += (n & (0x1 << 2)) != 0 ? (byte)4 : (byte)0;
                tmp += (n & (0x1 << 3)) != 0 ? (byte)8 : (byte)0;

                if (tmp > 0x9)
                {
                    result = 0;
                    ret = false;
                    break;
                }

                result += tmp * p;

                bcd -= n * divisor;
            }

            return ret;
        }
        public static bool TryConvertBCDToDec(short bcd, out byte result)
        {
            if (TryConvertBCDToDec(bcd, out uint d))
            {
                result = (byte)d;
                return true;
            }
            else
            {
                result = 0;
                return false;
            }
        }


        public static short ToInt16_Swap(byte[] value, int startIndex)
        {
            short ret = 0;

            if (value == null)
                throw new Exception("value is NULL");
            if (value.Length <= startIndex + 1)
                throw new Exception("startIndex Error");

            ret = SetShort(ret, 0, value[startIndex + 1]);
            ret = SetShort(ret, 8, value[startIndex]);

            return ret;
        }

    }
}
