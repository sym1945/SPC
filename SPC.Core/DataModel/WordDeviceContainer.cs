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
        public WordDeviceContainer(eDevice device, short startAddress, int readBlockKey, string desc = "") : this()
        {
            Device = device;
            StartAddress = startAddress;
            ReadBlockKey = readBlockKey;
            Description = desc;
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
