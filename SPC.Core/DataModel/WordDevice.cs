using System;
using System.Collections.Generic;

namespace SPC.Core
{
    public abstract class WordDevice : DeviceBase
    {
        #region Protected Members

        protected short _Length = 0;
        protected WordDeviceValue _ReadValue = null;
        protected WordDeviceValue _WriteValue = null;

        #endregion


        #region Public Properties

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


        public short[] RawData
        {
            get => _ReadValue.RawData;
        }

        public short[] WriteData
        {
            get => _WriteValue.RawData;
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

        #endregion


        #region Protected Methods

        protected void WriteValue(IEnumerable<short> value)
        {
            _WriteValue.SetValue(value);

            WriteValue();
        }

        protected void WriteValue()
        {
            OnWriteToPlc(new WordReadWriteInfo
            {
                Device = Device,
                Address = Address,
                Size = Length,
                Value = _WriteValue.RawData
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

        protected T _Value = default(T);

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
