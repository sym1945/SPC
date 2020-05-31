using SPC.Core;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace IMPLC.Monitor
{
    public class DeviceMonitorPageViewModel
    {
        public ObservableCollection<SpcDeviceBase> Devices { get; private set; }

        public DeviceMonitorPageViewModel(IEnumerable<SpcDeviceBase> devices)
        {
            Devices = new ObservableCollection<SpcDeviceBase>(devices);
        }       
    }
}