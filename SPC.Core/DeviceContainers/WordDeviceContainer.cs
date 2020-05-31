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
