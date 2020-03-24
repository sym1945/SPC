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
            get => GetDevice(nameof(HeartBeat)).Value;
            set => SetValue(nameof(HeartBeat), value);
        }


    }
}
