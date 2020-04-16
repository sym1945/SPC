using SPC.Core;

namespace SampleEqp
{
    public class ProcessEndCommand : SendHandshakeAction
    {
        public override DeviceFindKey ReplyBitFindKey => throw new System.NotImplementedException();
    }
}