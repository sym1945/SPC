using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            var orderByAddress = this.OfType<WordDevice>().OrderBy(d => d.Address);
            var firstDev = orderByAddress.FirstOrDefault();
            var writeValue = new List<short>(firstDev.RawData);

            foreach (var afterDev in orderByAddress.Skip(1))
            {
                var difference = writeValue.Count - afterDev.Address;
                // 추가될 데이터의 시작 주소가 이전 데이터와 겹칠 경우
                if (difference > 0)
                {
                    writeValue.RemoveRange(afterDev.Address - 1, difference);
                }
                // 추가될 데이터의 시작 주소가 이전 데이터 마지막 주소와 1 이상 차이날 경우
                else if (difference < 0)
                {
                    writeValue.AddRange(new short[difference * -1]);
                }

                writeValue.AddRange(afterDev.RawData);
            }

            // write to plc
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
