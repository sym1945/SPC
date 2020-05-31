namespace SPC.Core
{
    public class WordULongDevice : WordDevice<ulong>
    {
        public override ulong Value
        {
            get => Functions.WordToUInt64(ReadBufferData);
            set => WriteValue(value);
        }

        public WordULongDevice()
        {
            Length = 4;
        }

        public override void WriteValue(ulong value)
        {
            WriteValue(Functions.UInt64ToWord(value));
        }
    }
}
