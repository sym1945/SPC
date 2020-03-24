using System.Collections.Generic;

namespace SPC.Core
{
    public interface IDeviceContainer : ICollection<IDevice>
    {
        
        eDevice Device { get; set; }

        eDeviceType DeviceType { get; set; }

        short StartAddress { get; set; }

        string Description { get; set; }

        int ReadBlockKey { get; set; }
    }
}
