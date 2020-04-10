namespace SPC.Core
{
    public class WordStringDevice : WordDevice<string>
    {
        public override string Value
        {
            get => Functions.WordToString_Swap(RawData);
            set => WriteValue(value);
        }

        public override void WriteValue(string value)
        {
            WriteValue(Functions.StringToWord_Swap(value));
        }
    }

}
