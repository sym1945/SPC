using SPC.Core;

namespace SampleEqp
{
    public class GlassUnloadCommand : SendHandshakeAction
    {
        public override DeviceFindKey ReplyBitFindKey => new DeviceFindKey("CIM_REPLY", "UnloadStartReply");

        public override void BeforeTriggerBitOn(PlcCommandParameter commandParam)
        {
            var glassDataParam = commandParam as GlassCommandParam;
            var glassDataContainer = DevManager.GetDeviceContainer<A3GlassDataContainer>("UNLOAD_GLASS_DATA");

            glassDataContainer.WriteGlassData(glassDataParam.GlassData);
        }

    }
}