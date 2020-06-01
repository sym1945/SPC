using SPC.Core;

namespace SampleEqp
{
    [SpcDeviceContainer(EDevice.W, EDeviceType.Word, 0x0588, "UNLOAD_GLASS_DATA", "3")]
    public class PlcUnloadGlassData : A3GlassDataContainer
    {
    }
}
