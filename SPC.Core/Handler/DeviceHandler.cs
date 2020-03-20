using System.Collections.Generic;

namespace SPC.Core
{
    public class DeviceHandler
    {
        private Dictionary<string, BaseDevices> _Devices;

        public BitDevices B => (BitDevices)_Devices["B"];
        public WordDevices W => (WordDevices)_Devices["W"];

        public DeviceHandler()
        {
            _Devices = new Dictionary<string, BaseDevices>
            {
                { "B", new BitDevices() },
                { "W", new WordDevices() }
            };
        }

        public IEnumerable<BaseDevices> GetDevices()
        {
            return _Devices.Values;
        }
    }
}
