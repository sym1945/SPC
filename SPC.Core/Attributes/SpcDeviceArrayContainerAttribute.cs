using System;

namespace SPC.Core
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SpcDeviceArrayContainerAttribute : SpcDeviceContainerAttribute
    {
        public int Count { get; private set; }

        public SpcDeviceArrayContainerAttribute(EDevice device, EDeviceType deviceType, int count, string readBlockKey)
            : base(device, deviceType, readBlockKey)
        {
            Count = count;
        }
    }

}