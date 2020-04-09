using SPC.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPC.WPF
{
    public class SendAbleOnHandshakeAction : SendHandshakeAction
    {
        public override DeviceFindKey ReplyBitFindKey => new DeviceFindKey("CIM_RECV_BITS", "RecvAble");


        public override void BeforeTriggerBitOn(PlcCommandParameter commandParam)
        {
            if (!(commandParam is SendGlassData glassData))
                return;

            var hpanelId = DevManager.W("CIM_RECV_WORDS")["RecvGlassId"];
            hpanelId.WriteValue(glassData.GlassId);
        }


        public override void TimeOutReplyBitOff()
        {
            Console.WriteLine("Reply Bit Off Time out!");
        }


        public override void TimeOutReplyBitOn()
        {
            Console.WriteLine("Reply Bit On Time out!");
        }

    }
}
