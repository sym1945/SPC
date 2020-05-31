namespace SPC.Core
{
    public class BitDeviceArrayContainer : BitDeviceContainer
    {
        #region Constructor

        public BitDeviceArrayContainer(EDevice device, int startAddress, int count, string key, string readBlockKey)
        {
            Device = device;
            StartAddress = startAddress;
            Key = key;
            ReadBlockKey = readBlockKey;

            for (int i = 0; i < count; i++)
                Add(new BitDevice { Offset = i, Key = $"{Key}{i}" });
        }

        #endregion
    }
}