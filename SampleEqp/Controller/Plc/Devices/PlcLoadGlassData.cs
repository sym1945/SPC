using SPC.Core;

namespace SampleEqp
{
    [SpcDeviceContainer(EDevice.W, EDeviceType.Word, 0x0420, "LOAD_GLASS_DATA", "3")]
    public class PlcLoadGlassData : A3GlassDataContainer
    {
    }
}
