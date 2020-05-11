using SPC.Core;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace IMPLC.Monitor
{
    public class DeviceMonitorPageViewModel
    {
        public ObservableCollection<DeviceBase> Devices { get; private set; }

        public DeviceMonitorPageViewModel(IEnumerable<DeviceBase> devices)
        {
            Devices = new ObservableCollection<DeviceBase>(devices);
        }       
    }
}