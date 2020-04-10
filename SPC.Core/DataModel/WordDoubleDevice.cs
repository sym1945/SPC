namespace SPC.Core
{
    public class WordDoubleDevice : WordDevice<double>
    {
        public override double Value
        {
            get => Functions.WordToDouble(RawData);
            set => WriteValue(value);
        }

        public override void WriteValue(double value)
        {
            WriteValue(Functions.DoubleToWord(value));
        }
    }
}
