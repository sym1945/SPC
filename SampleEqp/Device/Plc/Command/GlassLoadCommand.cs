using SPC.Core;
using System;

namespace SampleEqp
{
    public class GlassLoadCommand : SendHandshakeAction
    {
        public override DeviceFindKey ReplyBitFindKey => new DeviceFindKey("CIM_REPLY", "GlassInspLoadStartReply");

        public override void BeforeTriggerBitOn(PlcCommandParameter commandParam)
        {
            var glassDataParam = commandParam as GlassCommandParam;
            var glassDataContainer = DevManager.GetDeviceContainer<A3GlassDataContainer>("LOAD_GLASS_DATA");

            glassDataContainer.WriteGlassData(glassDataParam.GlassData);
        }

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