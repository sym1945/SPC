using SPC.Core;

namespace SampleEqp
{
    public static class PlcWatcherFactory
    {
        public static PlcWatcher Make()
        {
            return new PlcWatcher
            {
                new PlcReadBlock { Device = eDevice.B, StartAddress = 0x0300, Size = 128, Key = 1 },
                new PlcReadBlock { Device = eDevice.B, StartAddress = 0x0400, Size = 128, Key = 2 },
                new PlcReadBlock { Device = eDevice.W, StartAddress = 0x0400, Size = 1024, Key = 3 },
            };

        }
    }
}