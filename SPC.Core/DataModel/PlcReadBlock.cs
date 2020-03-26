using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPC.Core
{
    public class PlcReadBlock
    {
        #region Private Members
        private short _Size = 0;
        #endregion


        #region Public Properties
        public int Key { get; set; }

        public eDevice Device { get; set; } = eDevice.B;

        public short StartAddress { get; set; } = 0;

        public short Size
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
        public PlcReadBlock(short size = 1024)
        {
            Size = size;
        }
        #endregion


        public event Action<PlcReadBlock> BeforeRead;
        public event Action<PlcReadBlock> AfterRead;

        internal void OnBeforeRead()
        {
            BeforeRead?.Invoke(this);
        }

        internal void OnAfterRead()
        {
            AfterRead?.Invoke(this);
        }

    }
}
