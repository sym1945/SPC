namespace IMPLC.Monitor
{
    public class MainViewModel : ViewModelBase
    {
        public ServiceClientViewModel ServiceClientViewModel { get; private set; }

        public DeviceMonitorViewModel DeviceMonitorViewModel { get; private set; }

        public MainViewModel()
        {
            ServiceClientViewModel = new ServiceClientViewModel();
            DeviceMonitorViewModel = new DeviceMonitorViewModel(ServiceClientViewModel);
        }
    }
}