using SPC.Core;
using System;
using System.Windows.Input;

namespace IMPLC.Monitor
{
    public class ServiceClientViewModel : ViewModelBase
    {
        private SpcHandler _SpcHandler;

        public string Uri { get; set; } = @"ipc://localhost:9090";

        public bool IsRunning { get; set; }

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
                        IsRunning = true;
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
                    if (_SpcHandler != null)
                    {
                        if (_SpcHandler.Stop())
                        {
                            IsRunning = false;
                            OnDisconnected();
                        }   
                    }
                }
            };
        }


        public event Action<SpcDeviceManager> Connected;

        public event Action Disconnected;

        protected void OnConnected(SpcDeviceManager devManager)
        {
            Connected?.Invoke(devManager);
        }

        protected void OnDisconnected()
        {
            Disconnected?.Invoke();
        }


    }
}
