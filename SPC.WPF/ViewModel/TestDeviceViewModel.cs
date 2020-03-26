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
        public BitDeviceContainer Devices { get; set; }

        public TestDeviceViewModel(BitDeviceContainer bitDevContainer)
        {
            Devices = bitDevContainer;
        }

    }
}
