using SPC.Core;

namespace SampleEqp
{
    [SpcDeviceContainer(EDevice.W, EDeviceType.Word, "3", StartAddress = 0x0420)]
    public class PlcLoadGlassData : A3GlassDataContainer
    {
    }
}
