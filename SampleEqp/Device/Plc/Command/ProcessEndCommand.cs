﻿using SPC.Core;

namespace SampleEqp
{
    public class ProcessEndCommand : SendHandshake<SPC.Core.SPC>
    {
        public override BitDevice CommandBit => Devices.B("PLC_COMMAND")["UnloadStart"];

        public override BitDevice ReplyBit => Devices.B("CIM_REPLY")["UnloadStartReply"];
    }
}