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
        public BitDeviceContainer(eDevice device, short startAddress, string desc = "") : this()
        {
            Device = device;
            StartAddress = startAddress;
            Description = desc;
        }


        public bool SetValue(string key, bool value)
        {
            var dev = GetDevice(key);
            dev.Value = value;

            return true;
        }

        public void UpdateDeviceValue(short[] rawData)
        {
            foreach (BitDevice device in this)
            {
                device.Value = (rawData[0] & 0b0000001) == 1;
            }
        }

    }
}
