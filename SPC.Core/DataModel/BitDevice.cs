using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SPC.Core
{
    public class BitDevice : DeviceBase
    {
        #region Private Members
        private ManualResetEventSlim _ResetEvent = null;
        private bool _OldValue = false;
        private bool _Value = false;
        #endregion


        #region Public Properties

        public bool Value
        {
            get => _Value;
            set
            {
                _OldValue = _Value;
                _Value = value;

                if (IsOnTrigger || IsOffTrigger)
                {
                    OnValueChanged();
                    OnPropertyChanged(nameof(Value));
                }
            }
        }

        public bool IsOnTrigger => !_OldValue && _Value;

        public bool IsOffTrigger => _OldValue && !_Value;
        #endregion


        #region Constructor
        public BitDevice()
        {
            _ResetEvent = new ManualResetEventSlim(false);
        }
        #endregion


        #region Public Method
        /// <summary>
        /// Bit 값 변경을 비동기로 대기한다.
        /// </summary>
        /// <param name="exceptedValue">원하는 변경값</param>
        /// <param name="waitMsec">변경 대기시간(msec)</param>
        /// <returns>true: 변경됨, false: 변경안됨</returns>
        public Task<bool> WaitBitAsync(bool exceptedValue, short waitMsec = 2000)
        {
            return Task.Run(() =>
            {
                return WaitBit(exceptedValue, waitMsec);
            });
        }

        /// <summary>
        /// Bit 값 변경을 대기한다.
        /// </summary>
        /// <param name="exceptedValue">원하는 변경값</param>
        /// <param name="waitMsec">변경 대기시간(msec)</param>
        /// <returns>true: 변경됨, false: 변경안됨</returns>
        public bool WaitBit(bool exceptedValue, short waitMsec = 2000)
        {
            if (_Value == exceptedValue)
                return true;

            _ResetEvent.Reset();
            _ResetEvent.Wait(waitMsec);

            return _Value == exceptedValue;
        }

        public void WriteValue(bool value)
        {
            OnWriteToPlc(new BitWriteInfo
            {
                Device = Device,
                Address = Address,
                Value = value
            });
        }

        public override void Execute(object parameter = null)
        {
            bool writeValue = !Value;
            if (parameter is bool)
                writeValue = (bool)parameter;

            WriteValue(writeValue);
        }
        #endregion


        #region Inner Method
        protected void OnValueChanged()
        {
            _ResetEvent.Set();
        }

        #endregion

    }
}
