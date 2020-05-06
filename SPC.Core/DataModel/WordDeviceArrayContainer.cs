namespace SPC.Core
{
    public class WordDeviceArrayContainer : WordDeviceContainer
    {
        public WordDeviceArrayContainer(eDevice device, short startAddress, short length, string key, int readBlockKey) : base(device, startAddress, key, readBlockKey)
        {
            for (short i = 0; i < length; i++)
            {
                Add(new WordShortDevice { Offset = i, Length = 1, Key = $"{key}{i}" });
            }
        }
    }
}