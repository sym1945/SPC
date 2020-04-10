namespace SPC.Core
{
    public class WordUIntDevice : WordDevice<uint>
    {
        public override uint Value
        {
            get => Functions.WordToUInt32(RawData);
            set => WriteValue(value);
        }

        public override void WriteValue(uint value)
        {
            WriteValue(Functions.UInt32ToWord(value));
        }
    }
}
