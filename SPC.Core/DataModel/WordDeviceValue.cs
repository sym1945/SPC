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

        public override string ToString()
        {
            return Functions.WordToString(true, _Buffer);
        }

        public int ToInt32()
        {
            return Functions.WordToInt32(_Buffer);
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


    }
}
