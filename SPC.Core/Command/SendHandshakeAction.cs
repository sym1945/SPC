using System;
using System.Collections.Generic;
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

                if (IsRunning)
                    return;

                IsRunning = true;
                DoHandshake();
            }
        }

        private PlcCommandParameter GetCommandParameter()
        {
            lock (Locker)
            {
                if (_CommandParameterQueue.Count > 0)
                    return _CommandParameterQueue.Dequeue();
                else
                    return null;
            }
        }


        public override bool CanExecute()
        {
            return false;
        }

        public override void Execute()
        {
            
        }


        public Task DoHandshake()
        {
            return Task.Run(() =>
            {
                PlcCommandParameter commandParam = null;

                while (true)
                {
                    Thread.Sleep(100); // Tn Delay

                    lock (Locker)
                    {
                        commandParam = GetCommandParameter();
                        if (commandParam == null)
                        {
                            IsRunning = false;
                            break;
                        }
                    }

                    BeforeTriggerBitOn(commandParam);

                    Thread.Sleep(100); // Tn Delay

                    TriggerBit.WriteValue(true);

                    var changed = ReplyBit.WaitBit(true, 5000); // T1

                    TriggerBit.WriteValue(false);

                    if (!changed)
                    {
                        TimeOutReplyBitOn();
                        continue;
                    }

                    changed = ReplyBit.WaitBit(false, 5000); // T2

                    if (!changed)
                    {
                        TimeOutReplyBitOff();
                    }

                    Console.WriteLine("Handshake Done");
                }
                
            });
        }



        public virtual void BeforeTriggerBitOn(PlcCommandParameter commandParam)
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
