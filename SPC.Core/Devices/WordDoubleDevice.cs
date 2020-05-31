namespace SPC.Core
{
    public class WordDoubleDevice : WordDevice<double>
    {
        public override double Value
        {
            get => Functions.WordToDouble(ReadBufferData);
            set => WriteValue(value);
        }

        public WordDoubleDevice()
        {
            Length = 4;
        }

        public override void WriteValue(double value)
        {
            WriteValue(Functions.DoubleToWord(value));
        }
    }
}
