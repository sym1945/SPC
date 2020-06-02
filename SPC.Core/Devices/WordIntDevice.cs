namespace SPC.Core
{
    public class WordIntDevice : WordDevice<int>, IValueDevice
    {
        public override int Value
        {
            get => Functions.WordToInt32(ReadBufferData);
            set => WriteValue(value);
        }

        public WordIntDevice()
        {
            Length = 2;
        }

        public override void WriteValue(int value)
        {
            WriteValue(Functions.Int32ToWord(value));
        }

    }
}
