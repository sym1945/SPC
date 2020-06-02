namespace SPC.Core
{
    public class WordUShortDevice : WordDevice<ushort>, IValueDevice
    {
        public override ushort Value
        {
            get => (ushort)ReadBufferData[0];
            set => WriteValue(value);
        }

        public WordUShortDevice()
        {
            Length = 1;
        }

        public override void WriteValue(ushort value)
        {
            WriteValue(new short[1] { (short)value });
        }
    }
}
