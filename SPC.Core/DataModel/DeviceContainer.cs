using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPC.Core
{
    public class DeviceContainer<T> : DeviceContainerBase
        where T : DeviceBase
    {
        

        new public T this[string key]
        {
            get
            {
                return (T)base[key];
            }
        }


        public DeviceContainer()
        {
        }
        public DeviceContainer(eDevice device, eDeviceType deviceType, short startAddress, string desc = "") : this()
        {
            Device = device;
            DeviceType = deviceType;
            StartAddress = startAddress;
            Description = desc;
        }
    }
}
