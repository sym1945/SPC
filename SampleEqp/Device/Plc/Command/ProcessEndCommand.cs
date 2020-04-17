using SPC.Core;
using System;

namespace SampleEqp
{
    public class ProcessEndCommand : SendHandshakeAction
    {
        public override DeviceFindKey ReplyBitFindKey => new DeviceFindKey("CIM_REPLY", "UnloadStartReply");

        public override void TimeOutReplyBitOn()
        {
            Console.WriteLine("Reply Bit On TimeOut!");
        }

        public override void TimeOutReplyBitOff()
        {
            Console.WriteLine("Reply Bit Off TimeOut!");
        }
    }
}