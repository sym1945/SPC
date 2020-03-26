using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPC.Core
{
    public class WordDevice : DeviceBase
    {
        private short _Length = 0;
        private WordDeviceValue _Value = null;
        private eValueDisplayMode _ValueDisplayMode = eValueDisplayMode.DEC;

        public short Length
        {
            get => _Length;
            set
            {
                if (_Length < 0)
                    return;
                if (_Length == value)
                    return;

                _Length = value;
                _Value = new WordDeviceValue(_Length);
            }
        }

        public object Value
        {
            get
            {
                switch (_ValueDisplayMode)
                {
                    default:
                        return string.Empty;
                    case eValueDisplayMode.ASCII:
                        return ToAscii();
                    case eValueDisplayMode.DEC:
                        return ToDec();
                    case eValueDisplayMode.HEX:
                        return ToHex();
                }
            }
        }

        public eValueDisplayMode ValueDisplayMode
        {
            get => _ValueDisplayMode;
            set
            {
                if (_ValueDisplayMode == value)
                    return;
                _ValueDisplayMode = value;
                OnPropertyChanged(nameof(ValueDisplayMode));
                OnPropertyChanged(nameof(Value));
            }
        }

        public short[] RawData
        {
            get => _Value.RawData;
        }


        public string ToAscii()
        {
            return _Value.ToString();
        }

        public string ToDec()
        {
            return _Value.ToDec();
        }

        public string ToHex()
        {
            return _Value.ToHex();
        }



        //public void WriteValue(string value)
        //{
        //    WriteValue(Functions.StringToWord_Swap(value));
        //}

        //public void WriteValue(short value)
        //{
        //    WriteValue(new short[1] { value });
        //}

        //public void WriteValue(ushort value)
        //{
        //    WriteValue((short)value);
        //}

        //public void WriteValue(int value)
        //{
        //    WriteValue(Functions.Int32ToWord(value));
        //}

        //public void WriteValue(uint value)
        //{
        //    WriteValue(Functions.UInt32ToWord(value));
        //}

        //public void WriteValue(long value)
        //{
        //    WriteValue(Functions.Int64ToWord(value));
        //}

        //public void WriteValue(ulong value)
        //{
        //    WriteValue(Functions.UInt64ToWord(value));
        //}

        //public void WriteValue(float value)
        //{
        //    WriteValue(Functions.SingleToWord(value));
        //}

        //public void WriteValue(double value)
        //{
        //    WriteValue(Functions.DoubleToWord(value));
        //}

        //public void WriteValue(short[] value)
        //{
        //    //TODO: 우아하게 바꾸기
        //    var writeValue = new short[Length];
        //    int len = Length;
        //    if (value.Length < Length)
        //    {
        //        len = value.Length;
        //    }
        //    Array.Copy(value, writeValue, len);
        //    //


        //    Execute(new WordWriteInfo
        //    {
        //        Device = Device,
        //        Address = Address,
        //        Size = Length,
        //        Value = writeValue
        //    });
        //}

        public void WriteValue(object writeValue)
        {
            Execute(writeValue);
        }


        protected override PlcWriteInfo MakeWriteInfo(object value)
        {
            short[] writeValue = new short[Length];
            short[] convertValue = null;

            switch (value)
            {
                default:
                    break;
                case string s:
                    convertValue = Functions.StringToWord_Swap(s);
                    break;
            }

            //TODO: 우아하게 바꾸기
            if (convertValue != null)
            {
                int len = Length;
                if (convertValue.Length < len)
                {
                    len = convertValue.Length;
                }
                Array.Copy(convertValue, writeValue, len);
            }
            
            return new WordWriteInfo
            {
                Device = Device,
                Address = Address,
                Size = Length,
                Value = writeValue
            };
        }

        internal void OnRawDataChanged()
        {
            OnPropertyChanged(nameof(Value));
        }

    }
}
