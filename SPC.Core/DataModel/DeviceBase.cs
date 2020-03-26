namespace SPC.Core
{
    public abstract class DeviceBase : IDevice
    {
        public string FullAddress => $"{Device.ToString()}{Address:X4}";

        public eDevice Device { get; set; }

        public eDeviceType DeviceType { get; set; }
        
        public string Key { get; set; }

        public short Address { get; set; }

        public short Offset { get; set; }

        public string Desc { get; set; }

    }
}
