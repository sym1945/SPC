namespace SPC.Core
{
    public abstract class PlcWriteInfo
    {
        public eDevice Device { get; set; }
        public short Address { get; set; }
    }
}
