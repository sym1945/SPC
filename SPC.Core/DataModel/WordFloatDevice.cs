namespace SPC.Core
{
    public class WordFloatDevice : WordDevice<float>
    {
        public override float Value
        {
            get => Functions.WordToSingle(RawData);
            set => WriteValue(value);
        }

        public override void WriteValue(float value)
        {
            WriteValue(Functions.SingleToWord(value));
        }
    }
}
