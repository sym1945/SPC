using SPC.Core;
using System;
using System.Windows.Input;

namespace IMPLC.Monitor
{
    public class ServiceClientViewModel : ViewModelBase
    {
        private SpcHandler _SpcHandler;

        public string Uri { get; set; } = @"ipc://localhost:9090";

        public ICommand ConnectStart
        {
            get => new CommandBase
            {
                ExecuteAction = (param) =>
                {
                    // TODO: URI parsing and Select Service Type

                    _SpcHandler = new SpcHandler(new Implc(Uri));
                    _SpcHandler.SetUp();

                    if (_SpcHandler.Start())
                    {
                        OnConnected(_SpcHandler.DeviceManager);
                    }
                    else
                    {
                        // Connect Fail
                        // TODO: message Popup
                    }
                }
            };
        }

        public ICommand ConnectStop
        {
            get => new CommandBase
            {
                ExecuteAction = (param) => 
                { 
                    // client Disconnect;
                }
            };
        }


        public event Action<DeviceManager> Connected;

        public event Action Disconnected;

        protected void OnConnected(DeviceManager devManager)
        {
            Connected?.Invoke(devManager);
        }

        protected void OnDisconnected()
        {
            Disconnected?.Invoke();
        }


    }
}
