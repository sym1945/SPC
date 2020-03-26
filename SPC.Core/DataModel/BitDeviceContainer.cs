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
            DeviceType = eDeviceType.Bit;
        }
        public BitDeviceContainer(eDevice device, short startAddress, int readBlockKey, string desc = "") : this()
        {
            Device = device;
            StartAddress = startAddress;
            ReadBlockKey = readBlockKey;
            Description = desc;
        }


        public bool SetValue(string key, bool value)
        {
            var dev = GetDevice(key);
            dev.Value = value;

            return true;
        }


        public override void AfterRead(PlcReadBlock devBlock)
        {
            foreach (BitDevice device in this)
            {
                device.Value = (devBlock.Buffer[0] & 0b0000001) == 1;
            }
        }

    }
}
