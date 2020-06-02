using System;

namespace SPC.Core
{
    public class BitDeviceArrayContainer : BitDeviceContainer
    {
        #region Constructor

        public BitDeviceArrayContainer() : base()
        {
            var devArrayContainerAttribute = (SpcDeviceArrayContainerAttribute)Attribute.GetCustomAttribute(GetType(), typeof(SpcDeviceArrayContainerAttribute));
            if (devArrayContainerAttribute != null)
            {
                InitialDeviceArray(typeof(BitDevice), devArrayContainerAttribute);
            }
        }

        public BitDeviceArrayContainer(EDevice device, int count, string readBlockKey)
          : base(device, 0x0000, readBlockKey)
        {
            CreateDevices(count);
        }

        public BitDeviceArrayContainer(EDevice device, int count, string key, string readBlockKey)
            : base(device, key, readBlockKey)
        {
            CreateDevices(count);
        }

        public BitDeviceArrayContainer(EDevice device, int count, int startAddress, string readBlockKey)
            : base(device, startAddress, readBlockKey)
        {
            CreateDevices(count);
        }

        #endregion


        #region Private Methods

        private void CreateDevices(int count)
        {
            for (int i = 0; i < count; i++)
                Add(new BitDevice { Offset = i, Key = $"{Key}{i}" });
        }

        #endregion

    }
}