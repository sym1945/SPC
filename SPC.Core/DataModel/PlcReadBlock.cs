using System;

namespace SPC.Core
{
    public class DeviceReadBlock
    {
        #region Private Members

        private int _Size = 0;

        #endregion


        #region Public Properties

        public string Key { get; set; }

        public EDevice Device { get; set; } = EDevice.B;

        public int StartAddress { get; set; } = 0;

        public int Size
        {
            get => _Size;
            set
            {
                if (_Size == value)
                    return;

                _Size = value;
                Buffer = new short[_Size];
            }
        }

        public short[] Buffer = null;

        #endregion


        #region Constructor

        public DeviceReadBlock(int size = 1024)
        {
            Size = size;
        }

        #endregion


        #region Events

        public event Action<DeviceReadBlock> BeforeRead;
        public event Action<DeviceReadBlock> AfterRead;

        internal void OnBeforeRead()
        {
            BeforeRead?.Invoke(this);
        }

        internal void OnAfterRead()
        {
            AfterRead?.Invoke(this);
        } 

        #endregion

    }
}
