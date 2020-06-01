using SPC.Core;

namespace SampleEqp
{

    [SpcDeviceContainer(EDevice.B, EDeviceType.Bit, "1", StartAddress = 0x0300)]
    public class CimReplyBits : BitDeviceContainer
    {
        [SpcDevice(0x003A)]
        public BitDevice GlassInspLoadStartReply { get; private set; }

        [SpcDevice(0x003B)]
        public BitDevice GlassInspLoadPauseReply { get; private set; }

        [SpcDevice(0x003C)]
        public BitDevice GlassInspLoadEndReply { get; private set; }

        [SpcDevice(0x004A)]
        public BitDevice UnloadStartReply { get; private set; }

        [SpcDevice(0x004B)]
        public BitDevice UnloadPauseReply { get; private set; }

        [SpcDevice(0x004C)]
        public BitDevice UnloadEndReply { get; private set; }
    }
}
