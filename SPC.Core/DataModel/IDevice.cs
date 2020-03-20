using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPC.Core
{
    public interface IDevice
    {
        eDevice Device { get; set; }

        eDeviceType DeviceType { get; set; }

        short Address { get; set; }

        short Offset { get; set; }

        string Desc { get; set; }

    }
}
