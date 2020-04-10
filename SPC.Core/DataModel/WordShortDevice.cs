namespace SPC.Core
{
    public class WordShortDevice : WordDevice<short>
    {
        public override short Value
        {
            get => RawData[0];
            set => WriteValue(value);
        }

        public override void WriteValue(short value)
        {
            WriteValue(new short[1] { value });
        }
    }
}
