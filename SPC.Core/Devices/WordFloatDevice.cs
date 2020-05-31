namespace SPC.Core
{
    public class WordFloatDevice : WordDevice<float>
    {
        public override float Value
        {
            get => Functions.WordToSingle(ReadBufferData);
            set => WriteValue(value);
        }

        public WordFloatDevice()
        {
            Length = 2;
        }

        public override void WriteValue(float value)
        {
            WriteValue(Functions.SingleToWord(value));
        }
    }
}
