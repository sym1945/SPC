using System;
using System.Collections.Generic;

namespace SPC.Core
{
    public class WordBoolArrayDevice : WordArrayDevice<bool>
    {
        public override IEnumerable<bool> Value
        {
            get
            {
                foreach (short value in _ReadBuffer.RawData)
                {
                    for (int pos = 0; pos < 16; pos++)
                    {
                        yield return value.GetBit(pos);
                    }
                }
            }
            set => WriteValue(value);
        }

        public override bool GetValue(int index)
        {
            if (index >= _Length * 16)
                throw new ArgumentOutOfRangeException();

            var wordValue = _ReadBuffer.RawData[index / 16];

            return wordValue.GetBit(index % 16);
        }

        public override void SetValue(int index, bool value)
        {
            if (index >= _Length * 16)
                throw new ArgumentOutOfRangeException();

            var wordValueIndex = index / 16;
            var bitIndex = index % 16;

            Array.Copy(_ReadBuffer.RawData, _WriteBuffer.RawData, _Length);
            var newValue = _WriteBuffer.RawData[wordValueIndex].SetBit(bitIndex, value);
            _WriteBuffer.RawData[wordValueIndex] = newValue;

            WriteValue();
        }

        public override void WriteValue(IEnumerable<bool> value)
        {
            WriteValue(value.ToShort());
        }
    }
}