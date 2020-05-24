using SPC.Core;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace IMPLC.Monitor
{
    public class DeviceMonitorViewModel : ViewModelBase
    {
        #region Public Properties

        public ObservableCollection<DeviceMonitorTabViewModel> DeviceTabs { get; private set; }

        public DeviceMonitorTabViewModel SelectedTab { get; set; }

        public bool ShowFindPanel { get; set; }

        public string TargetDevice { get; set; }

        #endregion


        #region Commands

        public ICommand ShowFindPanelCommand
        {
            get => new CommandBase
            {
                CanExecuteFunction = (param) => DeviceTabs.Count > 0,
                ExecuteAction = (param) =>
                {
                    ShowFindPanel = true;
                }
            };
        }

        public ICommand HideFindPanelCommand
        {
            get => new CommandBase
            {
                ExecuteAction = (param) =>
                {
                    ShowFindPanel = false;
                    TargetDevice = string.Empty;
                }
            };
        }

        public ICommand FindDeviceCommand
        {
            get => new CommandBase
            {
                ExecuteAction = (param) =>
                {
                    var deviceAddress = DeviceHelper.ConvertDeviceText(TargetDevice);
                    if (deviceAddress != null)
                    {
                        DeviceBase findDevice = null;
                        var foundTab = DeviceTabs.FirstOrDefault(tab => tab.FindDevice(deviceAddress, out findDevice));
                        if (foundTab != null)
                        {
                            SelectedTab = foundTab;
                            foundTab.GoToDevice(findDevice);
                        }
                    }

                    ShowFindPanel = false;
                    TargetDevice = string.Empty;
                }
            };
        }

        #endregion


        #region Constructor

        public DeviceMonitorViewModel(ServiceClientViewModel serviceClient)
        {
            DeviceTabs = new ObservableCollection<DeviceMonitorTabViewModel>();
            serviceClient.Connected += ServiceClient_Connected;
            serviceClient.Disconnected += ServiceClient_Disconnected;

        }

        #endregion


        #region Event Callback
        private void ServiceClient_Connected(DeviceManager devManager)
        {
            DeviceTabs.Clear();

            foreach (var deviceContainer in devManager)
            {
                switch (deviceContainer)
                {
                    case BitDeviceArrayContainer b:
                        {
                            var tab = new DeviceMonitorTabViewModel(b.Device.ToString(), b);
                            DeviceTabs.Add(tab);
                            break;
                        }
                    case WordDeviceArrayContainer w:
                        {
                            var tab = new DeviceMonitorTabViewModel(w.Device.ToString(), w);
                            DeviceTabs.Add(tab);
                            break;
                        }
                }
            }

            SelectedTab = DeviceTabs.FirstOrDefault();
        }

        private void ServiceClient_Disconnected()
        {
            DeviceTabs.Clear();
        } 
        #endregion

    }

}