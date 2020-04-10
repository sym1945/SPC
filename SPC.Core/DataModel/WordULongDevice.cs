namespace SPC.Core
{
    public class WordULongDevice : WordDevice<ulong>
    {
        public override ulong Value
        {
            get => Functions.WordToUInt64(RawData);
            set => WriteValue(value);
        }

        public override void WriteValue(ulong value)
        {
            WriteValue(Functions.UInt64ToWord(value));
        }
    }
}
