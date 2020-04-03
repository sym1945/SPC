using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPC.Core
{
    public abstract class HandshakeAction : PlcCommandActionBase
    {
        internal object Locker = new object();

        public bool IsRunning { get; protected set; }

        public BitDevice TriggerBit { get; private set; }

        public BitDevice ReplyBit { get; private set; }

        public abstract DeviceFindKey ReplyBitFindKey { get; }



        internal override void Initialize()
        {
            // Find Trigger Bit Device
            //if (PlcCommand != null)
            TriggerBit = DevManager.B(PlcCommand.Container)[PlcCommand.Device];


            // Find Reply Bit Device
            //if (ReplyBitFindKey != null)
            ReplyBit = DevManager.B(ReplyBitFindKey.Container)[ReplyBitFindKey.Device];
        }

    }
}
