namespace SPC.Core
{
    public class WordIntDevice : WordDevice<int>
    {
        public override int Value
        {
            get => Functions.WordToInt32(RawData);
            set => WriteValue(value);
        }

        public override void WriteValue(int value)
        {
            WriteValue(Functions.Int32ToWord(value));
        }
    }
}
