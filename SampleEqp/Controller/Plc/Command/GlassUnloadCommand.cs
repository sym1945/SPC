using SPC.Core;

namespace SampleEqp
{
    public class GlassUnloadCommand : SendHandshake<GlassCommandParam, PlcHandler>
    {
        public override BitDevice CommandBit => Spc.Devices.PlcCommandBits.UnloadEnd;

        public override BitDevice ReplyBit => Spc.Devices.CimReplyBits.UnloadEndReply;


        public override void BeforeCommandBitOn(GlassCommandParam commandParam)
        {
            Spc.Devices.PlcUnloadGlassData.WriteGlassData(commandParam.GlassData);
        }

    }
}