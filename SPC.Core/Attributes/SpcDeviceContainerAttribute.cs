using System;

namespace SPC.Core
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SpcDeviceContainerAttribute : Attribute
    {
        public EDevice Device { get; private set; }
        public EDeviceType DeviceType { get; private set; }
        public int StartAddress { get; private set; }
        public string Key { get; private set; }
        public string ReadBlockKey { get; private set; }

        public SpcDeviceContainerAttribute(EDevice device, EDeviceType deviceType, int startAddress, string key, string readBlockKey)
        {
            Device = device;
            DeviceType = deviceType;
            StartAddress = startAddress;
            Key = key;
            ReadBlockKey = readBlockKey;
        }
    }

}