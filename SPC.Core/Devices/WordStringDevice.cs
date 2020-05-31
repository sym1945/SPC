namespace SPC.Core
{
    public class WordStringDevice : WordDevice<string>
    {
        public override string Value
        {
            get => ReadBufferData.ToAscii();
            set => WriteValue(value);
        }

        public override void WriteValue(string value)
        {
            WriteValue(Functions.StringToWord_Swap(value));
        }
    }

}
