using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPC.Core
{
    public class WordDeviceValue
    {
        private short[] _Buffer;

        public short[] RawData => _Buffer;

        public WordDeviceValue(short length)
        {
            _Buffer = new short[length];
        }


        public string ToDec()
        {
            var len = _Buffer.Length;
            var sb = new StringBuilder();

            for (int i = 0; i < len; i++)
            {
                sb.Append($"{_Buffer[i]} ");
            }

            if (sb.Length > 0)
            {
                sb.Remove(sb.Length - 1, 1);
            }

            return sb.ToString();
        }

        public string ToHex()
        {
            var len = _Buffer.Length;
            var sb = new StringBuilder();

            for (int i = 0; i < len; i++)
            {
                sb.Append($"{_Buffer[i]:X4} ");
            }

            if (sb.Length > 0)
            {
                sb.Remove(sb.Length - 1, 1);
            }

            return sb.ToString();
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
