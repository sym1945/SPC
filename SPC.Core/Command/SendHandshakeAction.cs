using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SPC.Core
{
    public abstract class SendHandshakeAction : HandshakeAction
    {
        private Queue<PlcCommandParameter> _CommandParameterQueue = new Queue<PlcCommandParameter>();

        public void AddCommandParameter(PlcCommandParameter commandParameter)
        {
            lock (Locker)
            {
                _CommandParameterQueue.Enqueue(commandParameter);
            }
        }


        public override bool CanExecute()
        {
            return false;
        }

        public override void Execute()
        {
            lock (Locker)
            {
                if (IsRunning)
                    return;

                IsRunning = true;

                DoHandshake();
            }
        }


        public Task DoHandshake()
        {
            return Task.Run(() =>
            {
                BeforeTriggerBitOn();

                Thread.Sleep(1000); // Tn Delay

                TriggerBit.WriteValue(true);

                var timeout = ReplyBit.WaitBit(true, 2000); // T1

                TriggerBit.WriteValue(false);

                if (timeout)
                {
                    TimeOutReplyBitOn();
                    IsRunning = false;
                    return;
                }

                timeout = ReplyBit.WaitBit(false, 2000); // T2

                if (timeout)
                {
                    TimeOutReplyBitOff();
                }

                IsRunning = false;
            });
        }



        public virtual void BeforeTriggerBitOn()
        {

        }

        public virtual void TimeOutReplyBitOn()
        {

        }

        public virtual void TimeOutReplyBitOff()
        {

        }

    }
}
