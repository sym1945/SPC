namespace SPC.Core
{
    public abstract class DeviceReadWriteInfo
    {
        public EDevice Device { get; set; }
        public int Address { get; set; }
    }
}
