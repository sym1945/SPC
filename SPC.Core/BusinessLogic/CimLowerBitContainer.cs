using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPC.Core
{
    public class CimLowerBitContainer : BitDeviceContainer
    {
        public bool HeartBeat
        {
            get => this[nameof(HeartBeat)].Value;
            set => this[nameof(HeartBeat)].Execute();
        }

        public BitDevice RecvAble
        {
            get => this[nameof(RecvAble)];
        }


    }
}
