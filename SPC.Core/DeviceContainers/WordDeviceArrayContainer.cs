using System;

namespace SPC.Core
{
    public class WordDeviceArrayContainer<TDevice> : WordDeviceContainer
        where TDevice: WordDevice, IValueDevice, new()
    {
        #region Constructor

        public WordDeviceArrayContainer() : base()
        {
            var devArrayContainerAttribute = (SpcDeviceArrayContainerAttribute)Attribute.GetCustomAttribute(GetType(), typeof(SpcDeviceArrayContainerAttribute));
            if (devArrayContainerAttribute != null)
            {
                InitialDeviceArray(typeof(TDevice), devArrayContainerAttribute);
            }
        }

        public WordDeviceArrayContainer(EDevice device, int count, string readBlockKey)
          : base(device, 0x0000, readBlockKey)
        {
            CreateDevices(count);
        }

        public WordDeviceArrayContainer(EDevice device, int count, string key, string readBlockKey)
            : base(device, key, readBlockKey)
        {
            CreateDevices(count);
        }

        public WordDeviceArrayContainer(EDevice device, int count, int startAddress, string readBlockKey)
            : base(device, startAddress, readBlockKey)
        {
            CreateDevices(count);
        }

        #endregion


        #region Public Methods

        new public TDevice GetDevice(int index)
        {
            return (TDevice)base.GetDevice(index);
        } 

        #endregion


        #region Private Methods

        private void CreateDevices(int count)
        {
            for (int i = 0; i < count; i++)
                Add(new TDevice { Offset = i, Key = $"{Key}{i}" });
        }

        #endregion

    }
}