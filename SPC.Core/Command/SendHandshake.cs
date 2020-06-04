using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SPC.Core
{
    public abstract class SendHandshake<T> : SendHandshake<SpcCommandParameter, T>
        where T : SpcBase
    {
        
    }

    public abstract class SendHandshake<TParam, TSpc> : SendCommandBase<TSpc>
        where TParam : SpcCommandParameter
        where TSpc : SpcBase
    {
        private readonly object _Locker = new object();

        private readonly Queue<SpcCommandParameter> _CommandParameterQueue = new Queue<SpcCommandParameter>();


        public abstract BitDevice CommandBit { get; }

        public abstract BitDevice ReplyBit { get; }


        public bool IsRunning { get; private set; }


        public override void AddCommandParameter(SpcCommandParameter commandParameter)
        {
            if (CommandBit == null || ReplyBit == null)
                return;

            lock (_Locker)
            {
                _CommandParameterQueue.Enqueue(commandParameter);

                if (IsRunning)
                    return;

                Task.Run(async () =>
                {
                    IsRunning = true;
                    await DoHandshake();
                    IsRunning = false;
                });
            }
        }

        private SpcCommandParameter GetCommandParameter()
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
            SpcCommandParameter commandParam = null;

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

                BeforeCommandBitOn((TParam)commandParam);

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
                AfterHandshakeDone();
            }
        }


        public virtual void BeforeCommandBitOn(TParam commandParam)
        {
        }

        public virtual void TimeOutReplyBitOn()
        {
        }

        public virtual void TimeOutReplyBitOff()
        {
        }

        public virtual void AfterHandshakeDone()
        {
        }

    }
}