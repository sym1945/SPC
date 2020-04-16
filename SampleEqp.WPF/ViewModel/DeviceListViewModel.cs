using SPC.Core;
using System.Windows.Input;

namespace SampleEqp.WPF
{
    public class DeviceListViewModel
    {
        public BitDeviceContainer RecvBitDevices { get; set; }

        public BitDeviceContainer SendBitDevices { get; set; }

        public WordDeviceContainer WordDevices { get; set; }


        public ICommand SendCommandTest
        {
            get => new CommandBase((parameter) =>
            {
                var spc = SPCContainer.GetSPC();
                
            });
        }



        public DeviceListViewModel(DeviceManager manager)
        {
            RecvBitDevices = manager.B("CIM_RECV_BIT");
            SendBitDevices = manager.B("CIM_SEND_BIT");
            WordDevices = manager.W("CIM_RECV_WORD");
        }

    }
}
