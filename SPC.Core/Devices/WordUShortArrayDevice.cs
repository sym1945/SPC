using System;
using System.Collections.Generic;
using System.Linq;

namespace SPC.Core
{
    public class WordUShortArrayDevice : WordArrayDevice<ushort>
    {
        public override IEnumerable<ushort> Value
        {
            get => ReadBufferData.Cast<ushort>();
            set => WriteValue(value);
        }

        public override ushort GetValue(int index)
        {
            if (index >= _Length)
                throw new ArgumentOutOfRangeException();

            return (ushort)ReadBufferData[index];
        }

        public override void SetValue(int index, ushort value)
        {
            if (index >= _Length)
                throw new ArgumentOutOfRangeException();

            Array.Copy(_ReadBuffer.RawData, _WriteBuffer.RawData, _Length);
            _WriteBuffer.RawData[index] = (short)value;

            WriteValue();
        }

        public override void WriteValue(IEnumerable<ushort> value)
        {
            WriteValue(value.ToShort());
        }
    }
}