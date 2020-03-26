using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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


        public void SetValue(string key, bool value)
        {
            var dev = this[key];
            if (dev == null)
                return;

            dev.WriteValue(value);
        }


        public override void AfterRead(PlcReadBlock devBlock)
        {
            foreach (BitDevice device in this)
            {
                try
                {
                    int offset = device.Offset;
                    int i = offset / 16;
                    int o = offset % 16;

                    device.Value = ((devBlock.Buffer[i] >> o & 0b00000001) == 0b00000001);
                }
                catch
                {
                    // TODO: todo Something
                }
            }
        }

    }
}
