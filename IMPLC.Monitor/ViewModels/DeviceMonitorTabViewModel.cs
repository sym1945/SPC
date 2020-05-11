using SPC.Core;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace IMPLC.Monitor
{
    public class DeviceMonitorTabViewModel : ViewModelBase
    {
        private const int ITEM_COUNT_PER_PAGE = 16;

        private List<DeviceBase> _Devices;

        public string TabHeader { get; set; }

        public int TotalPageCount { get; set; }

        public int CurrentPage { get; set; }

        public DeviceMonitorPageViewModel FirstPage { get; private set; }
        public DeviceMonitorPageViewModel SecondPage { get; private set; }
        public DeviceMonitorPageViewModel ThirdPage { get; private set; }
        public DeviceMonitorPageViewModel LastPage { get; private set; }

        public ICommand PrevPageCommand
        {
            get => new CommandBase
            {
                CanExecuteFunction = (d) => CurrentPage > 1,
                ExecuteAction = (d) =>
                {
                    var prevPage = CurrentPage - 1;

                    LastPage = ThirdPage;
                    ThirdPage = SecondPage;
                    SecondPage = FirstPage;
                    FirstPage = new DeviceMonitorPageViewModel(_Devices.Skip((prevPage - 1) * ITEM_COUNT_PER_PAGE).Take(ITEM_COUNT_PER_PAGE));

                    CurrentPage = prevPage;
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
                    var nextPage = CurrentPage + 1;

                    FirstPage = SecondPage;
                    SecondPage = ThirdPage;
                    ThirdPage = LastPage;
                    LastPage = new DeviceMonitorPageViewModel(_Devices.Skip((nextPage + 3 - 1) * ITEM_COUNT_PER_PAGE).Take(ITEM_COUNT_PER_PAGE));

                    CurrentPage = nextPage;


                }
            };
        }



        public DeviceMonitorTabViewModel(string header, IEnumerable<DeviceBase> devices)
        {
            TabHeader = header;
            _Devices = new List<DeviceBase>(devices);

            TotalPageCount = _Devices.Count / 16;
            if (_Devices.Count % 16 > 0)
                TotalPageCount++;

            CurrentPage = 1;

            for (int i = 1; i <= TotalPageCount; i++)
            {
                var pageItems = _Devices.Skip((i - 1) * ITEM_COUNT_PER_PAGE).Take(ITEM_COUNT_PER_PAGE);

                if (i == 1)
                {
                    FirstPage = new DeviceMonitorPageViewModel(pageItems);
                }
                else if (i == 2)
                {
                    SecondPage = new DeviceMonitorPageViewModel(pageItems);
                }
                else if (i == 3)
                {
                    ThirdPage = new DeviceMonitorPageViewModel(pageItems);
                }
                else if (i == 4)
                {
                    LastPage = new DeviceMonitorPageViewModel(pageItems);
                }
                else
                {
                    break;
                }
                
            }

        }       
    }
}