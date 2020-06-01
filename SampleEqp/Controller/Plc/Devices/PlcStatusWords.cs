using SPC.Core;

namespace SampleEqp
{
    [SpcDeviceContainer(EDevice.W, EDeviceType.Word, "3", StartAddress = 0x0400)]
    public class PlcStatusWords : WordDeviceContainer
    {
        [SpcDevice(0x0001)]
        public WordUShortDevice ProcessState { get; private set; }
    }
}
