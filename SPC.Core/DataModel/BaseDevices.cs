using System.Collections.Generic;

namespace SPC.Core
{
    public class BaseDevices
    {
        private Dictionary<short, short> _DeviceMap;

        public BaseDevices()
        {
            _DeviceMap = new Dictionary<short, short>();
        }

        public void Update()
        {
        }

    }
}
