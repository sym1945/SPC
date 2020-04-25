using SPC.Core;

namespace SampleEqp
{
    public class GlassLoadCommand : SendHandshake<GlassCommandParam, SPC.Core.SPC>
    {
        public override BitDevice CommandBit => Devices.B("PLC_COMMAND")["GlassInspLoadStart"];

        public override BitDevice ReplyBit => Devices.B("CIM_REPLY")["GlassInspLoadStartReply"];


        public override void BeforeTriggerBitOn(GlassCommandParam commandParam)
        {
            var glassDataContainer = Devices.GetDeviceContainer<A3GlassDataContainer>("LOAD_GLASS_DATA");

            glassDataContainer.WriteGlassData(commandParam.GlassData);
        }


    }
}