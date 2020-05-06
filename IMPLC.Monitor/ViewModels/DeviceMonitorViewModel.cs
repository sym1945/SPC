using SPC.Core;
using System.Collections.ObjectModel;

namespace IMPLC.Monitor
{
    public class DeviceMonitorViewModel
    {
        public ObservableCollection<DeviceMonitorTabViewModel> DeviceTabs { get; private set; }


        public DeviceMonitorViewModel(ServiceClientViewModel serviceClient)
        {
            serviceClient.Connected += ServiceClient_Connected;
            serviceClient.Disconnected += ServiceClient_Disconnected;

        }

        private void ServiceClient_Connected(DeviceManager devManager)
        {
            DeviceTabs.Clear();

            foreach (var deviceContainer in devManager)
            {
                switch (deviceContainer)
                {
                    case BitDeviceArrayContainer b:
                        {
                            break;
                        }
                    case WordDeviceArrayContainer w:
                        {
                            break;
                        }
                }
            }
        }

        private void ServiceClient_Disconnected()
        {
            
        }

        
    }

}