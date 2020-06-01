using SPC.Core;

namespace SampleEqp
{

    [SpcDeviceContainer(EDevice.B, EDeviceType.Bit, "2", StartAddress = 0x0400)]
    public class PlcCommandBits : BitDeviceContainer
    {
        [SpcDevice(0x000A)]
        public BitDevice GlassInspLoadStart { get; private set; }

        [SpcDevice(0x000B)]
        public BitDevice GlassInspLoadPause { get; private set; }

        [SpcDevice(0x000C)]
        public BitDevice GlassInspLoadEnd { get; private set; }

        [SpcDevice(0x002A)]
        public BitDevice UnloadStart { get; private set; }

        [SpcDevice(0x002B)]
        public BitDevice UnlondPause { get; private set; }

        [SpcDevice(0x002C)]
        public BitDevice UnloadEnd { get; private set; }
    }
}
