using SPC.Core;

namespace SampleEqp
{
    public class GlassUnloadCommand : SendHandshake<GlassCommandParam, PlcHandler>
    {
        public override BitDevice CommandBit => Devices.B("PLC_COMMAND")["UnloadEnd"];

        public override BitDevice ReplyBit => Devices.B("CIM_REPLY")["UnloadEndReply"];


        public override void BeforeCommandBitOn(GlassCommandParam commandParam)
        {
            var glassDataContainer = Devices.GetDeviceContainer<A3GlassDataContainer>("UNLOAD_GLASS_DATA");

            glassDataContainer.WriteGlassData(commandParam.GlassData);
        }

    }
}