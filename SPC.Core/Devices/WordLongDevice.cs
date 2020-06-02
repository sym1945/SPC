namespace SPC.Core
{
    public class WordLongDevice : WordDevice<long>, IValueDevice
    {
        public override long Value
        {
            get => Functions.WordToInt64(ReadBufferData);
            set => WriteValue(value);
        }

        public WordLongDevice()
        {
            Length = 4;
        }

        public override void WriteValue(long value)
        {
            WriteValue(Functions.Int64ToWord(value));
        }
    }
}
