using IMPLC.Core;
using SPC.Core;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace IMPLC.Monitor
{
    public class DeviceMonitorTabViewModel : ViewModelBase
    {
        #region Private Members

        private const int ITEM_COUNT_PER_PAGE = 16;

        private int _CurrentPage;

        private readonly List<SpcDeviceBase> _Devices; 

        #endregion


        #region Public Properties

        public string TabHeader { get; set; }

        public int PageCountPerScreen { get; set; }

        public int TotalPageCount { get; set; }

        public int CurrentPage
        {
            get => _CurrentPage;
            set
            {
                if (_CurrentPage == value)
                    return;
                if (value < 1
                    || value > TotalPageCount)
                    return;

                var oldPage = _CurrentPage;
                _CurrentPage = value;
                OnPropertyChanged(nameof(CurrentPage));

                if (oldPage + 1 == _CurrentPage)
                {
                    var nextPageItems = _Devices.Skip((_CurrentPage + PageCountPerScreen - 2) * ITEM_COUNT_PER_PAGE).Take(ITEM_COUNT_PER_PAGE);

                    ViewingPages.RemoveAt(0);
                    ViewingPages.Add(new DeviceMonitorPageViewModel(nextPageItems));
                }
                else if (oldPage - 1 == _CurrentPage)
                {
                    var prevPageItems = _Devices.Skip((_CurrentPage - 1) * ITEM_COUNT_PER_PAGE).Take(ITEM_COUNT_PER_PAGE);

                    ViewingPages.RemoveAt(PageCountPerScreen - 1);
                    ViewingPages.Insert(0, new DeviceMonitorPageViewModel(prevPageItems));
                }
                else
                {
                    ViewingPages.Clear();
                    SetDevicesInScreen(_CurrentPage);
                }
            }
        }

        public ObservableCollection<DeviceMonitorPageViewModel> ViewingPages { get; private set; } 

        #endregion


        #region Commands
        public ICommand PrevScreenCommand
        {
            get => new CommandBase
            {
                CanExecuteFunction = (d) => CurrentPage > 1,
                ExecuteAction = (d) =>
                {
                    var newPageNo = CurrentPage - PageCountPerScreen;
                    if (newPageNo < 1)
                        newPageNo = 1;

                    CurrentPage = newPageNo;
                }
            };
        }

        public ICommand PrevPageCommand
        {
            get => new CommandBase
            {
                CanExecuteFunction = (d) => CurrentPage > 1,
                ExecuteAction = (d) =>
                {
                    CurrentPage--;
                }
            };
        }

        public ICommand NextPageCommand
        {
            get => new CommandBase
            {
                CanExecuteFunction = (d) => CurrentPage < TotalPageCount,
                ExecuteAction = (d) =>
                {
                    CurrentPage++;
                }
            };
        }

        public ICommand NextScreenCommand
        {
            get => new CommandBase
            {
                CanExecuteFunction = (d) => CurrentPage < TotalPageCount,
                ExecuteAction = (d) =>
                {
                    var newPageNo = CurrentPage + PageCountPerScreen;
                    if (newPageNo > TotalPageCount)
                        newPageNo = TotalPageCount;

                    CurrentPage = newPageNo;
                }
            };
        }
        #endregion


        #region Construtor

        public DeviceMonitorTabViewModel(string header, IEnumerable<SpcDeviceBase> devices)
        {
            _Devices = new List<SpcDeviceBase>(devices);

            TabHeader = header;
            ViewingPages = new ObservableCollection<DeviceMonitorPageViewModel>();

            TotalPageCount = _Devices.Count / 16;
            if (_Devices.Count % 16 > 0)
                TotalPageCount++;

            PageCountPerScreen = 4;

            _CurrentPage = 1;
            SetDevicesInScreen(CurrentPage);
        }

        #endregion


        public bool FindDevice(string deviceAddress, out SpcDeviceBase foundDevice)
        {
            foundDevice = _Devices.FirstOrDefault(device => device.FullAddress == deviceAddress);

            return (foundDevice != null);
        }

        public void GoToDevice(SpcDeviceBase device)
        {
            var devIndex = _Devices.IndexOf(device);
            if (devIndex < 0)
                return;

            var pageNo = (devIndex / ITEM_COUNT_PER_PAGE) + 1;

            CurrentPage = pageNo;
        }


        #region Private Methods

        private void SetDevicesInScreen(int currentPage)
        {
            currentPage--;
            if (currentPage < 0)
                return;

            for (int i = currentPage; i < PageCountPerScreen + currentPage; i++)
            {
                var pageItems = _Devices.Skip(i * ITEM_COUNT_PER_PAGE).Take(ITEM_COUNT_PER_PAGE);

                ViewingPages.Add(new DeviceMonitorPageViewModel(pageItems));
            }
        } 

        #endregion

    }
}