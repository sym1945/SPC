using System;
using System.Collections.Generic;

namespace SPC.Core
{
    public abstract class WordDevice : SpcDeviceBase
    {
        #region Protected Members

        protected int _Length = 0;
        protected WordDeviceValue _ReadBuffer = null;
        protected WordDeviceValue _WriteBuffer = null;

        #endregion


        #region Public Properties

        public int Length
        {
            get => _Length;
            set
            {
                if (_Length == value)
                    return;

                _Length = value;
                _ReadBuffer = new WordDeviceValue(_Length);
                _WriteBuffer = new WordDeviceValue(_Length);
            }
        }


        public short[] ReadBufferData
        {
            get => _ReadBuffer.RawData;
        }

        public short[] WriteBufferData
        {
            get => _WriteBuffer.RawData;
        }
        #endregion


        #region Constructor

        public WordDevice()
        {
            DeviceType = EDeviceType.Word;
        }

        #endregion


        #region Public Methods

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
                if (_ReadBuffer.RawData[i] != readInfo.Value[i])
                {
                    Array.Copy(readInfo.Value, 0, _ReadBuffer.RawData, 0, Length);
                    isChanged = true;
                    break;
                }
            }

            if (isChanged)
            {
                OnRawDataChanged();
            }
        }

        public void WriteValue(IEnumerable<short> value)
        {
            _WriteBuffer.SetValue(value);

            WriteValue();
        }

        #endregion


        #region Protected Methods

        protected void WriteValue()
        {
            OnWriteToPlc(new WordReadWriteInfo
            {
                Device = Device,
                Address = Address,
                Size = Length,
                Value = _WriteBuffer.RawData
            });
        }

        #endregion


        #region Internal Methods

        internal abstract void OnRawDataChanged();

        #endregion
    }


    public abstract class WordDevice<T> : WordDevice
    {
        #region Protected Members

        protected T _Value = default;

        #endregion


        #region Public Properties

        public abstract T Value { get; set; }

        #endregion


        #region Public Methods

        public abstract void WriteValue(T value);


        public override void Execute(object parameter = null)
        {
            try
            {
                var writeValue = (T)parameter;

                WriteValue(writeValue);
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
