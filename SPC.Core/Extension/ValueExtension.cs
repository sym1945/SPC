using System;
using System.Collections.Generic;
using System.Linq;

namespace SPC.Core
{
    public static class ValueExtension
    {
        public static bool GetBit(this short value, int index)
        {
            if (index < 0 || index > 15)
                throw new ArgumentOutOfRangeException();

            return (1 == ((value >> index) & 1));
        }

        public static short SetBit(this short value, int index, bool bitValue)
        {
            if (index < 0 || index > 15)
                throw new ArgumentOutOfRangeException();

            if (bitValue)
                value |= (short)(1 << index);
            else
                value &= (short)~(1 << index);

            return value;
        }

        public static byte GetByte(this short value, int index)
        {
            if (index < 0 || index > 1)
                throw new ArgumentOutOfRangeException();

            int shiftLength = ((index == 1) ? 8 : 0);

            return (byte)((value >> shiftLength) & 0xFF);
        }

        public static short SetByte(this short value, int index, byte byteValue)
        {
            if (index < 0 || index > 1)
                throw new ArgumentOutOfRangeException();

            int shiftLength = ((index == 1) ? 8 : 0);

            value &= (short)~(0xFF << shiftLength);

            value |= (short)(byteValue << shiftLength);

            return value;
        }


        public static IEnumerable<short> ToShort(this IEnumerable<bool> value)
        {
            int pos = -1;
            short shortValue = 0;
            
            foreach (var bit in value)
            {
                shortValue = shortValue.SetBit(++pos, bit);
                if (pos == 15)
                {
                    yield return shortValue;
                    pos = -1;
                    shortValue = 0;
                }
            }

            if (pos > -1 && pos < 16)
                yield return shortValue;
        }

        public static IEnumerable<short> ToShort(this IEnumerable<byte> value)
        {
            int pos = -1;
            short shortValue = 0;

            foreach (var byteValue in value)
            {
                shortValue = shortValue.SetByte(++pos, byteValue);
                if (pos == 1)
                {
                    yield return shortValue;
                    pos = -1;
                    shortValue = 0;
                }
            }

            if (pos > -1 && pos < 2)
                yield return shortValue;
        }

        public static IEnumerable<short> ToShort(this IEnumerable<ushort> value)
        {
            return value.Select(d => (short)d);
        }

    }
}
