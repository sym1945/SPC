using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPC.Core
{
    public class DeviceContainer<T> : DeviceContainerBase
        where T : IDevice
    {
        protected IDevice this[string key]
        {
            get => default(IDevice);
        }

        public T GetDevice(string key)
        {
            return (T)this[key];
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
