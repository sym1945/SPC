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

        public void Update(short[] values)
        {

        }


    }
}
