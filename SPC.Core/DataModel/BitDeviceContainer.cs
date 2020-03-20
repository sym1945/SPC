using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPC.Core
{
    public class BitDeviceContainer : DeviceContainer<BitDevice>
    {
        public BitDeviceContainer()
        {
            
        }

        public bool SetValue(string key, bool value)
        {
            var dev = GetDevice(key);
            dev.Value = value;

            return true;
        }

    }
}
