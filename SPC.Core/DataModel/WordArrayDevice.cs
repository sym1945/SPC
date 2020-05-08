using System;
using System.Collections.Generic;
using System.Linq;

namespace SPC.Core
{
    public class WordUShortArrayDevice : WordArrayDevice<ushort>
    {
        public override IEnumerable<ushort> Value
        {
            get => RawData.Cast<ushort>();
            set => WriteValue(value);
        }


        public override ushort GetValue(int index)
        {
            if (index >= _Length)
                throw new ArgumentOutOfRangeException();

            return (ushort)RawData[index];
        }

        public override void SetValue(int index, ushort value)
        {
            if (index >= _Length)
                throw new ArgumentOutOfRangeException();

            Array.Copy(_ReadValue.RawData, _WriteValue.RawData, 0);
            _WriteValue.RawData[index] = (short)value;

            WriteValue();
        }

        public override void WriteValue(IEnumerable<ushort> value)
        {
            WriteValue(value.ToShort());
        }
    }


    public class WordByteArrayDevice : WordArrayDevice<byte>
    {
        public override IEnumerable<byte> Value
        {
            get
            {
                foreach (short value in _ReadValue.RawData)
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

            var wordValue = _ReadValue.RawData[index / 2];

            return wordValue.GetByte(index % 2);
        }

        public override void SetValue(int index, byte value)
        {
            if (index >= _Length * 2)
                throw new ArgumentOutOfRangeException();

            var wordValueIndex = index / 2;
            var byteIndex = index % 2;

            Array.Copy(_ReadValue.RawData, _WriteValue.RawData, 0);
            _WriteValue.RawData[wordValueIndex].SetByte(byteIndex, value);

            WriteValue();
        }

        public override void WriteValue(IEnumerable<byte> value)
        {
            WriteValue(value.ToShort());
        }
    }


    public class WordBoolArrayDevice : WordArrayDevice<bool>
    {
        public override IEnumerable<bool> Value
        {
            get
            {
                foreach (short value in _ReadValue.RawData)
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

            var wordValue = _ReadValue.RawData[index / 16];

            return wordValue.GetBit(index % 16);
        }

        public override void SetValue(int index, bool value)
        {
            if (index >= _Length * 16)
                throw new ArgumentOutOfRangeException();

            var wordValueIndex = index / 16;
            var bitIndex = index % 16;

            Array.Copy(_ReadValue.RawData, _WriteValue.RawData, 0);
            _WriteValue.RawData[wordValueIndex].SetBit(bitIndex, value);

            WriteValue();
        }

        public override void WriteValue(IEnumerable<bool> value)
        {
            WriteValue(value.ToShort());
        }
    }


    public abstract class WordArrayDevice<T> : WordDevice
        where T : struct
    {
        #region Public Properties

        public abstract IEnumerable<T> Value { get; set; }

        #endregion


        #region Public Methods

        public abstract T GetValue(int index);

        public abstract void SetValue(int index, T value);

        public abstract void WriteValue(IEnumerable<T> value);

        public override void Execute(object parameter = null)
        {
            try
            {

            }
            catch
            {
                //TODO: Write Log
            }
        }

        #endregion


        #region Internal Methods

        internal override void OnRawDataChanged()
        {
            OnPropertyChanged(nameof(Value));
        }

        #endregion
    }
}
