using System;
using System.Collections.Generic;
using System.Linq;

namespace SPC.Core
{
    public class WordDeviceValue
    {
        private readonly short[] _Buffer;

        public short[] RawData => _Buffer;

        public WordDeviceValue(int length)
        {
            _Buffer = new short[length];
        }


        public string ToAscii()
        {
            return _Buffer.ToAscii();
        }

        public string ToDec()
        {
            return string.Join(" ", _Buffer);
        }

        public string ToHex()
        {
            return string.Join(" ", _Buffer.Select(d=>d.ToString("X4")));
        }

        public void SetValue(IEnumerable<short> values)
        {
            Clear();

            int i = 0;
            var len = _Buffer.Length;
            foreach (short value in values)
            {
                _Buffer[i++] = value;
                if (i >= len)
                    break;
            }
        }

        public void Clear()
        {
            Array.Clear(_Buffer, 0, _Buffer.Length);
        }

    }
}
