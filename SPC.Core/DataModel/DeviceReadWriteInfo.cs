namespace SPC.Core
{
    public abstract class DeviceReadWriteInfo
    {
        public eDevice Device { get; set; }
        public short Address { get; set; }
    }
}
