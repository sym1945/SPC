using SPC.Core;
using System.CodeDom;
using System.Collections.ObjectModel;

namespace IMPLC.Monitor
{
    public class DeviceMonitorTabViewModel
    {
        public string TabHeader { get; set; }

        public ObservableCollection<DeviceBase> Devices { get; private set; }

        public DeviceMonitorTabViewModel()
        {
            Devices = new ObservableCollection<DeviceBase>();
        }       
    }
}