using SPC.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPC.WPF
{
    public class DeviceListViewModel
    {
        public BitDeviceContainer RecvBitDevices { get; set; }

        public BitDeviceContainer SendBitDevices { get; set; }

        public WordDeviceContainer WordDevices { get; set; }

        public DeviceListViewModel(DeviceManager manager)
        {
            RecvBitDevices = manager.GetDeviceContainer<BitDeviceContainer>(1);
            SendBitDevices = manager.GetDeviceContainer<BitDeviceContainer>(2);
            WordDevices = manager.GetDeviceContainer<WordDeviceContainer>(3);
        }

    }
}
