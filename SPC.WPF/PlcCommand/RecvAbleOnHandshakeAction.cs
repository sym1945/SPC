using SPC.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPC.WPF
{
    public class RecvAbleOnHandshakeAction : RecvHandshakeAction
    {
        public override DeviceFindKey ReplyBitFindKey => new DeviceFindKey("CIM_RECV_BITS", "RecvAble");


        public override void AfterTriggerBitOn()
        {
            Debug.WriteLine("Trigger Bit On");
        }

        public override void AfterTriggerBitOff()
        {
            Debug.WriteLine("Trigger Bit Off");
        }

        public override void TimeOutTriggerBitOff()
        {
            Debug.WriteLine("Trigger Bit Off Timeout");
        }

    }
}
