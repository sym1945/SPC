using SPC.Core;

namespace SampleEqp
{
    public class ProcessEndCommand : SendHandshake<PlcHandler>
    {
        public override BitDevice CommandBit => Spc.Devices.PlcCommandBits.UnloadStart;

        public override BitDevice ReplyBit => Spc.Devices.CimReplyBits.UnloadStartReply;
    }
}