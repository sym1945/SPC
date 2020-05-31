using System;

namespace SPC.Core
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SpcDeviceArrayContainerAttribute : SpcDeviceContainerAttribute
    {
        public int Count { get; private set; }

        public SpcDeviceArrayContainerAttribute(EDevice device, EDeviceType deviceType, int startAddress, int count, string key, string readBlockKey)
            : base(device, deviceType, startAddress, key, readBlockKey)
        {
            Count = count;
        }
    }

}