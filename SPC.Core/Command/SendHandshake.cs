using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SPC.Core
{
    public abstract class SendHandshake<T> : SendHandshake<PlcCommandParameter, T>
        where T : SPC
    {
        
    }

    public abstract class SendHandshake<TParam, T> : SendPlcCommand<T>
        where TParam : PlcCommandParameter
        where T : SPC
    {
        private readonly object _Locker = new object();

        private readonly Queue<PlcCommandParameter> _CommandParameterQueue = new Queue<PlcCommandParameter>();


        public abstract BitDevice CommandBit { get; }

        public abstract BitDevice ReplyBit { get; }


        public bool IsRunning { get; private set; }


        public override void AddCommandParameter(PlcCommandParameter commandParameter)
        {
            if (CommandBit == null || ReplyBit == null)
                return;

            lock (_Locker)
            {
                _CommandParameterQueue.Enqueue(commandParameter);

                if (IsRunning)
                    return;

                IsRunning = true;
                DoHandshake().DoNotAwait();
            }
        }

        private PlcCommandParameter GetCommandParameter()
        {
            lock (_Locker)
            {
                if (_CommandParameterQueue.Count > 0)
                    return _CommandParameterQueue.Dequeue();
                else
                    return null;
            }
        }


        public async Task DoHandshake()
        {
            PlcCommandParameter commandParam = null;

            while (true)
            {
                Thread.Sleep(100); // Tn Delay

                lock (_Locker)
                {
                    commandParam = GetCommandParameter();
                    if (commandParam == null)
                    {
                        IsRunning = false;
                        break;
                    }
                }

                BeforeTriggerBitOn((TParam)commandParam);

                Thread.Sleep(100); // Tn Delay

                CommandBit.WriteValue(true);

                var changed = await ReplyBit.WaitBitAsync(true, 5000); // T1

                CommandBit.WriteValue(false);

                if (!changed)
                {
                    Console.WriteLine("Reply Bit On TimeOut!");
                    TimeOutReplyBitOn();
                    continue;
                }

                changed = await ReplyBit.WaitBitAsync(false, 5000); // T2

                if (!changed)
                {
                    Console.WriteLine("Reply Bit Off TimeOut!");
                    TimeOutReplyBitOff();
                }

                Console.WriteLine("Handshake Done");
            }
        }


        public virtual void BeforeTriggerBitOn(TParam commandParam)
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