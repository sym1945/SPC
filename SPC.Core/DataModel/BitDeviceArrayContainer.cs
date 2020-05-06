namespace SPC.Core
{
    public class BitDeviceArrayContainer : BitDeviceContainer
    {
        public BitDeviceArrayContainer(eDevice device, short startAddress, short length, string key, int readBlockKey) : base(device, startAddress, key, readBlockKey)
        {
            for (short i = 0; i < length; i++)
            {
                Add(new BitDevice { Offset = i, Key = $"{key}{i}" });
            }
        }
    }
}