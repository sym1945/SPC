namespace SPC.Core
{
    public class WordShortDevice : WordDevice<short>, IValueDevice
    {
        public override short Value
        {
            get => ReadBufferData[0];
            set => WriteValue(value);
        }

        public WordShortDevice()
        {
            Length = 1;
        }

        public override void WriteValue(short value)
        {
            WriteValue(new short[1] { value });
        }
    }
}
