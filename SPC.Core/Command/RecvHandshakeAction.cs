using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPC.Core
{
    public abstract class RecvHandshakeAction : HandshakeAction
    {
        public override bool CanExecute()
        {
            return TriggerBit?.IsOnTrigger ?? false;
        }

        public override async void Execute()
        {
            if (CanExecute() == false)
                return;

            lock (Locker)
            {
                if (IsRunning)
                    return;

                IsRunning = true;
            }

            await DoHandshake();

            IsRunning = false;
        }


        private Task DoHandshake()
        {
            return Task.Run(async () =>
            {
                AfterTriggerBitOn();

                ReplyBit.WriteValue(true);

                //TODO: Time 정보 Config로 보내기
                var changed = await TriggerBit.WaitBitAsync(false, 2000); // T4

                ReplyBit.WriteValue(false);

                if (changed)
                    AfterTriggerBitOff();
                else
                    TimeOutTriggerBitOff();
                
            });
        }

        public virtual void AfterTriggerBitOn()
        {

        }

        public virtual void AfterTriggerBitOff()
        {

        }

        public virtual void TimeOutTriggerBitOff()
        {

        }


    }
}
