namespace SPC.Core
{
    public class WordReadWriteInfo : DeviceReadWriteInfo
    {
        public short Size { get; set; }
        public short[] Value;
    }
}
