using System.Collections;
using System.Threading;

namespace SPC.Core
{
    public class HandshakeAlarmEvent : BaseHandshake
    {
        private CancellationTokenSource _CancellationTokenSource = null;

        public BitDevice RequestBit { get; set; }

        public BitDevice ReplyBit { get; set; }

        #region Constructor

        public HandshakeAlarmEvent(DeviceHandler deviceHandler) : base(deviceHandler)
        {
        }  

        #endregion

        public void DoHandshake()
        {
            

            



            
        }




    }
}
