namespace SPC.Core
{
    public class WordReadWriteInfo : DeviceReadWriteInfo
    {
        public int Size { get; set; }
        public short[] Value;
    }
}
