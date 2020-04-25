using SPC.Core;

namespace SampleEqp
{
    public class GlassUnloadCommand : SendHandshake<GlassCommandParam, SPC.Core.SPC>
    {
        public override BitDevice CommandBit => Devices.B("PLC_COMMAND")["UnloadEnd"];

        public override BitDevice ReplyBit => Devices.B("CIM_REPLY")["UnloadEndReply"];


        public override void BeforeTriggerBitOn(GlassCommandParam commandParam)
        {
            var glassDataContainer = Devices.GetDeviceContainer<A3GlassDataContainer>("UNLOAD_GLASS_DATA");

            glassDataContainer.WriteGlassData(commandParam.GlassData);
        }

    }
}