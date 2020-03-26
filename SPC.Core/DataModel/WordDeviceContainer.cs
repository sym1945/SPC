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


        public void SetValue(string key, string value)
        {
            
        }

        public void SetValue(string key, short value)
        {
            
        }

        public void SetValue(string key, int value)
        {

        }

        public void UpdateDeviceValue(short[] rawData)
        {
            foreach (WordDevice device in this)
            {
                Array.Copy(rawData, device.Offset, device.Value.RawData, device.Offset, device.Length);
                // OnValueChanged
            }
        }

    }
}
