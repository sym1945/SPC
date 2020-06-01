using SPC.Core;

namespace SampleEqp
{
    public class GlassLoadCommand : SendHandshake<GlassCommandParam, PlcHandler>
    {
        public override BitDevice CommandBit => Spc.Devices.PlcCommandBits.GlassInspLoadStart;

        public override BitDevice ReplyBit => Spc.Devices.CimReplyBits.GlassInspLoadStartReply;


        public override void BeforeCommandBitOn(GlassCommandParam commandParam)
        {
            Spc.Devices.PlcLoadGlassData.WriteGlassData(commandParam.GlassData);
        }


    }
}