using SPC.Core;
using System;

namespace SampleEqp
{
    public class PlcConfiguration : SpcConfiguration
    {
        public override SpcCommunication BuildCommunication()
        {
            return new Implc();
        }

        public override SpcDeviceManager BuildDeviceManager()
        {
            return new PlcDeviceManager();
        }

        public override SpcDeviceWatcher BuildDeviceWatcher()
        {
            return new SpcDeviceWatcher
            {
                new DeviceReadBlock { Device = EDevice.B, StartAddress = 0x0300, Size = 128, Key = "1" },
                new DeviceReadBlock { Device = EDevice.B, StartAddress = 0x0400, Size = 128, Key = "2" },
                new DeviceReadBlock { Device = EDevice.W, StartAddress = 0x0400, Size = 1024, Key = "3" },
            };
        }

        public override SpcCommandManager BuildCommandManager()
        {
            return new PlcCommandManagerBuilder()
                .AddPlcCommand<GlassLoadCommand>()
                .AddPlcCommand<ProcessEndCommand>()
                .AddPlcCommand<GlassUnloadCommand>()
                .Build();
        }
    }
}
