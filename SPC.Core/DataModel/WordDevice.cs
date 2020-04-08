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
        private WordDeviceValue _ReadValue = null;
        private WordDeviceValue _WriteValue = null;
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
                _ReadValue = new WordDeviceValue(_Length);
                _WriteValue = new WordDeviceValue(_Length);
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
            get => _ReadValue.RawData;
        }


        public string ToAscii()
        {
            return _ReadValue.ToAscii();
        }

        public string ToDec()
        {
            return _ReadValue.ToDec();
        }

        public string ToHex()
        {
            return _ReadValue.ToHex();
        }



        public void WriteValue(string value)
        {
            WriteValue(Functions.StringToWord_Swap(value));
        }

        public void WriteValue(short value)
        {
            WriteValue(new short[1] { value });
        }

        public void WriteValue(ushort value)
        {
            WriteValue((short)value);
        }

        public void WriteValue(int value)
        {
            WriteValue(Functions.Int32ToWord(value));
        }

        public void WriteValue(uint value)
        {
            WriteValue(Functions.UInt32ToWord(value));
        }

        public void WriteValue(long value)
        {
            WriteValue(Functions.Int64ToWord(value));
        }

        public void WriteValue(ulong value)
        {
            WriteValue(Functions.UInt64ToWord(value));
        }

        public void WriteValue(float value)
        {
            WriteValue(Functions.SingleToWord(value));
        }

        public void WriteValue(double value)
        {
            WriteValue(Functions.DoubleToWord(value));
        }

        public void WriteValue(IEnumerable<short> value)
        {
            _WriteValue.SetValue(value);

            OnWriteToPlc(new WordReadWriteInfo
            {
                Device = Device,
                Address = Address,
                Size = Length,
                Value = _WriteValue.RawData
            });
        }

        public override void Execute(object parameter = null)
        {
            switch (parameter)
            {
                default: break;
                case string str: WriteValue(str); break;
                case short s: WriteValue(s); break;
                case ushort us: WriteValue(us); break;
                case int i: WriteValue(i); break;
                case uint ui: WriteValue(ui); break;
                case long l: WriteValue(l); break;
                case ulong ul: WriteValue(ul); break;
                case float f: WriteValue(f); break;
                case double d: WriteValue(d); break;
            }
        }

        public void ReadValue()
        {
            var readInfo = new WordReadWriteInfo
            {
                Device = Device,
                Address = Address,
                Size = Length,
                Value = new short[Length]
            };

            OnReadFromPlc(readInfo);

            var isChanged = false;
            for (int i = 0; i < Length; i++)
            {
                if (_ReadValue.RawData[i] != readInfo.Value[i])
                {
                    Array.Copy(readInfo.Value, 0, _ReadValue.RawData, 0, Length);
                    isChanged = true;
                    break;
                }
            }

            if (isChanged)
            {
                OnRawDataChanged();
            }
        }


        internal void OnRawDataChanged()
        {
            OnPropertyChanged(nameof(Value));
        }

    }
}
