using SPC.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPC.WPF
{
    public class TestDeviceViewModel
    {
        public BitDeviceContainer BitDevices { get; set; }

        public WordDeviceContainer WordDevices { get; set; }

        public TestDeviceViewModel(BitDeviceContainer bitDevContainer, WordDeviceContainer wordDeviceContainer)
        {
            BitDevices = bitDevContainer;
            WordDevices = wordDeviceContainer;
        }

    }
}
