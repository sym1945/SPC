using SPC.Core;

namespace SampleEqp
{
    [SpcDeviceContainer(EDevice.W, EDeviceType.Word, "3", StartAddress = 0x0588)]
    public class PlcUnloadGlassData : A3GlassDataContainer
    {
    }
}
