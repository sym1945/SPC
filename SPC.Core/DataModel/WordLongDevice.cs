namespace SPC.Core
{
    public class WordLongDevice : WordDevice<long>
    {
        public override long Value
        {
            get => Functions.WordToInt64(RawData);
            set => WriteValue(value);
        }

        public override void WriteValue(long value)
        {
            WriteValue(Functions.Int64ToWord(value));
        }
    }
}
