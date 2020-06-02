namespace SPC.Core
{
    public class BitDeviceContainer : SpcDeviceContainer<BitDevice>
    {
        #region Constructor

        public BitDeviceContainer()
        {
            DeviceType = EDeviceType.Bit;
        }

        public BitDeviceContainer(EDevice device, string readBlockKey)
          : base(device, EDeviceType.Bit, 0x0000, readBlockKey)
        {
        }

        public BitDeviceContainer(EDevice device, string key, string readBlockKey)
            : base(device, EDeviceType.Bit, key, readBlockKey)
        {
        }

        public BitDeviceContainer(EDevice device, int startAddress, string readBlockKey)
            : base(device, EDeviceType.Bit, startAddress, readBlockKey)
        {
        }

        public BitDeviceContainer(EDevice device, int startAddress, string key, string readBlockKey)
            : base(device, EDeviceType.Bit, startAddress, key, readBlockKey)
        {
        }

        #endregion


        #region Public Methods

        public void SetValue(string key, bool value)
        {
            var dev = this[key];
            if (dev == null)
                return;

            dev.WriteValue(value);
        }

        public override void AfterRead(DeviceReadBlock devBlock)
        {
            foreach (BitDevice device in this)
            {
                try
                {
                    int offset = device.Address - devBlock.StartAddress;
                    int i = offset / 16;
                    int o = offset % 16;

                    if (i >= devBlock.Buffer.Length || i < 0)
                        continue;

                    var newValue = devBlock.Buffer[i].GetBit(o);
                    device.UpdateValue(newValue);
                }
                catch
                {
                    // TODO: todo Something
                }
            }
        } 

        #endregion

    }
}
