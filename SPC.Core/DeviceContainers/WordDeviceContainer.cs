using System;
using System.Linq;

namespace SPC.Core
{
    public class WordDeviceContainer : SpcDeviceContainer<WordDevice>
    {
        #region Counstructor

        public WordDeviceContainer()
        {
            DeviceType = EDeviceType.Word;
        }

        public WordDeviceContainer(EDevice device, string readBlockKey)
          : base(device, EDeviceType.Word, 0x0000, readBlockKey)
        {
        }

        public WordDeviceContainer(EDevice device, string key, string readBlockKey)
            : base(device, EDeviceType.Word, key, readBlockKey)
        {
        }

        public WordDeviceContainer(EDevice device, int startAddress, string readBlockKey)
            : base(device, EDeviceType.Word, startAddress, readBlockKey)
        {
        }

        public WordDeviceContainer(EDevice device, int startAddress, string key, string readBlockKey)
            : base(device, EDeviceType.Word, startAddress, key, readBlockKey)
        {
        }

        #endregion


        #region Public Methods

        public void BatchWrite()
        {
            if (Count < 1)
                return;

            var firstDev = this.OrderBy(d => d.Address).FirstOrDefault();
            var writeValue = DeviceContainerHelper.GetBatchWriteValues(this);

            WriteToPlc(new WordReadWriteInfo
            {
                Address = firstDev.Address,
                Device = Device,
                Size = (short)writeValue.Count,
                Value = writeValue.ToArray()
            });
        }


        public override void AfterRead(DeviceReadBlock devBlock)
        {
            foreach (WordDevice device in this)
            {
                bool isChanged = false;
                var offset = device.Address - devBlock.StartAddress;
                var length = device.Length;

                try
                {
                    for (int i = 0, j = offset; i < length; i++, j++)
                    {
                        if (devBlock.Buffer[j] != device.ReadBufferData[i])
                        {
                            Array.Copy(devBlock.Buffer, offset, device.ReadBufferData, 0, length);
                            isChanged = true;
                            break;
                        }
                    }

                    if (isChanged)
                    {
                        device.OnRawDataChanged();
                    }
                }
                catch
                {
                    //TODO: todo Something
                }
            }
        } 

        #endregion

    }
}
