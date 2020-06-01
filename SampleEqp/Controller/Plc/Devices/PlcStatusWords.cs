using SPC.Core;

namespace SampleEqp
{
    [SpcDeviceContainer(EDevice.W, EDeviceType.Word, 0x0400, "EQP_STATUS", "3")]
    public class PlcStatusWords : WordDeviceContainer
    {
        [SpcDevice(0x0001)]
        public WordUShortDevice ProcessState { get; private set; }
    }
}
