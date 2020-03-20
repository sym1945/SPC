using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPC.Core
{
    public class PlcReadBlock
    {

        #region Public Properties
        public eDevice Device { get; set; } = eDevice.B;

        public short StartAddress { get; set; } = 0;

        public short Size { get; set; }

        public short[] Buffer;
        #endregion


        #region Constructor
        public PlcReadBlock(short size = 1024)
        {
            Size = size;
            Buffer = new short[Size];
        } 
        #endregion


    }
}
