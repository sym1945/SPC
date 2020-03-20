using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SPC.Core
{
    public class BitDevice : IDevice
    {
        #region Private Members
        private ManualResetEventSlim _ManualResetEvent = null;
        private bool _OldValue = false;
        private bool _Value = false;
        #endregion


        #region Public Properties
        public eDevice Device { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public eDeviceType DeviceType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public short Address { get; set; }

        public short Offset { get; set; }

        public string Desc { get; set; }

        public bool Value
        {
            get => _Value;
            set
            {
                _OldValue = _Value;
                _Value = value;

                if (IsOnTrigger || IsOffTrigger)
                    OnValueChanged();
            }
        }

        public bool IsOnTrigger => !_OldValue && _Value;

        public bool IsOffTrigger => _OldValue && !_Value;
        #endregion


        #region Constructor
        public BitDevice()
        {
            _ManualResetEvent = new ManualResetEventSlim(false);
        }
        #endregion


        #region Public Method
        /// <summary>
        /// Bit 값 변경을 비동기로 대기한다.
        /// </summary>
        /// <param name="exceptedValue">원하는 변경값</param>
        /// <param name="waitMsec">변경 대기시간(msec)</param>
        /// <returns>true: 변경됨, false: 변경안됨</returns>
        public async Task<bool> WaitBitAsync(bool exceptedValue, short waitMsec = 2000)
        {
            return await Task.Run(() =>
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

            _ManualResetEvent.Reset();
            _ManualResetEvent.Wait(waitMsec);

            return _Value == exceptedValue;
        }
        #endregion


        #region Inner Method
        protected void OnValueChanged()
        {
            _ManualResetEvent.Set();
        } 
        #endregion

    }
}
