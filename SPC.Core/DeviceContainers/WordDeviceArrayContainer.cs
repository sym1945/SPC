namespace SPC.Core
{
    public class WordDeviceArrayContainer : WordDeviceContainer
    {
        #region Constructor

        public WordDeviceArrayContainer(EDevice device, int startAddress, int count, string key, string readBlockKey)
        {
            Device = device;
            StartAddress = startAddress;
            Key = key;
            ReadBlockKey = readBlockKey;

            for (int i = 0; i < count; i++)
                Add(new WordShortDevice { Offset = i, Key = $"{Key}{i}" });
        }

        #endregion
    }
}