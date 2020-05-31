using SPC.Core;

namespace SampleEqp
{
    public static class PlcWatcherFactory
    {
        public static SpcDeviceWatcher Make()
        {
            return new SpcDeviceWatcher
            {
                new DeviceReadBlock { Device = EDevice.B, StartAddress = 0x0300, Size = 128, Key = "1" },
                new DeviceReadBlock { Device = EDevice.B, StartAddress = 0x0400, Size = 128, Key = "2" },
                new DeviceReadBlock { Device = EDevice.W, StartAddress = 0x0400, Size = 1024, Key = "3" },
            };

        }
    }
}