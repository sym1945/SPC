namespace SPC.Core
{
    public class WordUShortDevice : WordDevice<ushort>
    {
        public override ushort Value
        {
            get => (ushort)RawData[0];
            set => WriteValue(value);
        }

        public override void WriteValue(ushort value)
        {
            WriteValue(new short[1] { (short)value });
        }
    }
}
