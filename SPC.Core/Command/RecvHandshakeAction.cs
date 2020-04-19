using System.Threading.Tasks;

namespace SPC.Core
{
    public abstract class RecvHandshakeAction : HandshakeAction
    {
        public override bool CanExecute()
        {
            return TriggerBit?.IsOnTrigger ?? false;
        }

        public override void Execute()
        {
            if (CanExecute() == false)
                return;

            lock (Locker)
            {
                if (IsRunning)
                    return;

                IsRunning = true;
                DoHandshake().DoNotAwait();
            }
        }


        private async Task DoHandshake()
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

            IsRunning = false;
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
