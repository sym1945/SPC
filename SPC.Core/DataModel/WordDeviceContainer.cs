using System;
using System.Linq;

namespace SPC.Core
{
    public class WordDeviceContainer : DeviceContainer<WordDevice>
    {
        public WordDeviceContainer()
        {
            DeviceType = eDeviceType.Word;
        }
        public WordDeviceContainer(eDevice device, short startAddress, string key, int readBlockKey) : this()
        {
            Device = device;
            StartAddress = startAddress;
            Key = key;
            ReadBlockKey = readBlockKey;
        }

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


        public override void AfterRead(PlcReadBlock devBlock)
        {
            foreach (WordDevice device in this)
            {
                bool isChanged = false;
                var offset = device.Offset;
                var length = device.Length;

                try
                {
                    for (int i = 0, j = offset; i < length; i++, j++)
                    {
                        if (devBlock.Buffer[j] != device.RawData[i])
                        {
                            Array.Copy(devBlock.Buffer, offset, device.RawData, 0, length);
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

    }
}
