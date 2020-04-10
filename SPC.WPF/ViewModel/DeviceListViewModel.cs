using SPC.Core;
using System.Windows.Input;

namespace SPC.WPF
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
            RecvBitDevices = manager.GetDeviceContainer<BitDeviceContainer>(1);
            SendBitDevices = manager.GetDeviceContainer<BitDeviceContainer>(2);
            WordDevices = manager.GetDeviceContainer<WordDeviceContainer>(3);
        }

    }
}
