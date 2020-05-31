using System;
using System.Threading;
using System.Threading.Tasks;

namespace SPC.Core
{
    public class BitDevice : SpcDeviceBase
    {
        #region Private Members
        private readonly ManualResetEventSlim _ResetEvent = null;
        private bool _OldValue = false;
        private bool _Value = false;
        #endregion


        #region Public Properties

        /// <summary>
        /// 디바이스의 내부 메모리 값.
        /// Setter로 메모리 값을 변경할 수 없다. (WriteValue 메서드 함수와 동일한 역할)
        /// </summary>
        public bool Value
        {
            get => _Value;
            set => WriteValue(value);
        }

        /// <summary>
        /// 값이 OFF → ON으로 변경된 경우 True
        /// </summary>
        public bool IsOnTrigger => !_OldValue && _Value;

        /// <summary>
        /// 값이 ON → OFF으로 변경된 경우 True
        /// </summary>
        public bool IsOffTrigger => _OldValue && !_Value;

        /// <summary>
        /// 현재 값이 이전 값과 다를 경우 True
        /// </summary>
        public bool IsChanged => _OldValue != _Value;
        #endregion


        #region Constructor

        /// <summary>
        /// BitDevice 기본 생성자
        /// </summary>
        public BitDevice()
        {
            DeviceType = EDeviceType.Bit;
            _ResetEvent = new ManualResetEventSlim(false);
        }

        #endregion


        #region Public Method

        /// <summary>
        /// Bit 값 변경을 대기한다.
        /// </summary>
        /// <param name="exceptedValue">원하는 변경값</param>
        /// <param name="waitMsec">변경 대기시간(msec)</param>
        /// <returns>true: 변경됨, false: 변경안됨</returns>
        public async ValueTask<bool> WaitBitAsync(bool exceptedValue, short waitMsec = 2000)
        {
            if (_Value == exceptedValue)
                return true;

            await Task.Run(() =>
            {
                _ResetEvent.Reset();
                _ResetEvent.Wait(waitMsec);
            });

            return (_Value == exceptedValue);
        }

        /// <summary>
        /// Plc로 Value 쓰기를 시도한다.
        /// </summary>
        /// <param name="value">쓸 값</param>
        public void WriteValue(bool value)
        {
            OnWriteToPlc(new BitReadWriteInfo
            {
                Device = Device,
                Address = Address,
                Value = value
            });
        }

        /// <summary>
        /// ICommand의 Execute Method 구현
        /// </summary>
        /// <param name="parameter">View에서 넘어오는 값</param>
        public override void Execute(object parameter = null)
        {
            bool writeValue = !_Value;
            if (parameter is bool)
                writeValue = (bool)parameter;

            WriteValue(writeValue);
        }

        /// <summary>
        /// Device의 내부 메모리 값을 변경한다.
        /// </summary>
        /// <param name="newValue">변경할 값</param>
        public void UpdateValue(bool newValue)
        {
            _OldValue = _Value;
            _Value = newValue;

            if (IsChanged)
            {
                _ResetEvent.Set();
                OnValueChanged();
                OnPropertyChanged(nameof(Value));
                //TODO: Write Log
                Console.WriteLine($"BIT CHANGE: {FullAddress}={(_Value ? 1 : 0)}");
            }
        }

        #endregion

    }
}
