using System;
using System.Collections.Generic;

namespace SPC.Core
{
    public class WordByteArrayDevice : WordArrayDevice<byte>
    {
        public override IEnumerable<byte> Value
        {
            get
            {
                foreach (short value in _ReadBuffer.RawData)
                {
                    for (int pos = 0; pos < 2; pos++)
                    {
                        yield return value.GetByte(pos);
                    }
                }
            }
            set => WriteValue(value);
        }

        public override byte GetValue(int index)
        {
            if (index >= _Length * 2)
                throw new ArgumentOutOfRangeException();

            var wordValue = _ReadBuffer.RawData[index / 2];

            return wordValue.GetByte(index % 2);
        }

        public override void SetValue(int index, byte value)
        {
            if (index >= _Length * 2)
                throw new ArgumentOutOfRangeException();

            var wordValueIndex = index / 2;
            var byteIndex = index % 2;

            Array.Copy(_ReadBuffer.RawData, _WriteBuffer.RawData, _Length);
            var newValue = _WriteBuffer.RawData[wordValueIndex].SetByte(byteIndex, value);
            _WriteBuffer.RawData[wordValueIndex] = newValue;

            WriteValue();
        }

        public override void WriteValue(IEnumerable<byte> value)
        {
            WriteValue(value.ToShort());
        }
    }
}