using System;

namespace SPC.Core
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SpcDeviceContainerAttribute : Attribute
    {
        public EDevice Device { get; private set; }
        public EDeviceType DeviceType { get; private set; }
        public int StartAddress { get; set; }
        public string Key { get; set; }
        public string ReadBlockKey { get; private set; }


        public SpcDeviceContainerAttribute(EDevice device, EDeviceType deviceType, string readBlockKey)
        {
            Device = device;
            DeviceType = deviceType;
            StartAddress = 0x0000;
            Key = null;
            ReadBlockKey = readBlockKey;
        }
    }

}