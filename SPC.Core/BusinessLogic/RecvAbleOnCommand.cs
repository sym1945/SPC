using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPC.Core
{
    public class RecvAbleOnCommand
    {
        private DeviceManager DevManager;

        private PlcCommand PlcCommand;

        private DeviceFindKey ReplyDeviceKey = new DeviceFindKey("CIM_SEND_BITS", "SendAble");

        private BitDevice TriggerBit;

        private BitDevice ReplyBit;


        public RecvAbleOnCommand()
        {
            var containerKey = PlcCommand.Container;
            var deviceKey = PlcCommand.Device;

            TriggerBit = DevManager.B(containerKey)[deviceKey];
            ReplyBit = DevManager.B(ReplyDeviceKey.Container)[ReplyDeviceKey.Device];



        }

        /// <summary>
        /// Execute 가능 여부 확인
        /// </summary>
        /// <returns></returns>
        internal virtual bool CanExecute()
        {
            bool canExecute = false;
            var trigger = PlcCommand.Trigger;
            var containerKey = PlcCommand.Container;
            var deviceKey = PlcCommand.Device;

            switch (trigger)
            {
                case CommandTrigger.Change:
                    {
                        var container = DevManager.B(containerKey);
                        var dev = container?[deviceKey];
                        if (dev != null)
                            canExecute = dev.IsOffTrigger || dev.IsOnTrigger;

                        break;
                    }
                case CommandTrigger.BitOn:
                    {
                        var container = DevManager.B(containerKey);
                        var dev = container?[deviceKey];
                        if (dev != null)
                            canExecute = dev.IsOnTrigger;

                        break;
                    }
                case CommandTrigger.BitOff:
                    {
                        var container = DevManager.B(containerKey);
                        var dev = container?[deviceKey];
                        if (dev != null)
                            canExecute = dev.IsOffTrigger;

                        break;
                    }
            }

            return canExecute;
        }

        /// <summary>
        /// CanExecute 조건 만족 시 호출
        /// </summary>
        internal virtual void Execute()
        {

        }






    }
}
