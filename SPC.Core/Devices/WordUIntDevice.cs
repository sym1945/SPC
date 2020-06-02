namespace SPC.Core
{
    public class WordUIntDevice : WordDevice<uint>, IValueDevice
    {
        public override uint Value
        {
            get => Functions.WordToUInt32(ReadBufferData);
            set => WriteValue(value);
        }

        public WordUIntDevice()
        {
            Length = 2;
        }

        public override void WriteValue(uint value)
        {
            WriteValue(Functions.UInt32ToWord(value));
        }
    }
}
