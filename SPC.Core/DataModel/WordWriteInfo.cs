namespace SPC.Core
{
    public class WordWriteInfo : PlcWriteInfo
    {
        public short Size { get; set; }
        public short[] Value;
    }
}
