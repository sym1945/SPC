using System.Threading.Tasks;

namespace SPC.Core
{
    public class PlcCommand
    {
        /// <summary>
        /// Target Device Container Key
        /// </summary>
        public string Container { get; set; }

        /// <summary>
        /// Target Device Key
        /// </summary>
        public string Device { get; set; }

        /// <summary>
        /// Execute Command Trigger Condition
        /// </summary>
        public CommandTrigger Trigger { get; set; }

        /// <summary>
        /// Execute Command Name
        /// </summary>
        public string Command { get; set; }

    }


    public abstract class PlcCommandBase<TParam, TSpc>
        where TParam : PlcCommandParameter
        where TSpc : SPC
    {
        public DeviceManager Devices => SPCContainer.GetSPC<TSpc>().DeviceManager;
    }

    public abstract class HandshakeCommand<TParam, TSpc> : PlcCommandBase<TParam, TSpc>
        where TParam : PlcCommandParameter
        where TSpc : SPC
    {
        public bool IsRunning { get; protected set; }

        public abstract BitDevice TriggerBit { get; }
        public abstract BitDevice ReplyBit { get; }
    }

    public abstract class RecvHandshakeCommand<TParam, TSpc> : HandshakeCommand<TParam, TSpc>
        where TParam : PlcCommandParameter
        where TSpc : SPC
    {
        private object _Locker = new object();

        public bool CanExecute()
        {
            if (TriggerBit == null || ReplyBit == null)
                return false;

            return TriggerBit.IsOnTrigger;
        }

        public void Execute()
        {
            if (CanExecute() == false)
                return;

            lock (_Locker)
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

    public class GlassLoadHandshake : RecvHandshakeCommand<PlcCommandParameter, SPC>
    {
        public override BitDevice TriggerBit => Devices.B("CIM_BITS")["RecvAble"];

        public override BitDevice ReplyBit => Devices.B("IDX_BITS")["SendAble"];


        public override void AfterTriggerBitOn()
        {
            // Valid Check

            // Do Something...

            // Write Reply Data
        }

    }



}
